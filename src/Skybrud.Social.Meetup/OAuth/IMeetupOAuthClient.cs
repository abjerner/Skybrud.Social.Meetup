using Skybrud.Social.Interfaces.Http;
using Skybrud.Social.Meetup.Endpoints.Raw;

namespace Skybrud.Social.Meetup.OAuth {

    public interface IMeetupOAuthClient : IHttpClient {

        MeetupEventsRawEndpoint Events { get; }

        MeetupGroupsRawEndpoint Groups { get; }

    }

}