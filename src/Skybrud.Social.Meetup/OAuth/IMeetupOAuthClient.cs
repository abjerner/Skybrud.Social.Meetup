using Skybrud.Essentials.Http.Client;
using Skybrud.Social.Meetup.Endpoints.Raw;

namespace Skybrud.Social.Meetup.OAuth {

    /// <summary>
    /// Interface descriting a HTTP client used for communication with the Meetup API. Native implementations within
    /// <strong>Skybrud.Social.Meetup</strong> are <see cref="MeetupOAuthClient"/> for OAuth 1.0a and
    /// <see cref="MeetupOAuth2Client"/> for OAuth 2.0 respectively.
    /// </summary>
    public interface IMeetupOAuthClient : IHttpClient {

        /// <summary>
        /// Gets a reference to the raw <strong>Events</strong> endpoint.
        /// </summary>
        MeetupEventsRawEndpoint Events { get; }

        /// <summary>
        /// Gets a reference to the raw <strong>Groups</strong> endpoint.
        /// </summary>
        MeetupGroupsRawEndpoint Groups { get; }

        /// <summary>
        /// Gets a reference to the raw <strong>Members</strong> endpoint.
        /// </summary>
        MeetupMembersRawEndpoint Members { get; }

    }

}