using System;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Essentials.Time;

namespace Skybrud.Social.Meetup.Models.Members {

    /// <summary>
    /// Class representing a Meetup member.
    /// </summary>
    public class MeetupMember : MeetupObject {

        #region Properties
        
        /// <summary>
        /// Gets the bio of the member. Use <see cref="HasBio"/> to check whether the member has specified a bio.
        /// </summary>
        public string Bio { get; }

        /// <summary>
        /// Gets whether the member has specified a bio.
        /// </summary>
        public bool HasBio => String.IsNullOrWhiteSpace(Bio);

        /// <summary>
        /// Gets the birthday of the member, or <c>null</c> if not specified. Use <see cref="HasBirthday"/> to check
        /// whether the member has specified a bio.
        /// </summary>
        public MeetupMemberBirthday Birthday { get; }

        /// <summary>
        /// Gets whether the member has specified a birthday.
        /// </summary>
        public bool HasBirthday => Birthday != null;

        /// <summary>
        /// Gets the country of the member.
        /// </summary>
        public string Country { get; }

        /// <summary>
        /// Gets the city of the member.
        /// </summary>
        public string City { get; }

        /// <summary>
        /// Gets the state of the member.
        /// </summary>
        public string State { get; }

        /// <summary>
        /// Gets the gender of the member.
        /// </summary>
        public MeetupGender Gender { get; }

        /// <summary>
        /// Gets whether the member has specified a gender.
        /// </summary>
        public bool HasGender => Gender != MeetupGender.None;

        /// <summary>
        /// Gets the hometown of the member.
        /// </summary>
        public string Hometown { get; }

        /// <summary>
        /// Gets the ID of the member.
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Gets a timestamp for when the member joined Meetup.
        /// </summary>
        public EssentialsTime Joined { get; }

        /// <summary>
        /// Gets the language of the member.
        /// </summary>
        public string Language { get; }

        /// <summary>
        /// Gets the latitude of the member.
        /// </summary>
        public double Latitude { get; set; }

        /// <summary>
        /// Gets the longitude of the member.
        /// </summary>
        public double Longitude { get; set; }

        /// <summary>
        /// Gets the URL of the member at the Meetup.com website.
        /// </summary>
        public string Link { get; }

        // TODO: Add support for the "membership_count" property

        // TODO: Add support for the "messagable" property

        // TODO: Add support for the "messaging_pref" property

        /// <summary>
        /// Gets the name of the member.
        /// </summary>
        public string Name { get; }

        // TODO: Add support for the "other_services" property

        // TODO: Add support for the "photo" property

        // TODO: Add support for the "photo_url" property

        // TODO: Add support for the "photos" property

        // TODO: Add support for the "privacy" property

        // TODO: Add support for the "reachable" property

        // TODO: Add support for the "self" property

        // TODO: Add support for the "status" property

        /// <summary>
        /// Gets an array of the topics of the member.
        /// </summary>
        public MeetupMemberTopic[] Topics { get; }

        // TODO: Add support for the "visited" property

        #endregion

        #region Constructors

        private MeetupMember(JObject obj) : base(obj) {
            Bio = obj.GetString("bio");
            Birthday = obj.GetObject("birthday", MeetupMemberBirthday.Parse);
            Country = obj.GetString("country");
            City = obj.GetString("city");
            State = obj.GetString("state");
            Gender = obj.GetEnum("gender", MeetupGender.None);
            Hometown = obj.GetString("hometown");
            Id = obj.GetInt32("id");
            Joined = obj.HasValue("joined") ? obj.GetInt64("joined", ParseUnixTimestamp) : null;
            Language = obj.GetString("lang");
            Latitude = obj.GetDouble("lat");
            Longitude = obj.GetDouble("lon");
            Link = obj.GetString("link");
            Name = obj.GetString("name");
            Topics = obj.GetArrayItems("topics", MeetupMemberTopic.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="MeetupMember"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="MeetupMember"/>.</returns>
        public static MeetupMember Parse(JObject obj) {
            return obj == null ? null : new MeetupMember(obj);
        }

        #endregion

    }

}