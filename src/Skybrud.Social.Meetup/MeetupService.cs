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
    /// static <see cref="CreateFromAccessToken"/> method. Alternatively, if you have an API key instead, you can use
    /// the <see cref="CreateFromApiKey"/> instead:
    /// <code>
    /// MeetupService meetup1 = MeetupService.CreateFromAccessToken("your access token");
    /// 
    /// MeetupService meetup2 = MeetupService.CreateFromAccessToken("your API key");
    /// </code>
    /// </example>
    /// <example>
    /// If you wish to use OAuth 1.0a, you can configure an instance of <see cref="MeetupOAuthClient"/>, and then pass
    /// it along to the <see cref="CreateFromOAuthClient"/> method:
    /// 
    /// <code>
    /// MeetupOAuthClient client = new MeetupOAuthClient("Your consumer key", "Your consumer key", "The access token of the user", "The access token secret of the user");
    /// 
    /// MeetupService meetup = MeetupService.GetFromOAuthClient(client);
    /// </code>
    /// </example>
    public class MeetupService {

        #region Properties

        /// <summary>
        /// Gets a reference to the internal OAuth client for communication with the Meetup API.
        /// </summary>
        public IMeetupOAuthClient Client { get; }

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
        public MeetupService() : this(new MeetupOAuth2Client()) { }

        private MeetupService(IMeetupOAuthClient client) {
            Client = client;
            Events = new MeetupEventsEndpoint(this);
            Groups = new MeetupGroupsEndpoint(this);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Initializes a new service based on the specified <paramref name="client"/>.
        /// </summary>
        /// <param name="client">The OAuth client to use.</param>
        public static MeetupService CreateFromOAuthClient(IMeetupOAuthClient client) {
            if (client == null) throw new ArgumentNullException(nameof(client));
            return new MeetupService(client);
        }

        /// <summary>
        /// Initializes a new service based on the specified <strong>OAuth 2.0</strong> <paramref name="accessToken"/>.
        /// </summary>
        /// <param name="accessToken">The <strong>OAuth 2.0</strong> access token.</param>
        public static MeetupService CreateFromAccessToken(string accessToken) {
            if (String.IsNullOrWhiteSpace(accessToken)) throw new ArgumentNullException(nameof(accessToken));
            return new MeetupService(new MeetupOAuth2Client { AccessToken = accessToken });
        }

        /// <summary>
        /// Initializes a new service based on the specified <paramref name="apiKey"/>.
        /// </summary>
        /// <param name="apiKey">The API key.</param>
        public static MeetupService CreateFromApiKey(string apiKey) {
            if (String.IsNullOrWhiteSpace(apiKey)) throw new ArgumentNullException(nameof(apiKey));
            return new MeetupService(new MeetupOAuth2Client { ApiKey = apiKey });
        }

        #endregion

    }

}