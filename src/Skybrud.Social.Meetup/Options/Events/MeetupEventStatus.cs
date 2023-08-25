namespace Skybrud.Social.Meetup.Options.Events; 

/// <summary>
/// Enum class representing the status of events to be returned by the Meetup.com API.
/// </summary>
public enum MeetupEventStatus {

    /// <summary>
    /// Indicates that cancelled events should be returned by the API.
    /// </summary>
    Cancelled,

    /// <summary>
    /// Indicates that draft events should be returned by the API. This status may not be requested with other status values.
    /// </summary>
    Draft,

    /// <summary>
    /// Indicates that past events should be returned by the API.
    /// </summary>
    Past,

    /// <summary>
    /// Indicates that proposed events should be returned by the API.
    /// </summary>
    Proposed,

    /// <summary>
    /// Indicates that suggested events should be returned by the API.
    /// </summary>
    Suggested,

    /// <summary>
    /// Indicates that upcoming events should be returned by the API.
    /// </summary>
    Upcoming

}