using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using System.Diagnostics.CodeAnalysis;

namespace Skybrud.Social.Meetup.Models.GraphQl.Events {

    /// <see>
    ///     <cref>https://www.meetup.com/api/schema/#UpcomingEventsEdge</cref>
    /// </see>
    public class UpcomingEventsEdge : MeetupObject {

        #region Properties

        /// <summary>
        /// Represents the position of the item inside the list of edges.
        /// </summary>
        [JsonProperty("cursor")]
        public string? Cursor { get; }

        /// <summary>
        /// Contains information about the event.
        /// </summary>
        [JsonProperty("node")]
        public MeetupEvent? Node { get; }

        #endregion

        #region Constructors

        private UpcomingEventsEdge(JObject json) : base(json) {
            Cursor = json.GetString("cursor");
            Node = json.GetObject("node", MeetupEvent.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> object into an instance of <see cref="UpcomingEventsEdge"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="UpcomingEventsEdge"/>.</returns>
        [return: NotNullIfNotNull("json")]
        public static UpcomingEventsEdge? Parse(JObject? json) {
            return json == null ? null : new UpcomingEventsEdge(json);
        }

        #endregion

    }

}