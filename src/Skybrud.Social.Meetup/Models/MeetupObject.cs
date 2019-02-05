using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json;
using Skybrud.Essentials.Time;

namespace Skybrud.Social.Meetup.Models {

    /// <summary>
    /// Class representing an object received from the Meetup API.
    /// </summary>
    public class MeetupObject : JsonObjectBase {

        #region Constructors

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> representing the object.</param>
        protected MeetupObject(JObject obj) : base(obj) { }

        #endregion

        #region Member methods

        /// <summary>
        /// Parses the specified millisecond UNIX timestamp into an instance of <see cref="EssentialsTime"/>.
        /// </summary>
        /// <param name="timestamp">The timestamp to be parsed.</param>
        /// <returns>An instance of <see cref="EssentialsTime"/>.</returns>
        protected EssentialsTime ParseUnixTimestamp(long timestamp) {
            return EssentialsTime.FromUnixTimestamp(timestamp / 1000);
        }

        #endregion

    }

}