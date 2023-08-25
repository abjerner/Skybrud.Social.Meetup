using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using System.Diagnostics.CodeAnalysis;

namespace Skybrud.Social.Meetup.Models.GraphQl.Images {

    /// <summary>
    /// Class representing an image.
    /// </summary>
    /// <see>
    ///     <cref>https://www.meetup.com/api/schema/#Image</cref>
    /// </see>
    public class MeetupImage : MeetupObject {

        #region Properties

        /// <summary>
        /// Gets the ID of the image.
        /// </summary>
        [JsonProperty("id")]
        public string?Id { get; }

        /// <summary>
        /// Gets the base url of the image
        /// </summary>
        [JsonProperty("baseUrl")]
        public string? BaseUrl { get; }

        /// <summary>
        /// Gets an image coded in Base64.
        /// </summary>
        [JsonProperty("preview")]
        public string? Preview { get; }

        #endregion

        #region Constructors

        private MeetupImage(JObject json) : base(json) {
            Id = json.GetString("id");
            BaseUrl = json.GetString("baseUrl");
            Preview = json.GetString("preview");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> object into an instance of <see cref="MeetupImage"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="MeetupImage"/>.</returns>
        [return: NotNullIfNotNull("json")]
        public static MeetupImage? Parse(JObject? json) {
            return json == null ? null : new MeetupImage(json);
        }

        #endregion

    }

}