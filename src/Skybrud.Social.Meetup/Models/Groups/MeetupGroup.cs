using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Meetup.Models.Groups {
    
    public class MeetupGroup : MeetupObject {

        #region Properties

        public long Id { get; private set; }

        public string Name { get; private set; }

        public string Link { get; private set; }

        public string UrlName { get; private set; }

        public string Description { get; private set; }

        #endregion

        #region Constructors

        private MeetupGroup(JObject obj) : base(obj) {
            Id = obj.GetInt64("id");
            Name = obj.GetString("name");
            Link = obj.GetString("link");
            UrlName = obj.GetString("urlname");
            Description = obj.GetString("description");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="MeetupGroup"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="MeetupGroup"/>.</returns>
        public static MeetupGroup Parse(JObject obj) {
            return obj == null ? null : new MeetupGroup(obj);
        }

        #endregion

    }

}