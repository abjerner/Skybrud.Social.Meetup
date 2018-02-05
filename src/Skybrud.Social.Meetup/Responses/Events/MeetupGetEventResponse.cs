using System;
using Skybrud.Social.Http;
using Skybrud.Social.Meetup.Models.Events;

namespace Skybrud.Social.Meetup.Responses.Events {

    /// <summary>
    /// Class representing a response of a call to get information about a <see cref="MeetupEvent"/>.
    /// </summary>
    public class MeetupGetEventResponse : MeetupResponse<MeetupEvent> {

        #region Constructors

        private MeetupGetEventResponse(SocialHttpResponse response) : base(response) {

            // Validate the response
            ValidateResponse(response);

            // Parse the response body
            Body = ParseJsonObject(response.Body, MeetupEvent.Parse);

        }

        #endregion

        #region Static methods
        
        /// <summary>
        /// Parses the specified <paramref name="response"/> into an instance of <see cref="MeetupGetEventResponse"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="SocialHttpResponse"/> representing the raw response.</param>
        /// <returns>An instance of <see cref="MeetupGetEventResponse"/> representing the response.</returns>
        public static MeetupGetEventResponse ParseResponse(SocialHttpResponse response) {
            if (response == null) throw new ArgumentNullException(nameof(response));
            return new MeetupGetEventResponse(response);
        }

        #endregion

    }

}