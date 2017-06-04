using Skybrud.Social.Http;
using Skybrud.Social.Meetup.Models.Groups;

namespace Skybrud.Social.Meetup.Responses.Groups {

    /// <summary>
    /// Class representing a response of a call to get information about a <see cref="MeetupGroup"/>.
    /// </summary>
    public class MeetupGetGroupResponse : MeetupResponse<MeetupGroup> {

        #region Constructors

        private MeetupGetGroupResponse(SocialHttpResponse response) : base(response) {

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
        /// <param name="response">The instance of <see cref="SocialHttpResponse"/> representing the raw response.</param>
        /// <returns>An instance of <see cref="MeetupGetGroupResponse"/> representing the response.</returns>
        public static MeetupGetGroupResponse ParseResponse(SocialHttpResponse response) {
            return response == null ? null : new MeetupGetGroupResponse(response);
        }

        #endregion

    }

}