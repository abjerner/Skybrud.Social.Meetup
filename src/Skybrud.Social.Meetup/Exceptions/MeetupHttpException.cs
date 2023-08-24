using System;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Meetup.Exceptions {

    /// <summary>
    /// Class representing an exception/error returned by the Meetup API.
    /// </summary>
    public class MeetupHttpException : Exception {

        #region Properties

        /// <summary>
        /// Gets a reference to the underlying <see cref="IHttpResponse"/>.
        /// </summary>
        public IHttpResponse Response { get; }

        /// <summary>
        /// Gets the details of the error, or <c>null</c> if not present.
        /// </summary>
        public string? Details { get; protected set; }

        /// <summary>
        /// Gets the code of the error, or <c>null</c> if not present.
        /// </summary>
        public string? Code { get; protected set; }

        /// <summary>
        /// Gets the problem of the error, or <c>null</c> if not present.
        /// </summary>
        public string? Problem { get; protected set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new exception based on the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="IHttpResponse"/> representing the raw response.</param>
        public MeetupHttpException(IHttpResponse response) : base("Invalid response received from the Meetup API (Status: " + (int) response.StatusCode + ")") {

            Response = response;

            switch (response.ContentType.Split(';')[0]) {

                case "application/json":

                    if (response.Body.StartsWith("{")) {
                        JObject obj = JObject.Parse(response.Body);
                        Details = obj.GetString("details");
                        Code = obj.GetString("code");
                        Problem = obj.GetString("problem") ?? obj.GetString("message");
                    }

                    break;

            }

        }

        #endregion

    }

}