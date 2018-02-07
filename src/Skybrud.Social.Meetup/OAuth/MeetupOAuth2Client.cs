using System;
using Skybrud.Essentials.Common;
using Skybrud.Social.Http;
using Skybrud.Social.Meetup.Endpoints.Raw;
using Skybrud.Social.Meetup.Scopes;

namespace Skybrud.Social.Meetup.OAuth {
    
    /// <summary>
    /// OAuth 2.0 client for the Meetup.com API.
    /// </summary>
    public class MeetupOAuth2Client : SocialHttpClient, IMeetupOAuthClient {

        #region Properties
        
        #region OAuth

        /// <summary>
        /// Gets or sets the client ID of the app.
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// Gets or sets the client secret of the app.
        /// </summary>
        public string ClientSecret { get; set; }
        
        /// <summary>
        /// Gets or sets the redirect URI of your application.
        /// </summary>
        public string RedirectUri { get; set; }

        /// <summary>
        /// Gets or sets the access token.
        /// </summary>
        public string AccessToken { get; set; }

        #endregion

        public MeetupEventsRawEndpoint Events { get; }

        public MeetupGroupsRawEndpoint Groups { get; }

        /// <summary>
        /// Gets or sets the API key.
        /// </summary>
        public string ApiKey { get; set; }

        #endregion

        #region Constructors

        public MeetupOAuth2Client() {

            // Endpoints
            Events = new MeetupEventsRawEndpoint(this);
            Groups = new MeetupGroupsRawEndpoint(this);
        
        }

        #endregion

        #region Member methods
        
        /// <summary>
        /// Generates the authorization URL using the specified <paramref name="state"/> and the default scope.
        /// </summary>
        /// <param name="state">The state to send to Meetups's OAuth login page.</param>
        /// <returns>An authorization URL based on <paramref name="state"/>.</returns>
        public string GetAuthorizationUrl(string state) {
            return GetAuthorizationUrl(state, new string[0]);
        }

        /// <summary>
        /// Generates the authorization URL using the specified <paramref name="state"/> and <paramref name="scope"/>.
        /// </summary>
        /// <param name="state">The state to send to Meetups's OAuth login page.</param>
        /// <param name="scope">The scope of the application.</param>
        /// <returns>An authorization URL based on <paramref name="state"/> and <paramref name="scope"/>.</returns>
        public string GetAuthorizationUrl(string state, MeetupScopeCollection scope) {
            return GetAuthorizationUrl(state, scope?.ToString());
        }
        
        /// <summary>
        /// Generates the authorization URL using the specified <paramref name="state"/> and <paramref name="scope"/>.
        /// </summary>
        /// <param name="state">The state to send to Meetups's OAuth login page.</param>
        /// <param name="scope">The scope of the application.</param>
        /// <returns>An authorization URL based on <paramref name="state"/> and <paramref name="scope"/>.</returns>
        public string GetAuthorizationUrl(string state, params string[] scope) {

            // Some validation
            if (String.IsNullOrWhiteSpace(ClientId)) throw new PropertyNotSetException(nameof(ClientId));
            if (String.IsNullOrWhiteSpace(RedirectUri)) throw new PropertyNotSetException(nameof(RedirectUri));

            // Do we have a valid "state" ?
            if (String.IsNullOrWhiteSpace(state)) {
                throw new ArgumentNullException(nameof(state), "A valid state should be specified as it is part of the security of OAuth 2.0.");
            }

            // Generate the authorization URL
            return $"https://secure.meetup.com/oauth2/authorize?client_id={ClientId}&redirect_uri={RedirectUri}&state={state}&scope={String.Join("+", scope)}";
        
        }

        #endregion

    }

}