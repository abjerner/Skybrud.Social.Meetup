# Authentication

The Meetup API uses OAuth 2.0 for authentication, which requires a user to go through an authentication flow where they have to accept that your app gets access to their Meetup data.

A successful authentication gives you both an *access token* and a *refresh token*. In theory access tokens are short-lived (an hour according to the Meetup authentication), so the refresh token can be used to obtain a new short-lived access token for the user. In practice, Meetup access token don't seem to expire.




## From an access token

An access token is obtained either by sending the user through Meetup's OAuth authentication flow, or from exchanging a refresh token for an access token.

The `MeetupHttpService` class is the main entry point for accessing the Meetup API, and you can create a new instance by using the `MeetupHttpService.CreateFromAccessToken` method:

```cshtml
@using Microsoft.AspNetCore.Mvc.Razor
@using Skybrud.Social.Meetup
@inherits RazorPage

@{

    // Create a new instance of the HTTP service (aka the API wrapper)
    MeetupHttpService meetup = MeetupHttpService.CreateFromAccessToken("Your access token here");

}
```

Notice that this step it self doesn't involve any requests to the Meetup API.




## From a refresh token

You can also create a new `MeetupHttpService` instance from the user's refresh token along with the client ID and client secret of your Meetup app. Under the hood, the package use these three to request the Meetup API for a new access token for the user.

```cshtml
@using Microsoft.AspNetCore.Mvc.Razor
@using Skybrud.Social.Meetup
@inherits RazorPage

@{

    // Create a new instance of the HTTP service (aka the API wrapper)
    MeetupHttpService meetup = MeetupHttpService.CreateFromRefreshToken("Your client ID", "Your client secret", "Your refresh token");

}
```

As the `CreateFromRefreshToken` method results in a request to the Meetup API, you should ideally cache the created `MeetupHttpService`. The Meetup API indicates that access tokens live for an hour, but in practice Meetup access tokens don't seem to expire.






## Caching the HTTP service

As mentioned before, when getting a new `MeetupHttpService` instance from a refresh token, it's advised to cache the created instance, so we don't keep creating new access token when not necessary.

The example below uses [Umbraco](https://github.com/umbraco/Umbraco-CMS/) and dependency injection to create the `MeetupApiAccessor` class. In Umbraco, the `AppCaches` exposes different types of cache, and for our use case, we can use it's `RuntimeCache` property to cache instances for the duration of the application - or for a specified duration in this case.

As the Meetup API documentation mentions that access tokens expire in an hour, we cache the created `MeetupHttpService` for just short of an hour to account for different machines not having their time 100% in sync.

```csharp
using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Skybrud.Essentials.Http.Exceptions;
using Skybrud.Social.Meetup;
using Skybrud.Social.Meetup.OAuth;
using Skybrud.Social.Meetup.Responses.Authentication;
using Umbraco.Cms.Core.Cache;

namespace code.Features.Meetup {

    public class MeetupApiAccessor {

        private readonly ILogger<MeetupApiAccessor> _logger;
        private readonly IConfiguration _configuration;
        private readonly AppCaches _appCaches;

        public MeetupApiAccessor(ILogger<MeetupApiAccessor> logger, IConfiguration configuration, AppCaches appCaches) {
            _logger = logger;
            _configuration = configuration;
            _appCaches = appCaches;
        }

        /// <summary>
        /// Returns a <see cref="MeetupHttpService"/> instance for accessing the Meetup API.
        /// </summary>
        public MeetupHttpService Api => (MeetupHttpService) _appCaches.RuntimeCache
            .Get("MeetupApiAccessor", Factory, TimeSpan.FromMinutes(59))!;

        private MeetupHttpService Factory() {

            string clientId = _configuration.GetSection("Limbo:Integrations:Meetup:ClientId").Value;
            string clientSecret = _configuration.GetSection("Limbo:Integrations:Meetup:ClientSecret").Value;
            string refreshToken = _configuration.GetSection("Limbo:Integrations:Meetup:RefreshToken").Value;

            if (string.IsNullOrWhiteSpace(clientId)) throw new Exception("Required 'Limbo:Integrations:Meetup:ClientId' not specified in app settings.");
            if (string.IsNullOrWhiteSpace(clientSecret)) throw new Exception("Required 'Limbo:Integrations:Meetup:ClientSecret' not specified in app settings.");
            if (string.IsNullOrWhiteSpace(refreshToken)) throw new Exception("Required 'Limbo:Integrations:Meetup:RefreshToken' not specified in app settings.");

            MeetupOAuthClient client = new() {
                ClientId = clientId,
                ClientSecret = clientSecret
            };

            try {

                // use the refresh token to obtain a new access token
                MeetupTokenResponse response = client.GetAccessTokenFromRefreshToken(refreshToken);

                // Set the access token of the OAuth client
                client.AccessToken = response.Body.AccessToken;

                // Initialize and return a new HTTP service
                return MeetupHttpService.CreateFromOAuthClient(client);

            } catch (HttpException ex) {

                // Write the exception to the Umbraco log
                _logger.LogError(ex, "Failed obtaining new Meetup access token.");

                // Throw a new exception wrapping the thrown exception
                throw new Exception("Failed obtaining new Meetup access token.", ex);

            }

        }

    }

}
```
