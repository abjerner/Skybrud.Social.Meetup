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
        /// to <code>1</code>. Default is <code>200</code>.
        /// </summary>
        public int Page { get; set; }

        public int Offset { get; set; }

        #endregion

        #region Constructors

        public MeetupGetEventsOptions() { }

        public MeetupGetEventsOptions(string urlname) {
            UrlName = urlname;
        }

        public MeetupGetEventsOptions(string urlname, int page) {
            UrlName = urlname;
            Page = page;
        }

        public MeetupGetEventsOptions(string urlname, int page, int offset) {
            UrlName = urlname;
            Page = page;
            Offset = offset;
        }

        #endregion

        #region Member methods

        public IHttpQueryString GetQueryString() {
            
            IHttpQueryString query = new SocialHttpQueryString();

            // TODO: Add support for the "desc" parameter
            // TODO: Add support for the "fields" parameter
            if (Page > 0) query.Add("page", Page);
            if (Offset > 0) query.Add("offset", Offset);
            // TODO: Add support for the "scroll" parameter
            // TODO: Add support for the "status" parameter

            return query;

        }

        #endregion

    }

}