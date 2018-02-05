using Skybrud.Social.Http;
using Skybrud.Social.Interfaces.Http;

namespace Skybrud.Social.Meetup.Exceptions {

    public class MeetupOAuthException : MeetupHttpException {

        #region Properties

        public string Problem { get; }

        #endregion

        #region Constructors

        public MeetupOAuthException(SocialHttpResponse response) : base(response) {

            if (response.ContentType.StartsWith("application/x-www-form-urlencoded")) {
                IHttpQueryString query = SocialHttpQueryString.ParseQueryString(response.Body);
                Problem = query["oauth_problem"];
            }

        }

        #endregion

    }

}