using Skybrud.Social.Meetup.Endpoints.Raw;
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
        
        public MeetupEventsRawEndpoint Events { get; }

        public MeetupGroupsRawEndpoint Groups { get; }

        #endregion

        public MeetupOAuthClient(string consumerKey, string consumerSecret, string token, string tokenSecret, string callback) {

            // Endpoints
            Events = new MeetupEventsRawEndpoint(this);
            Groups = new MeetupGroupsRawEndpoint(this);

            // Common properties
            ConsumerKey = consumerKey;
            ConsumerSecret = consumerSecret;
            Token = token;
            TokenSecret = tokenSecret;
            Callback = callback;

            // Specific to LinkedIn
            RequestTokenUrl = "https://api.meetup.com/oauth/request/";
            AuthorizeUrl = "https://api.meetup.com/oauth/authenticate";
            AccessTokenUrl = "https://api.meetup.com/oauth/access/";
        
        }

    }

}