using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using System.Diagnostics.CodeAnalysis;

namespace Skybrud.Social.Meetup.Models.Members; 

/// <summary>
/// Class representing a topic of a <see cref="MeetupMember"/>.
/// </summary>
public class MeetupMemberTopic : MeetupObject {

    #region Properties

    /// <summary>
    /// Gets the URL key of the topic.
    /// </summary>
    public string UrlKey { get; set; }

    /// <summary>
    /// Gets the name of the topic.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets the ID of the topic.
    /// </summary>
    public int Id { get; set; }

    #endregion

    #region Constructors

    private MeetupMemberTopic(JObject obj) : base(obj) {
        UrlKey = obj.GetString("urlkey")!;
        Name = obj.GetString("name")!;
        Id = obj.GetInt32("id");
    }

    #endregion

    #region Static methods

    /// <summary>
    /// Parses the specified <paramref name="obj"/> into an instance of <see cref="MeetupMemberTopic"/>.
    /// </summary>
    /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
    /// <returns>An instance of <see cref="MeetupMemberTopic"/>.</returns>
    [return: NotNullIfNotNull("obj")]
    public static MeetupMemberTopic? Parse(JObject? obj) {
        return obj == null ? null : new MeetupMemberTopic(obj);
    }

    #endregion

}