namespace Skybrud.Social.Meetup.Models; 

/// <summary>
/// Enum class representing the gender of a Meetup member.
/// </summary>
public enum MeetupGender {

    /// <summary>
    /// Indicates that a gender hasn't been specified (or wasn't returned by the API).
    /// </summary>
    None,
        
    /// <summary>
    /// Indicates that the member is female.
    /// </summary>
    Female,

    /// <summary>
    /// Indicates that the member is male.
    /// </summary>
    Male,
        
    /// <summary>
    /// Indicates that the member is of another gender.
    /// </summary>
    Other

}