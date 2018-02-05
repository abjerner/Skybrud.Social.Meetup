using Skybrud.Social.Http;
using Skybrud.Social.Meetup.Endpoints.Raw;

namespace Skybrud.Social.Meetup.OAuth {
    
    /// <summary>
    /// OAuth 2.0 client for the Meetup.com API.
    /// </summary>
    public class MeetupOAuth2Client : SocialHttpClient, IMeetupOAuthClient {

        #region Properties
        
        public MeetupEventsRawEndpoint Events { get; }

        public MeetupGroupsRawEndpoint Groups { get; }

        public string AccessToken { get; set; }

        public string ApiKey { get; set; }

        #endregion

        #region Constructors

        public MeetupOAuth2Client() {

            // Endpoints
            Events = new MeetupEventsRawEndpoint(this);
            Groups = new MeetupGroupsRawEndpoint(this);
        
        }

        #endregion

    }

}