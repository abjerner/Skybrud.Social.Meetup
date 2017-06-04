using Skybrud.Social.Http;
using Skybrud.Social.Meetup.Endpoints.Raw;

namespace Skybrud.Social.Meetup {
    
    public class MeetupClient : SocialHttpClient {

        public string ApiKey { get; set; }

        public MeetupEventsRawEndpoint Events { get; private set; }

        public MeetupGroupsRawEndpoint Groups { get; private set; }

        public MeetupClient() {
            Events = new MeetupEventsRawEndpoint(this);
            Groups = new MeetupGroupsRawEndpoint(this);
        }

    }

}