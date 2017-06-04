using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json;
using Skybrud.Essentials.Time;

namespace Skybrud.Social.Meetup.Models {
    
    public class MeetupObject : JsonObjectBase {

        #region Constructors

        protected MeetupObject(JObject obj) : base(obj) { }

        #endregion

        #region Member methods

        /// <summary>
        /// Parses the specified millisecond UNIX timestamp into an instance of <see cref="EssentialsDateTime"/>.
        /// </summary>
        /// <param name="timestamp">The timestamp to be parsed.</param>
        /// <returns>An instance of <see cref="EssentialsDateTime"/>.</returns>
        protected EssentialsDateTime ParseUnixTimestamp(long timestamp) {
            return EssentialsDateTime.FromUnixTimestamp(timestamp / 1000);
        }

        #endregion

    }

}