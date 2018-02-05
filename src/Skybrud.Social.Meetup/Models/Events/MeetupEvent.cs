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

        public EssentialsDateTime Created { get; }

        public string Id { get; }

        public string Name { get; }

        public EssentialsDateTime Time { get; }

        public EssentialsDateTime Updated { get; }

        public MeetupGroup Group { get; }

        public MeetupVenue Venue { get; }

        public bool HasVenue => Venue != null;

        public string Link { get; }

        public string Description { get; }

        public MeetupEventVisibility Visibility { get; }

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