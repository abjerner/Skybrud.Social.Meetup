using System;
using Skybrud.Social.Http;
using Skybrud.Social.Meetup.Models.Members;

namespace Skybrud.Social.Meetup.Responses.Members {

    /// <summary>
    /// Class representing a response of a call to get information about a <see cref="MeetupMember"/>.
    /// </summary>
    public class MeetupGetMemberResponse : MeetupResponse<MeetupMember> {

        #region Constructors

        private MeetupGetMemberResponse(SocialHttpResponse response) : base(response) {

            // Validate the response
            ValidateResponse(response);

            // Parse the response body
            Body = ParseJsonObject(response.Body, MeetupMember.Parse);

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="response"/> into an instance of <see cref="MeetupGetMemberResponse"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="SocialHttpResponse"/> representing the raw response.</param>
        /// <returns>An instance of <see cref="MeetupGetMemberResponse"/> representing the response.</returns>
        public static MeetupGetMemberResponse ParseResponse(SocialHttpResponse response) {
            if (response == null) throw new ArgumentNullException(nameof(response));
            return new MeetupGetMemberResponse(response);
        }

        #endregion

    }

}