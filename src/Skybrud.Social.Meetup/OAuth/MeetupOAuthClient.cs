using System;
using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Client;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Social.Meetup.Endpoints.Raw;
using Skybrud.Social.Meetup.Responses.Authentication;
using Skybrud.Social.Meetup.Scopes;

namespace Skybrud.Social.Meetup.OAuth {

    /// <summary>
    /// OAuth 2.0 client for the Meetup.com API.
    /// </summary>
    public class MeetupOAuthClient : HttpClient {

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

        /// <summary>
        /// Gets a reference to the raw <strong>Events</strong> endpoint.
        /// </summary>
        public MeetupEventsRawEndpoint Events { get; }

        /// <summary>
        /// Gets a reference to the raw <strong>Groups</strong> endpoint.
        /// </summary>
        public MeetupGroupsRawEndpoint Groups { get; }

        /// <summary>
        /// Gets a reference to the raw <strong>Members</strong> endpoint.
        /// </summary>
        public MeetupMembersRawEndpoint Members { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance with default options.
        /// </summary>
        public MeetupOAuthClient() {
            Events = new MeetupEventsRawEndpoint(this);
            Groups = new MeetupGroupsRawEndpoint(this);
            Members = new MeetupMembersRawEndpoint(this);
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
            if (string.IsNullOrWhiteSpace(ClientId)) throw new PropertyNotSetException(nameof(ClientId));
            if (string.IsNullOrWhiteSpace(RedirectUri)) throw new PropertyNotSetException(nameof(RedirectUri));

            // Do we have a valid "state" ?
            if (string.IsNullOrWhiteSpace(state)) {
                throw new ArgumentNullException(nameof(state), "A valid state should be specified as it is part of the security of OAuth 2.0.");
            }

            IHttpQueryString query = new HttpQueryString();
            query.Add("client_id", ClientId);
            query.Add("redirect_uri", RedirectUri);
            query.Add("response_type", "code");
            query.Add("state", state);

            string s = string.Join("+", scope ?? new string[0]);
            if (!string.IsNullOrWhiteSpace(s)) query.Add("scope", s);

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
            if (string.IsNullOrWhiteSpace(ClientId)) throw new PropertyNotSetException(nameof(ClientId));
            if (string.IsNullOrWhiteSpace(ClientSecret)) throw new PropertyNotSetException(nameof(ClientSecret));
            if (string.IsNullOrWhiteSpace(RedirectUri)) throw new PropertyNotSetException(nameof(RedirectUri));
            if (string.IsNullOrWhiteSpace(authCode)) throw new ArgumentNullException(nameof(authCode));

            // Initialize the query string
            HttpPostData data = new HttpPostData {
                {"client_id", ClientId},
                {"client_secret", ClientSecret},
                {"grant_type", "authorization_code"},
                {"redirect_uri", RedirectUri},
                {"code", authCode}
            };

            // Make the call to the API
            IHttpResponse response = HttpUtils.Requests
                .Post("https://secure.meetup.com/oauth2/access", null, data);

            // Parse the response
            return MeetupTokenResponse.ParseResponse(response);

        }

        /// <summary>
        /// Updates requests passed through this client - eg. appending an <c>Authorization</c> header when <see cref="AccessToken"/> has a value.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <see>
        ///     <cref>https://www.meetup.com/api/authentication/</cref>
        /// </see>
        protected override void PrepareHttpRequest(IHttpRequest request) {

            base.PrepareHttpRequest(request);

            // Append the scheme and host name if not already present
            if (request.Url.StartsWith("/")) request.Url = $"https://api.meetup.com{request.Url}";

            if (!string.IsNullOrWhiteSpace(AccessToken)) {
                request.Headers.Authorization = $"Bearer {AccessToken}";
            }

        }

        #endregion

    }

}