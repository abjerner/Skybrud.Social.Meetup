using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using System.Diagnostics.CodeAnalysis;

namespace Skybrud.Social.Meetup.Models.GraphQl;

/// <summary>
/// Class representing the result of a request to the
/// </summary>
public class MeetupGraphQlGroupResult : MeetupObject {

    #region Properties

    /// <summary>
    /// Gets a reference to the data object of the result.
    /// </summary>
    public MeetupGraphQlGroupData Data { get; }

    #endregion

    #region Constructors

    private MeetupGraphQlGroupResult(JObject json) : base(json) {
        Data = json.GetObject("data", MeetupGraphQlGroupData.Parse)!;
    }

    #endregion

    #region Static methods

    /// <summary>
    /// Parses the specified <paramref name="json"/> object into an instance of <see cref="MeetupGraphQlGroupResult"/>.
    /// </summary>
    /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
    /// <returns>An instance of <see cref="MeetupGraphQlGroupResult"/>.</returns>
    [return: NotNullIfNotNull("json")]
    public static MeetupGraphQlGroupResult? Parse(JObject? json) {
        return json == null ? null : new MeetupGraphQlGroupResult(json);
    }

    #endregion

}