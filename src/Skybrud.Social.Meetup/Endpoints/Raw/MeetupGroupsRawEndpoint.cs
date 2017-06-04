using System;
using Skybrud.Social.Http;

namespace Skybrud.Social.Meetup.Endpoints.Raw {
    
    public class MeetupGroupsRawEndpoint {

        public MeetupClient Client { get; set; }

        public MeetupGroupsRawEndpoint(MeetupClient client) {
            Client = client;
        }

        public SocialHttpResponse GetGroup(string urlname) {
            if (String.IsNullOrWhiteSpace(urlname)) throw new ArgumentNullException("urlname");
            return Client.DoHttpGetRequest("https://api.meetup.com/" + urlname);
        }

        public SocialHttpResponse GetUserGroups() {
            return Client.DoHttpGetRequest("https://api.meetup.com/self/groups");
        }

    }

}