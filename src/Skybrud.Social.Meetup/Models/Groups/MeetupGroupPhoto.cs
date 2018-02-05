using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Meetup.Models.Groups {
    
    /// <summary>
    /// Class representing a photo of a group.
    /// </summary>
    public class MeetupGroupPhoto : MeetupObject {

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
        public MeetupGroupPhotoType Type { get; }
        
        /// <summary>
        /// Gets a base url that can be use to construct a photo url from its components.
        /// </summary>
        public string BaseUrl { get; }

        #endregion

        #region Constructors

        private MeetupGroupPhoto(JObject obj) : base(obj) {
            Id = obj.GetInt64("id");
            HighresLink = obj.GetString("highres_link");
            PhotoLink = obj.GetString("photo_link");
            ThumbLink = obj.GetString("thumb_link");
            Type = obj.GetEnum<MeetupGroupPhotoType>("type");
            BaseUrl = obj.GetString("base_url");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="MeetupGroupPhoto"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="MeetupGroupPhoto"/>.</returns>
        public static MeetupGroupPhoto Parse(JObject obj) {
            return obj == null ? null : new MeetupGroupPhoto(obj);
        }

        #endregion

    }

}