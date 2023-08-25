using System;
using Skybrud.Social.Meetup.Endpoints;
using Skybrud.Social.Meetup.OAuth;
using Skybrud.Social.Meetup.Responses.Authentication;

namespace Skybrud.Social.Meetup;

/// <summary>
/// Class working as an entry point to the Meetup API.
/// </summary>
/// <example>
/// Initializing a new instance for public API access (no authentication):
/// <code>
/// MeetupHttpService meetup = new MeetupHttpService();
/// </code>
/// </example>
/// <example>
/// If you already have an OAuth 2.0 access token you wish to use for authentication, you can instead use the
/// static <see cref="CreateFromAccessToken"/> method.
/// <code>
/// MeetupHttpService meetup = MeetupHttpService.CreateFromAccessToken("your access token");
/// </code>
/// </example>
public class MeetupHttpService {

    #region Properties

    /// <summary>
    /// Gets a reference to the internal OAuth client for communication with the Meetup API.
    /// </summary>
    public MeetupOAuthClient Client { get; }

    /// <summary>
    /// Gets a reference to the <strong>Events</strong> endpoint.
    /// </summary>
    public MeetupEventsEndpoint Events { get; }

    /// <summary>
    /// Gets a reference to the <strong>Groups</strong> endpoint.
    /// </summary>
    public MeetupGroupsEndpoint Groups { get; }

    /// <summary>
    /// Gets a reference to the <strong>GraphQL</strong> endpoint.
    /// </summary>
    public MeetupGraphQlEndpoint GraphQl { get; }

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance with default settings.
    /// </summary>
    public MeetupHttpService() : this(new MeetupOAuthClient()) { }

    private MeetupHttpService(MeetupOAuthClient client) {
        Client = client;
        Events = new MeetupEventsEndpoint(this);
        Groups = new MeetupGroupsEndpoint(this);
        GraphQl = new MeetupGraphQlEndpoint(this);
    }

    #endregion

    #region Static methods

    /// <summary>
    /// Initializes a new instance for public access to the Meetup.com API.
    /// </summary>
    /// <returns>A new instance of <see cref="MeetupHttpService"/>.</returns>
    public static MeetupHttpService Create() {
        return new MeetupHttpService();
    }

    /// <summary>
    /// Initializes a new service based on the specified <paramref name="client"/>.
    /// </summary>
    /// <param name="client">The OAuth client to use.</param>
    /// <returns>A new instance of <see cref="MeetupHttpService"/>.</returns>
    public static MeetupHttpService CreateFromOAuthClient(MeetupOAuthClient client) {
        if (client == null) throw new ArgumentNullException(nameof(client));
        return new MeetupHttpService(client);
    }

    /// <summary>
    /// Initializes a new service based on the specified <strong>OAuth 2.0</strong> <paramref name="accessToken"/>.
    /// </summary>
    /// <param name="accessToken">The <strong>OAuth 2.0</strong> access token.</param>
    /// <returns>A new instance of <see cref="MeetupHttpService"/>.</returns>
    public static MeetupHttpService CreateFromAccessToken(string accessToken) {
        if (string.IsNullOrWhiteSpace(accessToken)) throw new ArgumentNullException(nameof(accessToken));
        return new MeetupHttpService(new MeetupOAuthClient { AccessToken = accessToken });
    }

    /// <summary>
    /// Initializes a new instance based on the specified refresh token. The refresh token is used for making a
    /// call to the Meetup API to get a new access token.
    /// </summary>
    /// <param name="clientId">The client ID.</param>
    /// <param name="clientSecret">The client secret.</param>
    /// <param name="refreshToken">The refresh token.</param>
    public static MeetupHttpService CreateFromRefreshToken(string clientId, string clientSecret, string refreshToken) {

        // Input validation
        if (string.IsNullOrWhiteSpace(clientId)) throw new ArgumentNullException(nameof(clientId));
        if (string.IsNullOrWhiteSpace(clientSecret)) throw new ArgumentNullException(nameof(clientSecret));
        if (string.IsNullOrWhiteSpace(refreshToken)) throw new ArgumentNullException(nameof(refreshToken));

        // Initialize a new OAuth client
        MeetupOAuthClient client = new() {
            ClientId = clientId,
            ClientSecret = clientSecret
        };

        // Exchange the refresh token for a new access token
        MeetupTokenResponse response = client.GetAccessTokenFromRefreshToken(refreshToken);

        // Set the access token of the OAuth client
        client.AccessToken = response.Body.AccessToken;

        // Initialize new HTTP service
        return new MeetupHttpService(client);

    }

    #endregion

}