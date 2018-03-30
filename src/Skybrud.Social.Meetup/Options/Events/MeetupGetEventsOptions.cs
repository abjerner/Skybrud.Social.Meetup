using System;
using System.Linq;
using Skybrud.Essentials.Strings;
using Skybrud.Social.Http;
using Skybrud.Social.Interfaces.Http;

namespace Skybrud.Social.Meetup.Options.Events {

    /// <see>
    ///     <cref>https://www.meetup.com/meetup_api/docs/:urlname/events/#listparams</cref>
    /// </see>
    public class MeetupGetEventsOptions : IHttpGetOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the URL name/slug of the parent group.
        /// </summary>
        public string UrlName { get; set; }

        /// <summary>
        /// Gets or sets the maximum amount of events to be returned in a page. Must be a value greater than or equal
        /// to <c>1</c>. Default is <c>200</c>.
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// Gets or sets the offset.
        /// </summary>
        public int Offset { get; set; }

        /// <summary>
        /// Gets or sets an array of the statuses that the returned events should match. If empty, upcoming events will be returned.
        /// </summary>
        public MeetupEventStatus[] Status { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance with default options.
        /// </summary>
        public MeetupGetEventsOptions() { }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="urlname"/>.
        /// </summary>
        /// <param name="urlname">The URL name of the group.</param>
        public MeetupGetEventsOptions(string urlname) {
            UrlName = urlname;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="urlname"/> and <paramref name="status"/>.
        /// </summary>
        /// <param name="urlname">The URL name of the group.</param>
        /// <param name="status">The statuses that the returned events should match.</param>
        public MeetupGetEventsOptions(string urlname, params MeetupEventStatus[] status) {
            UrlName = urlname;
            Status = status;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="urlname"/> and <paramref name="page"/>.
        /// </summary>
        /// <param name="urlname">The URL name of the group.</param>
        /// <param name="page">The page to be returned.</param>
        public MeetupGetEventsOptions(string urlname, int page) {
            UrlName = urlname;
            Page = page;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="urlname"/>, <paramref name="page"/> and <paramref name="status"/>.
        /// </summary>
        /// <param name="urlname">The URL name of the group.</param>
        /// <param name="page">The page to be returned.</param>
        /// <param name="status">The statuses that the returned events should match.</param>
        public MeetupGetEventsOptions(string urlname, int page, params MeetupEventStatus[] status) {
            UrlName = urlname;
            Page = page;
            Status = status;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="urlname"/>, <paramref name="page"/> and
        /// <paramref name="offset"/>.
        /// </summary>
        /// <param name="urlname">The URL name of the group.</param>
        /// <param name="page">The page to be returned.</param>
        /// <param name="offset">The offset.</param>
        public MeetupGetEventsOptions(string urlname, int page, int offset) {
            UrlName = urlname;
            Page = page;
            Offset = offset;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="urlname"/>, <paramref name="page"/>, <paramref name="offset"/> and <paramref name="status"/>.
        /// </summary>
        /// <param name="urlname">The URL name of the group.</param>
        /// <param name="page">The page to be returned.</param>
        /// <param name="offset">The offset.</param>
        /// <param name="status">The statuses that the returned events should match.</param>
        public MeetupGetEventsOptions(string urlname, int page, int offset, params MeetupEventStatus[] status) {
            UrlName = urlname;
            Page = page;
            Offset = offset;
            Status = status;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets an instance of <see cref="IHttpQueryString"/> representing the GET parameters.
        /// </summary>
        public IHttpQueryString GetQueryString() {
            
            IHttpQueryString query = new SocialHttpQueryString();

            // TODO: Add support for the "desc" parameter
            // TODO: Add support for the "fields" parameter
            if (Page > 0) query.Add("page", Page);
            if (Offset > 0) query.Add("offset", Offset);
            // TODO: Add support for the "scroll" parameter

            if (Status != null && Status.Length > 0) query.Add("status", String.Join(",", from status in Status select StringUtils.ToCamelCase(status))); 

            return query;

        }

        #endregion

    }

}