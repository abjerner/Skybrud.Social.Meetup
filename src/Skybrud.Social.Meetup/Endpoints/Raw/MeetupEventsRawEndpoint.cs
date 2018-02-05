using System;
using Skybrud.Social.Http;
using Skybrud.Social.Meetup.OAuth;

namespace Skybrud.Social.Meetup.Endpoints.Raw {
    
    public class MeetupEventsRawEndpoint {

        #region Properties

        public IMeetupOAuthClient Client { get; set; }

        #endregion

        #region Constructors

        public MeetupEventsRawEndpoint(IMeetupOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets information about the event matching the specified group <paramref name="urlname"/> and <paramref name="eventId"/>.
        /// </summary>
        /// <param name="urlname">The URL name of the parent group.</param>
        /// <param name="eventId">The ID of the event.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://www.meetup.com/meetup_api/docs/:urlname/events/:id/#get</cref>
        /// </see>
        public SocialHttpResponse GetEvent(string urlname, string eventId) {
            if (String.IsNullOrWhiteSpace(urlname)) throw new ArgumentNullException(nameof(urlname));
            if (String.IsNullOrWhiteSpace(eventId)) throw new ArgumentNullException(nameof(eventId));
            return Client.DoHttpGetRequest("https://api.meetup.com/" + urlname + "/events/" + eventId);
        }

        /// <summary>
        /// Gets a list of events of the group with the specified <paramref name="urlname"/>.
        /// </summary>
        /// <param name="urlname">The URL name/slug of the parent group.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://www.meetup.com/meetup_api/docs/:urlname/events/#listparams</cref>
        ///     <cref>https://www.meetup.com/meetup_api/docs/:urlname/events/#listresponse</cref>
        /// </see>
        public SocialHttpResponse GetEvents(string urlname) {
            if (String.IsNullOrWhiteSpace(urlname)) throw new ArgumentNullException(nameof(urlname));
            return Client.DoHttpGetRequest("https://api.meetup.com/" + urlname + "/events");
        }

        #endregion

    }

}