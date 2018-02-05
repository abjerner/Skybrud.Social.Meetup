namespace Skybrud.Social.Meetup.Models.Events {
    
    /// <summary>
    /// Enum class representing the visibility of an event. <see cref="Unspecified"/> indicates
    /// that the visibility wasn't part of the response from the API.
    /// </summary>
    public enum MeetupEventVisibility {
        Unspecified,
        Public,
        PublicLimited,
        Members
    }

}