using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json;
using Skybrud.Essentials.Time;

namespace Skybrud.Social.Meetup.Models {
    
    public class MeetupObject : JsonObjectBase {

        #region Constructors

        protected MeetupObject(JObject obj) : base(obj) { }

        #endregion

        #region Member methods

        protected EssentialsDateTime ParseUnixTimestamp(long timestamp) {
            return EssentialsDateTime.FromUnixTimestamp(timestamp / 1000);
        }

        #endregion

    }

}