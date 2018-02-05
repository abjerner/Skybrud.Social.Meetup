using System;
using Skybrud.Social.Http;

namespace Skybrud.Social.Meetup.Exceptions {

    /// <summary>
    /// Class representing an exception/error returned by the Meetup API.
    /// </summary>
    public class MeetupHttpException : Exception {

        #region Properties

        /// <summary>
        /// Gets a reference to the underlying <see cref="SocialHttpResponse"/>.
        /// </summary>
        public SocialHttpResponse Response { get; private set; }

        #endregion

        #region Constructors

        public MeetupHttpException(SocialHttpResponse response) : base("Invalid response received from the Meetup API (Status: " + (int) response.StatusCode + ")") {
            Response = response;
        }

        #endregion

    }

}