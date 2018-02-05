using System;
using Skybrud.Social.Meetup.Endpoints;
using Skybrud.Social.Meetup.OAuth;

namespace Skybrud.Social.Meetup {
    
    public class MeetupService {

        #region Properties

        public IMeetupOAuthClient Client { get; }

        public MeetupEventsEndpoint Events { get; }

        public MeetupGroupsEndpoint Groups { get; }

        #endregion

        #region Constructors

        public MeetupService() : this(new MeetupOAuth2Client()) { }

        private MeetupService(IMeetupOAuthClient client) {
            Client = client;
            Events = new MeetupEventsEndpoint(this);
            Groups = new MeetupGroupsEndpoint(this);
        }

        #endregion

        #region Static methods
        
        /// <summary>
        /// Initializes a new service based on the specified <strong>OAuth 1.0a</strong> client.
        /// </summary>
        /// <param name="client">The OAuth client to use.</param>
        public static MeetupService CreateFromOAuthClient(MeetupOAuthClient client) {
            if (client == null) throw new ArgumentNullException(nameof(client));
            return new MeetupService(client);
        }

        /// <summary>
        /// Initializes a new service based on the specified <strong>OAuth 2.0</strong> client.
        /// </summary>
        /// <param name="client">The OAuth client to use.</param>
        public static MeetupService CreateFromOAuthClient(MeetupOAuth2Client client) {
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