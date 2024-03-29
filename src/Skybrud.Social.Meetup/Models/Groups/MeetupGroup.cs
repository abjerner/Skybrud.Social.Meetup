﻿using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Essentials.Maps.Geometry;
using Skybrud.Social.Meetup.Models.Events;
using Skybrud.Social.Meetup.Models.Photos;
using System.Diagnostics.CodeAnalysis;

namespace Skybrud.Social.Meetup.Models.Groups; 

/// <summary>
/// Class representing a Meetup.com group.
/// </summary>
/// <see>
///     <cref>https://www.meetup.com/meetup_api/docs/:urlname/#get</cref>
/// </see>
public class MeetupGroup : MeetupObject, IPoint {

    #region Properties

    /// <summary>
    /// Gets the numeric ID of the group.
    /// </summary>
    public long Id { get; }

    /// <summary>
    /// Gets the name of the group.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Gets the URL of the page about the group at meetup.com.
    /// </summary>
    public string Link { get; }

    /// <summary>
    /// Gets the URL name/slug of the group.
    /// </summary>
    public string UrlName { get; }

    /// <summary>
    /// Gets a short description about the group.
    /// </summary>
    public string Description { get; }

    /// <summary>
    /// The latitude of the group.
    /// </summary>
    public double Latitude { get; }

    /// <summary>
    /// The longitude of the group.
    /// </summary>
    public double Longitude { get; }

    /// <summary>
    /// Gets the next event of the group, or <c>null</c> if there are no upcoming events.
    /// </summary>
    public MeetupEvent? NextEvent { get; }

    /// <summary>
    /// Gets whether group has an upcoming event.
    /// </summary>
    public bool HasNextEvent => NextEvent != null;

    /// <summary>
    /// Gets the group photo of the group.
    /// </summary>
    public MeetupPhoto? GroupPhoto { get; }

    /// <summary>
    /// Gets whether the group has a group photo.
    /// </summary>
    public bool HasGroupPhoto => GroupPhoto != null;

    /// <summary>
    /// Gets the primary photo of the group.
    /// </summary>
    public MeetupPhoto? KeyPhoto { get; }

    /// <summary>
    /// Gets whether the group has a key photo.
    /// </summary>
    public bool HasKeyPhoto => KeyPhoto != null;

    #endregion

    #region Constructors

    private MeetupGroup(JObject obj) : base(obj) {
        Id = obj.GetInt64("id");
        Name = obj.GetString("name")!;
        Link = obj.GetString("link")!;
        UrlName = obj.GetString("urlname")!;
        Description = obj.GetString("description")!;
        Latitude = obj.GetDouble("lat");
        Longitude = obj.GetDouble("lon");
        NextEvent = obj.GetObject("next_event", MeetupEvent.Parse);
        GroupPhoto = obj.GetObject("group_photo", MeetupPhoto.Parse);
        KeyPhoto = obj.GetObject("key_photo", MeetupPhoto.Parse);
    }

    #endregion

    #region Static methods

    /// <summary>
    /// Parses the specified <paramref name="obj"/> into an instance of <see cref="MeetupGroup"/>.
    /// </summary>
    /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
    /// <returns>An instance of <see cref="MeetupGroup"/>.</returns>
    [return: NotNullIfNotNull("obj")]
    public static MeetupGroup? Parse(JObject? obj) {
        return obj == null ? null : new MeetupGroup(obj);
    }

    #endregion

}