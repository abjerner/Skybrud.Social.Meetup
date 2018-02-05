using System;
using Skybrud.Social.Http;
using Skybrud.Social.Meetup.OAuth;

namespace Skybrud.Social.Meetup.Endpoints.Raw {
    
    public class MeetupGroupsRawEndpoint {

        #region Properties

        public IMeetupOAuthClient Client { get; set; }

        #endregion

        #region Constructors

        public MeetupGroupsRawEndpoint(IMeetupOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets information about the group with the specified <paramref name="urlname"/>.
        /// </summary>
        /// <param name="urlname">The URL name/slug of the group.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        public SocialHttpResponse GetGroup(string urlname) {
            if (String.IsNullOrWhiteSpace(urlname)) throw new ArgumentNullException(nameof(urlname));
            return Client.DoHttpGetRequest("https://api.meetup.com/" + urlname);
        }

        public SocialHttpResponse GetUserGroups() {
            return Client.DoHttpGetRequest("https://api.meetup.com/self/groups");
        }

        #endregion

    }

}