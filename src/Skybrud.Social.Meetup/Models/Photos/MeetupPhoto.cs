using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Meetup.Models.Photos {
    
    /// <summary>
    /// Class representing a photo of a group or event.
    /// </summary>
    public class MeetupPhoto : MeetupObject {

        #region Properties

        /// <summary>
        /// Gets the numeric ID of the photo.
        /// </summary>
        public long Id { get; }

        /// <summary>
        /// Gets the URL for a full sized version of the photo.
        /// </summary>
        public string HighresLink { get; }
        
        /// <summary>
        /// Gets the URL for a standard sized version of the photo.
        /// </summary>
        public string PhotoLink { get; }
        
        /// <summary>
        /// Gets the URL for a thumbnail sized version of the photo.
        /// </summary>
        public string ThumbLink { get; }
        
        /// <summary>
        /// Gets the type of the photo.
        /// </summary>
        public MeetupPhotoType Type { get; }
        
        /// <summary>
        /// Gets a base url that can be use to construct a photo url from its components.
        /// </summary>
        public string BaseUrl { get; }

        #endregion

        #region Constructors

        private MeetupPhoto(JObject obj) : base(obj) {
            Id = obj.GetInt64("id");
            HighresLink = obj.GetString("highres_link");
            PhotoLink = obj.GetString("photo_link");
            ThumbLink = obj.GetString("thumb_link");
            Type = obj.GetEnum<MeetupPhotoType>("type");
            BaseUrl = obj.GetString("base_url");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="MeetupPhoto"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="MeetupPhoto"/>.</returns>
        public static MeetupPhoto Parse(JObject obj) {
            return obj == null ? null : new MeetupPhoto(obj);
        }

        #endregion

    }

}