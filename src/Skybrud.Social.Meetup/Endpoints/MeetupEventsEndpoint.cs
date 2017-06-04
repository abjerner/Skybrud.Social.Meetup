using Skybrud.Social.Meetup.Endpoints.Raw;
using Skybrud.Social.Meetup.Responses.Events;

namespace Skybrud.Social.Meetup.Endpoints {

    public class MeetupEventsEndpoint {

        public MeetupService Service { get; set; }

        public MeetupEventsRawEndpoint Raw {
            get { return Service.Client.Events; }
        }

        public MeetupEventsEndpoint(MeetupService service) {
            Service = service;
        }

        public MeetupGetEventResponse GetEvent(string urlname, string eventId) {
            return MeetupGetEventResponse.ParseResponse(Raw.GetEvent(urlname, eventId));
        }

        public MeetupGetEventsResponse GetEvents(string urlname) {
            return MeetupGetEventsResponse.ParseResponse(Raw.GetEvents(urlname));
        }

    }

}