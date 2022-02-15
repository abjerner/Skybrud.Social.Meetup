using Skybrud.Essentials.Http;
using Skybrud.Social.Meetup.OAuth;

namespace Skybrud.Social.Meetup.Endpoints.Raw {

    /// <summary>
    /// Class representing the raw implementation of the <strong>Members</strong> endpoint.
    /// </summary>
    public class MeetupMembersRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the OAuth client.
        /// </summary>
        public MeetupOAuthClient Client { get; }

        #endregion

        #region Constructors

        internal MeetupMembersRawEndpoint(MeetupOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets information about the authenticated member/user.
        /// </summary>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://www.meetup.com/meetup_api/docs/2/member/#get</cref>
        /// </see>
        public IHttpResponse GetMember() {
            return Client.Get("https://api.meetup.com/members/self");
        }

        /// <summary>
        /// Gets information about the member with the specified <paramref name="memberId"/>.
        /// </summary>
        /// <param name="memberId">The ID of the member.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://www.meetup.com/meetup_api/docs/2/member/#get</cref>
        /// </see>
        public IHttpResponse GetMember(int memberId) {
            return Client.Get("https://api.meetup.com/members/" + memberId);
        }

        #endregion

    }

}