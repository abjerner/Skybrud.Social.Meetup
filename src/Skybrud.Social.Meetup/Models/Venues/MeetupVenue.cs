using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Essentials.Locations;

namespace Skybrud.Social.Meetup.Models.Venues {
    
    public class MeetupVenue : MeetupObject, ILocation {

        #region Properties

        public long Id { get; private set; }

        public string Name { get; private set; }

        public double Latitude { get; private set; }

        public double Longitude { get; private set; }

        public string Address1 { get; private set; }

        public string Address2 { get; private set; }

        public string Address3 { get; private set; }

        public string City { get; private set; }

        public string Country { get; private set; }

        public string LocalizedCountryName { get; private set; }

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