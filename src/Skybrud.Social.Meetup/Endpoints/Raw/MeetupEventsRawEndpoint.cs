using System;
using Skybrud.Social.Http;

namespace Skybrud.Social.Meetup.Endpoints.Raw {
    
    public class MeetupEventsRawEndpoint {

        public MeetupClient Client { get; set; }

        public MeetupEventsRawEndpoint(MeetupClient client) {
            Client = client;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="urlname">The URL name of the parent group.</param>
        /// <param name="eventId">The ID of the event.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        /// <see cref="https://www.meetup.com/meetup_api/docs/:urlname/events/:id/#get"/>
        public SocialHttpResponse GetEvent(string urlname, string eventId) {
            if (String.IsNullOrWhiteSpace(urlname)) throw new ArgumentNullException("urlname");
            if (String.IsNullOrWhiteSpace(eventId)) throw new ArgumentNullException("eventId");
            return Client.DoHttpGetRequest("https://api.meetup.com/" + urlname + "/events/" + eventId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="urlname">The URL name/slug of the parent group.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://www.meetup.com/meetup_api/docs/:urlname/events/#listparams</cref>
        ///     <cref>https://www.meetup.com/meetup_api/docs/:urlname/events/#listresponse</cref>
        /// </see>
        public SocialHttpResponse GetEvents(string urlname) {
            if (String.IsNullOrWhiteSpace(urlname)) throw new ArgumentNullException("urlname");
            return Client.DoHttpGetRequest("https://api.meetup.com/" + urlname + "/events");
        }

    }

}