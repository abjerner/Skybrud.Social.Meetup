using System;
using Skybrud.Social.Meetup.Endpoints;
using Skybrud.Social.Meetup.OAuth;

namespace Skybrud.Social.Meetup {

    /// <summary>
    /// Class working as an entry point to the Meetup API.
    /// </summary>
    /// <example>
    /// Initializing a new instance for public API access (no authentication):
    /// <code>
    /// MeetupService meetup = new MeetupService();
    /// </code>
    /// </example>
    /// <example>
    /// If you already have an OAuth 2.0 access token you wish to use for authentication, you can instead use the
    /// static <see cref="CreateFromAccessToken"/> method.
    /// <code>
    /// MeetupService meetup1 = MeetupService.CreateFromAccessToken("your access token");
    /// </code>
    /// </example>
    public class MeetupHttpService {

        #region Properties

        /// <summary>
        /// Gets a reference to the internal OAuth client for communication with the Meetup API.
        /// </summary>
        public MeetupOAuthClient Client { get; }

        /// <summary>
        /// Gets a reference to the raw <strong>Events</strong> endpoint.
        /// </summary>
        public MeetupEventsEndpoint Events { get; }

        /// <summary>
        /// Gets a reference to the raw <strong>Groups</strong> endpoint.
        /// </summary>
        public MeetupGroupsEndpoint Groups { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance with default settings.
        /// </summary>
        public MeetupHttpService() : this(new MeetupOAuthClient()) { }

        private MeetupHttpService(MeetupOAuthClient client) {
            Client = client;
            Events = new MeetupEventsEndpoint(this);
            Groups = new MeetupGroupsEndpoint(this);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Initializes a new instance for public access to the Meetup.com API.
        /// </summary>
        /// <returns>A new instance of <see cref="MeetupHttpService"/>.</returns>
        public static MeetupHttpService Create() {
            return new MeetupHttpService();
        }

        /// <summary>
        /// Initializes a new service based on the specified <paramref name="client"/>.
        /// </summary>
        /// <param name="client">The OAuth client to use.</param>
        /// <returns>A new instance of <see cref="MeetupHttpService"/>.</returns>
        public static MeetupHttpService CreateFromOAuthClient(MeetupOAuthClient client) {
            if (client == null) throw new ArgumentNullException(nameof(client));
            return new MeetupHttpService(client);
        }

        /// <summary>
        /// Initializes a new service based on the specified <strong>OAuth 2.0</strong> <paramref name="accessToken"/>.
        /// </summary>
        /// <param name="accessToken">The <strong>OAuth 2.0</strong> access token.</param>
        /// <returns>A new instance of <see cref="MeetupHttpService"/>.</returns>
        public static MeetupHttpService CreateFromAccessToken(string accessToken) {
            if (string.IsNullOrWhiteSpace(accessToken)) throw new ArgumentNullException(nameof(accessToken));
            return new MeetupHttpService(new MeetupOAuthClient { AccessToken = accessToken });
        }

        #endregion

    }

}