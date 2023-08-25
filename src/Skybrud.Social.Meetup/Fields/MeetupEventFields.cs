using Skybrud.Social.Meetup.Models.Events;

namespace Skybrud.Social.Meetup.Fields; 

/// <summary>
/// Static class with available fields of a <see cref="MeetupEvent"/>.
/// </summary>
public static class MeetupEventFields {

    /// <summary>
    /// Field indicating that the featured photo should be returned.
    /// </summary>
    public static readonly MeetupField FeaturedPhoto = new("featured_photo");

    // TODO: Add support for the remaining fields

}