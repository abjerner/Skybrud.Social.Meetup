using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.Meetup.Models.Groups;

namespace Skybrud.Social.Meetup.Responses.Groups {

    /// <summary>
    /// Class representing a response of a call to get information about a <see cref="MeetupGroup"/>.
    /// </summary>
    public class MeetupGetGroupResponse : MeetupResponse<MeetupGroup> {

        #region Constructors

        private MeetupGetGroupResponse(IHttpResponse response) : base(response) {

            // Validate the response
            ValidateResponse(response);

            // Parse the response body
            Body = ParseJsonObject(response.Body, MeetupGroup.Parse);

        }

        #endregion

        #region Static methods
        
        /// <summary>
        /// Parses the specified <paramref name="response"/> into an instance of <see cref="MeetupGetGroupResponse"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="IHttpResponse"/> representing the raw response.</param>
        /// <returns>An instance of <see cref="MeetupGetGroupResponse"/> representing the response.</returns>
        public static MeetupGetGroupResponse ParseResponse(IHttpResponse response) {
            if (response == null) throw new ArgumentNullException(nameof(response));
            return new MeetupGetGroupResponse(response);
        }

        #endregion

    }

}