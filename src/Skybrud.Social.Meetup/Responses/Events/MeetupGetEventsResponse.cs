using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.Meetup.Models.Events;

namespace Skybrud.Social.Meetup.Responses.Events {

    /// <summary>
    /// Class representing a response of a call to get a list of <see cref="MeetupEvent"/>.
    /// </summary>
    public class MeetupGetEventsResponse : MeetupResponse<MeetupEvent[]> {

        #region Constructors

        private MeetupGetEventsResponse(IHttpResponse response) : base(response) {
            Body = ParseJsonArray(response.Body, MeetupEvent.Parse);
        }

        #endregion

        #region Static methods
        
        /// <summary>
        /// Parses the specified <paramref name="response"/> into an instance of <see cref="MeetupGetEventsResponse"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="IHttpResponse"/> representing the raw response.</param>
        /// <returns>An instance of <see cref="MeetupGetEventsResponse"/> representing the response.</returns>
        public static MeetupGetEventsResponse ParseResponse(IHttpResponse response) {
            if (response == null) throw new ArgumentNullException(nameof(response));
            return new MeetupGetEventsResponse(response);
        }

        #endregion

    }

}