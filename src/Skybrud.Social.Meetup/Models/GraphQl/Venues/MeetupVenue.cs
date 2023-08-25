using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using System.Diagnostics.CodeAnalysis;

namespace Skybrud.Social.Meetup.Models.GraphQl.Venues; 

/// <summary>
/// Class representing a venue of an event.
/// </summary>
/// <see>
///     <cref>https://www.meetup.com/api/schema/#Venue</cref>
/// </see>
public class MeetupVenue : MeetupObject {

    #region Properties

    /// <summary>
    /// Gets the ID of the venue.
    /// </summary>
    [JsonProperty("id")]
    public string? Id { get; }

    /// <summary>
    /// Gets the name of the venue.
    /// </summary>
    [JsonProperty("name")]
    public string? Name { get; }

    /// <summary>
    /// Gets the latitude of the venue.
    /// </summary>
    [JsonProperty("lat")]
    public double? Latitude { get; }

    /// <summary>
    /// Gets longtitude of the venue.
    /// </summary>
    [JsonProperty("lng")]
    public double? Longitude { get; }

    #endregion

    #region Constructors

    private MeetupVenue(JObject json) : base(json) {
        Id = json.GetString("id");
        Name = json.GetString("name");
        Latitude = json.GetDouble("lat");
        Longitude = json.GetDouble("lng");
    }

    #endregion

    #region Static methods

    /// <summary>
    /// Parses the specified <paramref name="json"/> object into an instance of <see cref="MeetupVenue"/>.
    /// </summary>
    /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
    /// <returns>An instance of <see cref="MeetupVenue"/>.</returns>
    [return: NotNullIfNotNull("json")]
    public static MeetupVenue? Parse(JObject? json) {
        return json == null ? null : new MeetupVenue(json);
    }

    #endregion

}