using Skybrud.Social.Http;
using Skybrud.Social.Interfaces.Http;

namespace Skybrud.Social.Meetup.Exceptions {

    /// <summary>
    /// Class representing an OAUth related exception/error returned by the Meetup API.
    /// </summary>
    public class MeetupOAuthException : MeetupHttpException {

        #region Constructors

        /// <summary>
        /// Initializes a new exception based on the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="SocialHttpResponse"/> representing the raw response.</param>
        public MeetupOAuthException(SocialHttpResponse response) : base(response) {

            if (response.ContentType.StartsWith("application/x-www-form-urlencoded")) {
                IHttpQueryString query = SocialHttpQueryString.ParseQueryString(response.Body);
                Problem = query["oauth_problem"];
            }

        }

        #endregion

    }

}