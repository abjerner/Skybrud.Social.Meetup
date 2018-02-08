using Skybrud.Social.Meetup.Models.Authentication;
using Skybrud.Social.Http;

namespace Skybrud.Social.Meetup.Responses.Authentication {

    /// <summary>
    /// Class representing a response with information about an access token.
    /// </summary>
    public class MeetupTokenResponse : MeetupResponse<MeetupToken> {

        #region Properties
        

        #endregion

        #region Constructors

        private MeetupTokenResponse(SocialHttpResponse response) : base(response) {

            // Validate the response
            ValidateResponse(response);

            // Parse the response body
            Body = ParseJsonObject(response.Body, MeetupToken.Parse);

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="response"/> into an instance of <see cref="MeetupTokenResponse"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="SocialHttpResponse"/> representing the raw response.</param>
        /// <returns>An instance of <see cref="MeetupTokenResponse"/> representing the response.</returns>
        public static MeetupTokenResponse ParseResponse(SocialHttpResponse response) {
            return response == null ? null : new MeetupTokenResponse(response);
        }

        #endregion

    }

}