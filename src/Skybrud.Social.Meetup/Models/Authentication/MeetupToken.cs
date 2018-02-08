using System;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Meetup.Models.Authentication {
    
    /// <summary>
    /// Class describing an access token received from the Meetup API.
    /// </summary>
    public class MeetupToken : MeetupObject {

        #region Properties

        public string AccessToken { get; private set; }

        public string RefreshToken { get; private set; }

        public string TokenType { get; private set; }

        public TimeSpan ExpiresIn { get; private set; }

        #endregion

        #region Constructors

        private MeetupToken(JObject obj) : base(obj) {
            AccessToken = obj.GetString("access_token");
            RefreshToken = obj.GetString("refresh_token");
            TokenType = obj.GetString("token_type");
            ExpiresIn = obj.GetDouble("expires_in", TimeSpan.FromSeconds);
        }

        #endregion

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="MeetupToken"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="MeetupToken"/>.</returns>
        public static MeetupToken Parse(JObject obj) {
            return obj == null ? null : new MeetupToken(obj);
        }

    }

}