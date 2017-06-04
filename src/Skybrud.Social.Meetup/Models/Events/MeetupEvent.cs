using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Essentials.Time;
using Skybrud.Social.Meetup.Models.Groups;
using Skybrud.Social.Meetup.Models.Venues;

namespace Skybrud.Social.Meetup.Models.Events {
    
    /// <summary>
    /// Class representing a Meetup.com event.
    /// </summary>
    /// <see>
    ///     <cref>https://www.meetup.com/meetup_api/docs/:urlname/events/:id/#get</cref>
    /// </see>
    public class MeetupEvent : MeetupObject {

        #region Properties

        public EssentialsDateTime Created { get; private set; }

        public string Id { get; private set; }

        public string Name { get; private set; }

        public EssentialsDateTime Time { get; private set; }

        public EssentialsDateTime Updated { get; private set; }

        public MeetupGroup Group { get; private set; }

        public MeetupVenue Venue { get; private set; }

        public bool HasVenue {
            get { return Venue != null; }
        }

        public string Link { get; private set; }

        public string Description { get; private set; }

        public MeetupEventVisibility Visibility { get; private set; }

        #endregion

        #region Constructors

        private MeetupEvent(JObject obj) : base(obj) {
            Created = obj.HasValue("created") ? obj.GetInt64("created", ParseUnixTimestamp) : null;
            Id = obj.GetString("id");
            Name = obj.GetString("name");
            Time = obj.HasValue("time") ? obj.GetInt64("time", ParseUnixTimestamp) : null;
            Updated = obj.HasValue("updated") ? obj.GetInt64("updated", ParseUnixTimestamp) : null;
            Group = obj.GetObject("group", MeetupGroup.Parse);
            Venue = obj.GetObject("venue", MeetupVenue.Parse);
            Link = obj.GetString("link");
            Description = obj.GetString("description");
            Visibility = obj.HasValue("visiblity") ? obj.GetEnum<MeetupEventVisibility>("visibility") : MeetupEventVisibility.Unspecified;
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="MeetupEvent"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="MeetupEvent"/>.</returns>
        public static MeetupEvent Parse(JObject obj) {
            return obj == null ? null : new MeetupEvent(obj);
        }

        #endregion

    }

}