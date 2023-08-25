using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;
using System.Diagnostics.CodeAnalysis;

namespace Skybrud.Social.Meetup.Models.GraphQl.Events; 

/// <summary>
/// Class representing an image of an event.
/// </summary>
/// <see>
///     <cref>https://www.meetup.com/api/schema/#EventImage</cref>
/// </see>
public class MeetupEventImage : MeetupObject {

    #region Properties

    /// <summary>
    /// Gets the ID of the image.
    /// </summary>
    [JsonProperty("id")]
    public string? Id { get; }

    /// <summary>
    /// Gets the base url of the image
    /// </summary>
    [JsonProperty("baseUrl")]
    public string? BaseUrl { get; }

    #endregion

    #region Constructors

    private MeetupEventImage(JObject json) : base(json) {
        Id = json.GetString("id");
        BaseUrl = json.GetString("baseUrl");
    }

    #endregion

    #region Static methods

    /// <summary>
    /// Parses the specified <paramref name="json"/> object into an instance of <see cref="MeetupEventImage"/>.
    /// </summary>
    /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
    /// <returns>An instance of <see cref="MeetupEventImage"/>.</returns>
    [return: NotNullIfNotNull("json")]
    public static MeetupEventImage? Parse(JObject? json) {
        return json == null ? null : new MeetupEventImage(json);
    }

    #endregion

}