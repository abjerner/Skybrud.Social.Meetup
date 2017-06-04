using Skybrud.Social.Meetup.Endpoints;

namespace Skybrud.Social.Meetup {
    
    public class MeetupService {

        #region Properties

        public MeetupClient Client { get; set; }

        public MeetupEventsEndpoint Events { get; private set; }

        public MeetupGroupsEndpoint Groups { get; private set; }

        #endregion

        #region Constructors

        public MeetupService() {
            Client = new MeetupClient();
            Events = new MeetupEventsEndpoint(this);
            Groups = new MeetupGroupsEndpoint(this);
        }

        #endregion

    }

}