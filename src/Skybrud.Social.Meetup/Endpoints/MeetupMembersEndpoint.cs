using Skybrud.Social.Meetup.Endpoints.Raw;
using Skybrud.Social.Meetup.Responses.Groups;
using Skybrud.Social.Meetup.Responses.Members;

namespace Skybrud.Social.Meetup.Endpoints {

    /// <summary>
    /// Implementation of the <strong>Members</strong> endpoint.
    /// </summary>
    public class MeetupMembersEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the parent service.
        /// </summary>
        public MeetupService Service { get; set; }

        /// <summary>
        /// Gets a reference to the raw endpoint.
        /// </summary>
        public MeetupMembersRawEndpoint Raw => Service.Client.Members;

        #endregion

        #region Constructors

        internal MeetupMembersEndpoint(MeetupService service) {
            Service = service;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets information about the authenticated member/user.
        /// </summary>
        /// <returns>An instance of <see cref="MeetupGetMemberResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://www.meetup.com/meetup_api/docs/2/member/#get</cref>
        /// </see>
        public MeetupGetMemberResponse GetMember() {
            return MeetupGetMemberResponse.ParseResponse(Raw.GetMember());
        }

        /// <summary>
        /// Gets information about the member with the specified <paramref name="memberId"/>.
        /// </summary>
        /// <param name="memberId">The ID of the member.</param>
        /// <returns>An instance of <see cref="MeetupGetMemberResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://www.meetup.com/meetup_api/docs/2/member/#get</cref>
        /// </see>
        public MeetupGetMemberResponse GetMember(int memberId) {
            return MeetupGetMemberResponse.ParseResponse(Raw.GetMember(memberId));
        }

        #endregion

    }

}