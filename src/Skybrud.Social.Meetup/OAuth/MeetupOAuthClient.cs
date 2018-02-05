using System;
using System.Net;
using Skybrud.Essentials.Common;
using Skybrud.Social.Http;
using Skybrud.Social.Meetup.Endpoints.Raw;
using Skybrud.Social.Meetup.Exceptions;
using Skybrud.Social.OAuth;

namespace Skybrud.Social.Meetup.OAuth {
    
    /// <summary>
    /// OAuth 1.0a client for the Meetup.com API.
    /// </summary>
    /// <see>
    ///     <cref>https://www.meetup.com/meetup_api/auth/#oauth</cref>
    /// </see>
    public class MeetupOAuthClient : SocialOAuthClient, IMeetupOAuthClient {

        #region Properties
        
        /// <summary>
        /// Gets a reference to the raw <strong>Events</strong> endpoint.
        /// </summary>
        public MeetupEventsRawEndpoint Events { get; }

        /// <summary>
        /// Gets a reference to the raw <strong>Groups</strong> endpoint.
        /// </summary>
        public MeetupGroupsRawEndpoint Groups { get; }

        #endregion
        
        /// <summary>
        /// Initializes a new instance with default options.
        /// </summary>
        public MeetupOAuthClient() {

            // Endpoints
            Events = new MeetupEventsRawEndpoint(this);
            Groups = new MeetupGroupsRawEndpoint(this);

            // Specific to LinkedIn
            RequestTokenUrl = "https://api.meetup.com/oauth/request/";
            AuthorizeUrl = "https://secure.meetup.com/authenticate/";
            AccessTokenUrl = "https://api.meetup.com/oauth/access/";
        
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


        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        protected override SocialHttpResponse GetRequestTokenResponse() {

            // Some error checking
            if (String.IsNullOrWhiteSpace(RequestTokenUrl)) throw new PropertyNotSetException("RequestTokenUrl");
            if (String.IsNullOrWhiteSpace(AuthorizeUrl)) throw new PropertyNotSetException("AuthorizeUrl");

            // Make the call to the API/provider
            SocialHttpResponse response = DoHttpPostRequest(RequestTokenUrl);
            
            if (response.StatusCode != HttpStatusCode.OK) {
                throw new MeetupOAuthException(response);
            }

            return response;

        }

    }

}