using Skybrud.Social.Meetup.Endpoints;

namespace Skybrud.Social.Meetup {
    
    public class MeetupService {

        public MeetupClient Client { get; set; }

        public MeetupEventsEndpoint Events { get; private set; }

        public MeetupGroupsEndpoint Groups { get; private set; }

        public MeetupService() {
            Client = new MeetupClient();
            Events = new MeetupEventsEndpoint(this);
            Groups = new MeetupGroupsEndpoint(this);
        }

    }

}