using System.Collections.Generic;
using Skybrud.Essentials.Http;
using Skybrud.Social.Meetup.OAuth;
using Skybrud.Social.Meetup.Options.GraphQl;

namespace Skybrud.Social.Meetup.Endpoints {

    /// <summary>
    /// Class representing the raw implementation of the <strong>GraphQL</strong> endpoint.
    /// </summary>
    public class MeetupGraphQlRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the OAuth client.
        /// </summary>
        public MeetupOAuthClient Client { get; }

        #endregion

        #region Constructors

        internal MeetupGraphQlRawEndpoint(MeetupOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Returns information about the group matching the specified <paramref name="query"/>.
        /// </summary>
        /// <param name="query">The GraphQL query.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the response from the API.</returns>
        public IHttpResponse GetGroupByUrlname(string query) {
            return GetGroupByUrlname(new MeetupGraphQlOptions(query));
        }

        /// <summary>
        /// Returns information about the group matching the specified <paramref name="query"/>.
        /// </summary>
        /// <param name="query">The GraphQL query.</param>
        /// <param name="variables">A dictionary with variable to be used with the query.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the response from the API.</returns>
        public IHttpResponse GetGroupByUrlname(string query, Dictionary<string, string>? variables) {
            return GetGroupByUrlname(new MeetupGraphQlOptions(query, variables));
        }

        /// <summary>
        /// Returns a group matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the response from the API.</returns>
        public IHttpResponse GetGroupByUrlname(MeetupGraphQlOptions options) {
            return Client.GetResponse(options);
        }

        #endregion

    }

}