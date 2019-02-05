using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Collections;

namespace Skybrud.Social.Meetup.Exceptions {

    /// <summary>
    /// Class representing an OAUth related exception/error returned by the Meetup API.
    /// </summary>
    public class MeetupOAuthException : MeetupHttpException {

        #region Constructors

        /// <summary>
        /// Initializes a new exception based on the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="IHttpResponse"/> representing the raw response.</param>
        public MeetupOAuthException(IHttpResponse response) : base(response) {

            if (response.ContentType.StartsWith("application/x-www-form-urlencoded")) {
                IHttpQueryString query = HttpQueryString.ParseQueryString(response.Body);
                Problem = query["oauth_problem"];
            }

        }

        #endregion

    }

}