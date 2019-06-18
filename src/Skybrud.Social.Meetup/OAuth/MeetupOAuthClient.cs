using System.Net;
using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.OAuth;
using Skybrud.Social.Meetup.Endpoints.Raw;
using Skybrud.Social.Meetup.Exceptions;

namespace Skybrud.Social.Meetup.OAuth {
    
    /// <summary>
    /// OAuth 1.0a client for the Meetup.com API.
    /// </summary>
    /// <see>
    ///     <cref>https://www.meetup.com/meetup_api/auth/#oauth</cref>
    /// </see>
    public class MeetupOAuthClient : OAuthClient, IMeetupOAuthClient {

        #region Properties
        
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

            // Endpoints
            Events = new MeetupEventsRawEndpoint(this);
            Groups = new MeetupGroupsRawEndpoint(this);
            Members = new MeetupMembersRawEndpoint(this);

            // Specific to LinkedIn
            RequestTokenUrl = "https://api.meetup.com/oauth/request/";
            AuthorizeUrl = "https://secure.meetup.com/authenticate/";
            AccessTokenUrl = "https://api.meetup.com/oauth/access/";
        
        }

        /// <summary>
        /// Initializes a new instance based on the <paramref name="consumerKey"/>, <paramref name="consumerSecret"/>,
        /// <paramref name="token"/> and <paramref name="tokenSecret"/>.
        /// </summary>
        /// <param name="consumerKey">The comsumer key of your application.</param>
        /// <param name="consumerSecret">The consumer secret of your application.</param>
        /// <param name="token">The access token of the user.</param>
        /// <param name="tokenSecret">The access token secret of the user.</param>
        public MeetupOAuthClient(string consumerKey, string consumerSecret, string token, string tokenSecret) : this() {
            ConsumerKey = consumerKey;
            ConsumerSecret = consumerSecret;
            Token = token;
            TokenSecret = tokenSecret;
        }

        /// <summary>
        /// Initializes a new instance based on the <paramref name="consumerKey"/>, <paramref name="consumerSecret"/>,
        /// <paramref name="token"/>, <paramref name="tokenSecret"/> and <paramref name="callback"/>.
        /// </summary>
        /// <param name="consumerKey">The comsumer key of your application.</param>
        /// <param name="consumerSecret">The consumer secret of your application.</param>
        /// <param name="token">The access token of the user.</param>
        /// <param name="tokenSecret">The access token secret of the user.</param>
        /// <param name="callback">The callback URI used for authentication.</param>
        public MeetupOAuthClient(string consumerKey, string consumerSecret, string token, string tokenSecret, string callback) : this() {
            ConsumerKey = consumerKey;
            ConsumerSecret = consumerSecret;
            Token = token;
            TokenSecret = tokenSecret;
            Callback = callback;
        }

        #endregion

        #region Member methods

        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        protected override IHttpResponse GetRequestTokenResponse() {
            
            // Some error checking
            if (string.IsNullOrWhiteSpace(RequestTokenUrl)) throw new PropertyNotSetException(nameof(RequestTokenUrl));
            if (string.IsNullOrWhiteSpace(AuthorizeUrl)) throw new PropertyNotSetException(nameof(AuthorizeUrl));

            // Make the call to the API/provider
            IHttpResponse response = DoHttpPostRequest(RequestTokenUrl);
            
            if (response.StatusCode != HttpStatusCode.OK) {
                throw new MeetupOAuthException(response);
            }

            return response;

        }

        /// <summary>
        /// Updates the request with missing information. For <see cref="MeetupOAuthClient"/> specifically, this means
        /// that the scheme and host name of the API are prepended to the URL if not already present. 
        /// </summary>
        /// <param name="request">The instance of <see cref="IHttpRequest"/> representing the request.</param>
        protected override void PrepareHttpRequest(IHttpRequest request) {

            base.PrepareHttpRequest(request);

            // Append the scheme and host name if not already present
            if (request.Url.StartsWith("/")) request.Url = "https://api.meetup.com" + request.Url;
            
        }

        #endregion

    }

}