using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.Meetup.OAuth;

namespace Skybrud.Social.Meetup.Endpoints.Raw {

    /// <summary>
    /// Class representing the raw implementation of the <strong>Groups</strong> endpoint.
    /// </summary>
    public class MeetupGroupsRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the OAuth client.
        /// </summary>
        public IMeetupOAuthClient Client { get; }

        #endregion

        #region Constructors

        internal MeetupGroupsRawEndpoint(IMeetupOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets information about the group with the specified <paramref name="urlname"/>.
        /// </summary>
        /// <param name="urlname">The URL name/slug of the group.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://www.meetup.com/meetup_api/docs/:urlname/#get</cref>
        /// </see>
        public IHttpResponse GetGroup(string urlname) {
            if (string.IsNullOrWhiteSpace(urlname)) throw new ArgumentNullException(nameof(urlname));
            return Client.DoHttpGetRequest($"/{urlname}");
        }

        /// <summary>
        /// Gets a list of the groups of the authenticated user.
        /// </summary>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://www.meetup.com/meetup_api/docs/self/groups/</cref>
        /// </see>
        public IHttpResponse GetUserGroups() {
            return Client.DoHttpGetRequest("/self/groups");
        }

        #endregion

    }

}