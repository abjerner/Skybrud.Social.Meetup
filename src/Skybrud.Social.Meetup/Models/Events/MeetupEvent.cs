using System;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Essentials.Time;
using Skybrud.Social.Meetup.Fields;
using Skybrud.Social.Meetup.Models.Groups;
using Skybrud.Social.Meetup.Models.Photos;
using Skybrud.Social.Meetup.Models.Venues;

namespace Skybrud.Social.Meetup.Models.Events; 

/// <summary>
/// Class representing a Meetup.com event.
/// </summary>
/// <see>
///     <cref>https://www.meetup.com/meetup_api/docs/:urlname/events/:id/#get</cref>
/// </see>
public class MeetupEvent : MeetupObject {

    #region Properties

    /// <summary>
    /// Gets a timestamp for when the event was created.
    /// </summary>
    public EssentialsTime? Created { get; }

    /// <summary>
    /// Gets the scheduled duration of the event if an end time has been specified by the organizer.
    /// </summary>
    public TimeSpan Duration { get; }

    /// <summary>
    /// Gets whether the event has a scheduled duration.
    /// </summary>
    public bool HasDuration => Duration.Ticks > 0;

    /// <summary>
    /// Gets the ID of the event.
    /// </summary>
    public string Id { get; }

    /// <summary>
    /// Gets the name of the event.
    /// </summary>
    public string Name { get; }

    // TODO: Add support for the "rsvp_limit"

    // TODO: Add support for the "date_in_series_pattern"

    // TODO: Add support for the "status"

    /// <summary>
    /// Gets the start time of the event.
    /// </summary>
    public EssentialsTime? Time { get; }

    // TODO: Add support for the "local_date"

    // TODO: Add support for the "local_time"

    /// <summary>
    /// Gets a timestamp for when the event was last modified.
    /// </summary>
    public EssentialsTime? Updated { get; }

    // TODO: Add support for the "utc_offset"

    // TODO: Add support for the "waitlist_count"

    // TODO: Add support for the "yes_rsvp_count"

    /// <summary>
    /// Gets a reference to the group hosting the event.
    /// </summary>
    public MeetupGroup Group { get; }

    /// <summary>
    /// Gets a refence to the venue of the meetup. Use <see cref="HasVenue"/> to check whether the event has a venue.
    /// </summary>
    public MeetupVenue? Venue { get; }

    /// <summary>
    /// Gets whether the event has a venue.
    /// </summary>
    public bool HasVenue => Venue != null;

    /// <summary>
    /// Gets the URL of the event at the Meetup.com website.
    /// </summary>
    public string Link { get; }

    /// <summary>
    /// Gets the description of the event in HTML. Email addresses and phone numbers will be masked for non-members.
    /// </summary>
    public string Description { get; }

    // TODO: Add support for the "how_to_find_us" property

    /// <summary>
    /// Gets the visibility of the event.
    /// </summary>
    public MeetupEventVisibility Visibility { get; }

    /// <summary>
    /// Gets the featured photo of the event, or <c>null</c> if not present.
    ///
    /// Notice that this property requires the <see cref="MeetupEventFields.FeaturedPhoto"/> field to be part of the request.
    /// </summary>
    public MeetupPhoto? FeaturedPhoto { get; }

    /// <summary>
    /// Gets whether the event has a featured photo.
    /// </summary>
    public bool HasFeaturedPhoto => FeaturedPhoto != null;

    #endregion

    #region Constructors

    private MeetupEvent(JObject obj) : base(obj) {
        Created = obj.HasValue("created") ? obj.GetInt64("created", ParseUnixTimestamp) : null;
        Duration = obj.GetDouble("duration", TimeSpan.FromMilliseconds);
        Id = obj.GetString("id")!;
        Name = obj.GetString("name")!;
        Time = obj.HasValue("time") ? obj.GetInt64("time", ParseUnixTimestamp) : null;
        Updated = obj.HasValue("updated") ? obj.GetInt64("updated", ParseUnixTimestamp) : null;
        Group = obj.GetObject("group", MeetupGroup.Parse)!;
        Venue = obj.GetObject("venue", MeetupVenue.Parse);
        Link = obj.GetString("link")!;
        Description = obj.GetString("description")!;
        Visibility = obj.HasValue("visiblity") ? obj.GetEnum<MeetupEventVisibility>("visibility") : MeetupEventVisibility.Unspecified;
        FeaturedPhoto = obj.GetObject("featured_photo", MeetupPhoto.Parse);
    }

    #endregion

    #region Static methods

    /// <summary>
    /// Parses the specified <paramref name="obj"/> into an instance of <see cref="MeetupEvent"/>.
    /// </summary>
    /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
    /// <returns>An instance of <see cref="MeetupEvent"/>.</returns>
    [return: NotNullIfNotNull("obj")]
    public static MeetupEvent? Parse(JObject? obj) {
        return obj == null ? null : new MeetupEvent(obj);
    }

    #endregion

}