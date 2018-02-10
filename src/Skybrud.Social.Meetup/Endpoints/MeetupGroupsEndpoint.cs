using Skybrud.Social.Meetup.Endpoints.Raw;
using Skybrud.Social.Meetup.Responses.Groups;

namespace Skybrud.Social.Meetup.Endpoints {

    /// <summary>
    /// Implementation of the <strong>Groups</strong> endpoint.
    /// </summary>
    public class MeetupGroupsEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the parent service.
        /// </summary>
        public MeetupService Service { get; set; }

        /// <summary>
        /// Gets a reference to the raw endpoint.
        /// </summary>
        public MeetupGroupsRawEndpoint Raw => Service.Client.Groups;

        #endregion

        #region Constructors

        internal MeetupGroupsEndpoint(MeetupService service) {
            Service = service;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets information about the group with the specified <paramref name="urlname"/>.
        /// </summary>
        /// <param name="urlname">The URL name/slug of the group.</param>
        /// <returns>An instance of <see cref="MeetupGetGroupResponse"/> representing the response.</returns>
        public MeetupGetGroupResponse GetGroup(string urlname) {
            return MeetupGetGroupResponse.ParseResponse(Raw.GetGroup(urlname));
        }

        #endregion

    }

}