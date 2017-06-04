using Skybrud.Social.Meetup.Endpoints.Raw;
using Skybrud.Social.Meetup.Responses.Groups;

namespace Skybrud.Social.Meetup.Endpoints {

    public class MeetupGroupsEndpoint {

        public MeetupService Service { get; set; }

        public MeetupGroupsRawEndpoint Raw {
            get { return Service.Client.Groups; }
        }

        public MeetupGroupsEndpoint(MeetupService service) {
            Service = service;
        }

        public MeetupGetGroupResponse GetGroup(string urlname) {
            return MeetupGetGroupResponse.ParseResponse(Raw.GetGroup(urlname));
        }

    }

}