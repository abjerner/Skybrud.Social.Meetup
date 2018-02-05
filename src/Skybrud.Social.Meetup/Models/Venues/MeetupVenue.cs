using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Essentials.Locations;

namespace Skybrud.Social.Meetup.Models.Venues {
    
    /// <summary>
    /// Class describing a venue of an event.
    /// </summary>
    public class MeetupVenue : MeetupObject, ILocation {

        #region Properties

        /// <summary>
        /// Gets the numeric ID of the venue.
        /// </summary>
        public long Id { get; }

        /// <summary>
        /// Gets the name of the venue.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the latitude of the event.
        /// </summary>
        public double Latitude { get; }

        /// <summary>
        /// Gets the longitude of the event.
        /// </summary>
        public double Longitude { get; }

        /// <summary>
        /// Gets the first line of the address of the venue.
        /// </summary>
        public string Address1 { get; }

        /// <summary>
        /// Gets the second line of the address of the venue.
        /// </summary>
        public string Address2 { get; }

        /// <summary>
        /// Gets the third line of the address of the venue.
        /// </summary>
        public string Address3 { get; }

        /// <summary>
        /// Gets the city of the venue.
        /// </summary>
        public string City { get; }

        /// <summary>
        /// Gets the country of the venue.
        /// </summary>
        public string Country { get; }

        /// <summary>
        /// Gets localized country name of the venue.
        /// </summary>
        public string LocalizedCountryName { get; }

        #endregion

        #region Constructors

        private MeetupVenue(JObject obj) : base(obj) {
            Id = obj.GetInt64("id");
            Name = obj.GetString("name");
            Latitude = obj.GetDouble("lat");
            Longitude = obj.GetDouble("lon");
            Address1 = obj.GetString("address1");
            Address2 = obj.GetString("address2");
            Address3 = obj.GetString("address3");
            City = obj.GetString("city");
            Country = obj.GetString("country");
            LocalizedCountryName = obj.GetString("localized_country_name");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="MeetupVenue"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="MeetupVenue"/>.</returns>
        public static MeetupVenue Parse(JObject obj) {
            return obj == null ? null : new MeetupVenue(obj);
        }

        #endregion

    }

}