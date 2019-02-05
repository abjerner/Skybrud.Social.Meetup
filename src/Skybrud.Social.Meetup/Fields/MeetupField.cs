namespace Skybrud.Social.Meetup.Fields {
    
    /// <summary>
    /// Class representing a field in the Meetup API.
    /// </summary>
    public class MeetupField {

        #region Properties

        /// <summary>
        /// Gets the name of the field.
        /// </summary>
        public string Name { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new field with the specified <paramref name="name"/>.
        /// </summary>
        /// <param name="name">The name of the field.</param>
        public MeetupField(string name) {
            Name = name;
        }

        #endregion

        #region Operators

        /// <summary>
        /// Initializes a new field based on the specified <paramref name="name"/>.
        /// </summary>
        /// <param name="name">The name of the field.</param>
        public static implicit operator MeetupField(string name) {
            return new MeetupField(name);
        }

        /// <summary>
        /// Adding two instances of <see cref="MeetupField"/> will result in a <see cref="MeetupFieldsCollection"/> containing both fields.
        /// </summary>
        /// <param name="left">The left field.</param>
        /// <param name="right">The right field.</param>
        public static MeetupFieldsCollection operator +(MeetupField left, MeetupField right) {
            return new MeetupFieldsCollection(left, right);
        }

        #endregion

    }

}