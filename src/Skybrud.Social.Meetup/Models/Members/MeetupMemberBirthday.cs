using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using System.Diagnostics.CodeAnalysis;

namespace Skybrud.Social.Meetup.Models.Members; 

/// <summary>
/// Class representing the birthday of a member.
/// </summary>
public class MeetupMemberBirthday : MeetupObject {

    #region Properties

    /// <summary>
    /// Gets the day of the month.
    /// </summary>
    public int Day { get; set; }

    /// <summary>
    /// Gets the month.
    /// </summary>
    public int Month { get; set; }

    /// <summary>
    /// Gets the year.
    /// </summary>
    public int Year { get; set; }

    #endregion

    #region Constructors

    private MeetupMemberBirthday(JObject obj) : base(obj) {
        Day = obj.GetInt32("day");
        Month = obj.GetInt32("month");
        Year = obj.GetInt32("year");
    }

    #endregion

    #region Static methods

    /// <summary>
    /// Parses the specified <paramref name="obj"/> into an instance of <see cref="MeetupMemberBirthday"/>.
    /// </summary>
    /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
    /// <returns>An instance of <see cref="MeetupMemberBirthday"/>.</returns>
    [return: NotNullIfNotNull("obj")]
    public static MeetupMemberBirthday? Parse(JObject? obj) {
        return obj == null ? null : new MeetupMemberBirthday(obj);
    }

    #endregion

}