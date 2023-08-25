﻿using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;
using System.Diagnostics.CodeAnalysis;

namespace Skybrud.Social.Meetup.Models.GraphQl.Events {

    /// <summary>
    /// Class representing an upcoming events connection of a group.
    /// </summary>
    /// <see>
    ///     <cref>https://www.meetup.com/api/schema/#UpcomingEventsConnection</cref>
    /// </see>
    public class UpcomingEventsConnection : MeetupObject {

        #region Properties

        /// <summary>
        /// The total number of edges.
        /// </summary>
        [JsonProperty("count")]
        public int? Count { get; }

        /// <summary>
        /// Information to aid in pagination.
        /// </summary>
        [JsonProperty("pageInfo")]
        public MeetupPageInfo? PageInfo { get; }

        /// <summary>
        /// A list of upcoming events edges.
        /// </summary>
        [JsonProperty("edges")]
        public IReadOnlyList<UpcomingEventsEdge>? Edges { get; }

        #endregion

        #region Constructors

        private UpcomingEventsConnection(JObject json) : base(json) {
            Count = json.GetInt32OrNull("count");
            PageInfo = json.GetObject("pageInfo", MeetupPageInfo.Parse);
            Edges = json.GetArrayItems("edges", UpcomingEventsEdge.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> into an instance of <see cref="UpcomingEventsConnection"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="UpcomingEventsConnection"/>.</returns>
        [return: NotNullIfNotNull("json")]
        public static UpcomingEventsConnection? Parse(JObject? json) {
            return json == null ? null : new UpcomingEventsConnection(json);
        }

        #endregion

    }

}