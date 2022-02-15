using Skybrud.Social.Meetup.Models.Authentication;
using Skybrud.Essentials.Http;

namespace Skybrud.Social.Meetup.Responses.Authentication {

    /// <summary>
    /// Class representing a response with information about an access token.
    /// </summary>
    public class MeetupTokenResponse : MeetupResponse<MeetupToken> {

        #region Constructors

        private MeetupTokenResponse(IHttpResponse response) : base(response) {
            Body = ParseJsonObject(response.Body, MeetupToken.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="response"/> into an instance of <see cref="MeetupTokenResponse"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="IHttpResponse"/> representing the raw response.</param>
        /// <returns>An instance of <see cref="MeetupTokenResponse"/> representing the response.</returns>
        public static MeetupTokenResponse ParseResponse(IHttpResponse response) {
            return response == null ? null : new MeetupTokenResponse(response);
        }

        #endregion

    }

}