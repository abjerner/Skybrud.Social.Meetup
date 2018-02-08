using System;
using Skybrud.Essentials.Common;
using Skybrud.Social.Http;
using Skybrud.Social.Interfaces.Http;
using Skybrud.Social.Meetup.Endpoints.Raw;
using Skybrud.Social.Meetup.Responses.Authentication;
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

            IHttpQueryString query = new SocialHttpQueryString();
            query.Add("client_id", ClientId);
            query.Add("redirect_uri", RedirectUri);
            query.Add("response_type", "code");
            query.Add("state", state);

            string s = String.Join("+", scope ?? new string[0]);
            if (!String.IsNullOrWhiteSpace(s)) query.Add("scope", s);

            // Generate the authorization URL
            return "https://secure.meetup.com/oauth2/authorize?" + query;
        
        }


        /// <summary>
        /// Exchanges the specified authorization code for an access token.
        /// </summary>
        /// <param name="authCode">The authorization code received from the Meetup OAuth dialog.</param>
        /// <returns>An instance of <see cref="MeetupTokenResponse"/> representing the response.</returns>
        public MeetupTokenResponse GetAccessTokenFromAuthCode(string authCode) {

            // Some validation
            if (String.IsNullOrWhiteSpace(ClientId)) throw new PropertyNotSetException("ClientId");
            if (String.IsNullOrWhiteSpace(ClientSecret)) throw new PropertyNotSetException("ClientSecret");
            if (String.IsNullOrWhiteSpace(RedirectUri)) throw new PropertyNotSetException("RedirectUri");
            if (String.IsNullOrWhiteSpace(authCode)) throw new ArgumentNullException(nameof(authCode));

            // Initialize the query string
            SocialHttpPostData data = new SocialHttpPostData {
                {"client_id", ClientId},
                {"client_secret", ClientSecret},
                {"grant_type", "authorization_code"},
                {"redirect_uri", RedirectUri},
                {"code", authCode}
            };

            // Make the call to the API
            SocialHttpResponse response = SocialUtils.Http.DoHttpPostRequest("https://secure.meetup.com/oauth2/access", null, data);
            
            // Parse the response
            return MeetupTokenResponse.ParseResponse(response);

        }

        #endregion

    }

}