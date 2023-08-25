using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Social.Meetup.Models.GraphQl.Groups;
using System.Diagnostics.CodeAnalysis;

namespace Skybrud.Social.Meetup.Models.GraphQl {

    /// <summary>
    /// Class representing the data of a GraphQL group result.
    /// </summary>
    public class MeetupGraphQlGroupData : MeetupObject {

        #region Properties

        /// <summary>
        /// Gets a reference to the group.
        /// </summary>
        public MeetupGroup GroupByUrlName { get; }

        #endregion

        #region Constructors

        private MeetupGraphQlGroupData(JObject json) : base(json) {
            GroupByUrlName = json.GetObject("groupByUrlname", MeetupGroup.Parse)!;
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> object into an instance of <see cref="MeetupGraphQlGroupData"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="MeetupGraphQlGroupData"/>.</returns>
        [return: NotNullIfNotNull("json")]
        public static MeetupGraphQlGroupData? Parse(JObject? json) {
            return json == null ? null : new MeetupGraphQlGroupData(json);
        }

        #endregion

    }

}