using System;
using System.Collections.Generic;

namespace Skybrud.Social.Meetup.Scopes {
    
    /// <summary>
    /// Class representing a scope of the Meetup API.
    /// </summary>
    public class MeetupScope {

        #region Private fields

        private static readonly Dictionary<string, MeetupScope> Scopes = new Dictionary<string, MeetupScope>();

        #endregion

        #region Properties

        /// <summary>
        /// Gets the name of the scope.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the description of the scope.
        /// </summary>
        public string Description { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new scope with the specified <paramref name="name"/>.
        /// </summary>
        /// <param name="name">The name of the scope.</param>
        public MeetupScope(string name) {
            Name = name;
            Description = String.Empty;
        }

        /// <summary>
        /// Initializes a new scope with the specified <paramref name="name"/> and <paramref name="description"/>.
        /// </summary>
        /// <param name="name">The name of the scope.</param>
        /// <param name="description">The description of the scope.</param>
        public MeetupScope(string name, string description) {
            Name = name;
            Description = String.IsNullOrWhiteSpace(description) ? String.Empty : description.Trim();
        }

        #endregion

        #region Member methods

        public override string ToString() {
            return Name;
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Registers a scope in the internal dictionary.
        /// </summary>
        /// <param name="name">The name of the scope.</param>
        /// <param name="description">The description of the scope.</param>
        internal static MeetupScope RegisterScope(string name, string description = null) {
            MeetupScope scope = new MeetupScope(name, description);
            Scopes.Add(scope.Name, scope);
            return scope;
        }

        /// <summary>
        /// Attempts to get a scope with the specified <paramref name="name"/>.
        /// </summary>
        /// <param name="name">The name of the scope.</param>
        /// <returns>Gets a scope matching the specified <paramref name="name"/>, or <code>null</code> if not found-</returns>
        public static MeetupScope GetScope(string name) {
            MeetupScope scope;
            return Scopes.TryGetValue(name, out scope) ? scope : null;
        }

        /// <summary>
        /// Gets whether the scope is a known scope.
        /// </summary>
        /// <param name="name">The name of the scope.</param>
        /// <returns><code>true</code> if the specified <paramref name="name"/> matches a known scope, otherwise <code>false</code>.</returns>
        public static bool ScopeExists(string name) {
            return Scopes.ContainsKey(name);
        }

        #endregion

        #region Operators

        /// <summary>
        /// Adding two instances of <see cref="MeetupScope"/> will result in a <see cref="MeetupScopeCollection"/>
        /// containing both scopes.
        /// </summary>
        /// <param name="left">The left scope.</param>
        /// <param name="right">The right scope.</param>
        public static MeetupScopeCollection operator +(MeetupScope left, MeetupScope right) {
            return new MeetupScopeCollection(left, right);
        }

        #endregion

    }

}