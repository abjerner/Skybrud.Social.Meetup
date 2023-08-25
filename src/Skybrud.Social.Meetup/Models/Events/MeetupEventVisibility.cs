namespace Skybrud.Social.Meetup.Models.Events; 

/// <summary>
/// Enum class representing the visibility of an event. <see cref="Unspecified"/> indicates
/// that the visibility wasn't part of the response from the API.
/// </summary>
public enum MeetupEventVisibility {

    /// <summary>
    /// Indicates that the visibility wasn't returned by the API.
    /// </summary>
    Unspecified,

    /// <summary>
    /// Indicates that the event is public.
    /// </summary>
    Public,
        
    /// <summary>
    /// Indicates that the event only has limited visibility to the public.
    /// </summary>
    PublicLimited,

    /// <summary>
    /// Indicates that the event is only visible to members.
    /// </summary>
    Members

}