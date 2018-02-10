﻿using Newtonsoft.Json.Linq;
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

        /// <summary>
        /// Gets a timestamp for when the event was created.
        /// </summary>
        public EssentialsDateTime Created { get; }

        /// <summary>
        /// Gets the ID of the event.
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// Gets the name of the event.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the start time of the event.
        /// </summary>
        public EssentialsDateTime Time { get; }

        /// <summary>
        /// Gets a timestamp for when the event was last modified.
        /// </summary>
        public EssentialsDateTime Updated { get; }

        /// <summary>
        /// Gets a reference to the group hosting the event.
        /// </summary>
        public MeetupGroup Group { get; }

        /// <summary>
        /// Gets a refence to the venue of the meetup. Use <see cref="HasVenue"/> to check whether the event has a venue.
        /// </summary>
        public MeetupVenue Venue { get; }

        /// <summary>
        /// Gets whether the event has a venue.
        /// </summary>
        public bool HasVenue => Venue != null;

        /// <summary>
        /// Gets the URL of the event at the Meetup.com website.
        /// </summary>
        public string Link { get; }

        /// <summary>
        /// Gets the description of the event in HTML. Email addresses and phone numbers will be masked for non-members.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Gets the visibility of the event.
        /// </summary>
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