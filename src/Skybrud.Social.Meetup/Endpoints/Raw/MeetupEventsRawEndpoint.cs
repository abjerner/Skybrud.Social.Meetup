﻿using System;
using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Social.Meetup.OAuth;
using Skybrud.Social.Meetup.Options.Events;

#pragma warning disable CS0618

namespace Skybrud.Social.Meetup.Endpoints.Raw; 

/// <summary>
/// Class representing the raw implementation of the <strong>Events</strong> endpoint.
/// </summary>
public class MeetupEventsRawEndpoint {

    #region Properties

    /// <summary>
    /// Gets a reference to the OAuth client.
    /// </summary>
    public MeetupOAuthClient Client { get; }

    #endregion

    #region Constructors

    internal MeetupEventsRawEndpoint(MeetupOAuthClient client) {
        Client = client;
    }

    #endregion

    #region Member methods

    /// <summary>
    /// Gets information about the event matching the specified group <paramref name="urlname"/> and <paramref name="eventId"/>.
    /// </summary>
    /// <param name="urlname">The URL name of the parent group.</param>
    /// <param name="eventId">The ID of the event.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    /// <see>
    ///     <cref>https://www.meetup.com/meetup_api/docs/:urlname/events/:id/#get</cref>
    /// </see>
    public IHttpResponse GetEvent(string urlname, string eventId) {
        if (string.IsNullOrWhiteSpace(urlname)) throw new ArgumentNullException(nameof(urlname));
        if (string.IsNullOrWhiteSpace(eventId)) throw new ArgumentNullException(nameof(eventId));
        return Client.Get($"/{urlname}/events/{eventId}");
    }

    /// <summary>
    /// Gets a list of events of the group with the specified <paramref name="urlname"/>.
    /// </summary>
    /// <param name="urlname">The URL name/slug of the parent group.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    /// <see>
    ///     <cref>https://www.meetup.com/meetup_api/docs/:urlname/events/#listparams</cref>
    ///     <cref>https://www.meetup.com/meetup_api/docs/:urlname/events/#listresponse</cref>
    /// </see>
    public IHttpResponse GetEvents(string urlname) {
        if (string.IsNullOrWhiteSpace(urlname)) throw new ArgumentNullException(nameof(urlname));
        return Client.Get($"/{urlname}/events");
    }
        
    /// <summary>
    /// Gets a list of events of the group matching the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    /// <see>
    ///     <cref>https://www.meetup.com/meetup_api/docs/:urlname/events/#listparams</cref>
    ///     <cref>https://www.meetup.com/meetup_api/docs/:urlname/events/#listresponse</cref>
    /// </see>
    public IHttpResponse GetEvents(MeetupGetEventsOptions options) {
        if (options == null) throw new ArgumentNullException(nameof(options));
        if (string.IsNullOrWhiteSpace(options.UrlName)) throw new PropertyNotSetException(nameof(options.UrlName));
        return Client.Get($"/{options.UrlName}/events", options);
    }

    #endregion

}