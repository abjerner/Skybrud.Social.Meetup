using Skybrud.Social.Meetup.Endpoints.Raw;
using Skybrud.Social.Meetup.Options.Events;
using Skybrud.Social.Meetup.Responses.Events;

namespace Skybrud.Social.Meetup.Endpoints; 

/// <summary>
/// Implementation of the <strong>Events</strong> endpoint.
/// </summary>
public class MeetupEventsEndpoint {

    #region Properties

    /// <summary>
    /// Gets a reference to the parent service.
    /// </summary>
    public MeetupHttpService Service { get; }

    /// <summary>
    /// Gets a reference to the raw endpoint.
    /// </summary>
    public MeetupEventsRawEndpoint Raw => Service.Client.Events;

    #endregion

    #region Constructors

    internal MeetupEventsEndpoint(MeetupHttpService service) {
        Service = service;
    }

    #endregion

    #region Member methods

    /// <summary>
    /// Gets information about the event matching the specified group <paramref name="urlname"/> and <paramref name="eventId"/>.
    /// </summary>
    /// <param name="urlname">The URL name/slug of the parent group.</param>
    /// <param name="eventId">The ID of the event.</param>
    /// <returns>An instance of <see cref="MeetupGetEventResponse"/> representing the response.</returns>
    public MeetupGetEventResponse GetEvent(string urlname, string eventId) {
        return MeetupGetEventResponse.ParseResponse(Raw.GetEvent(urlname, eventId));
    }

    /// <summary>
    /// Gets a list of events of the group with the specified <paramref name="urlname"/>.
    /// </summary>
    /// <param name="urlname">The URL name/slug of the group.</param>
    /// <returns>An instance of <see cref="MeetupGetEventsResponse"/> representing the response.</returns>
    public MeetupGetEventsResponse GetEvents(string urlname) {
        return MeetupGetEventsResponse.ParseResponse(Raw.GetEvents(urlname));
    }

    /// <summary>
    /// Gets a list of events of the group matching the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="MeetupGetEventsResponse"/> representing the response.</returns>
    public MeetupGetEventsResponse GetEvents(MeetupGetEventsOptions options) {
        return MeetupGetEventsResponse.ParseResponse(Raw.GetEvents(options));
    }

    #endregion

}