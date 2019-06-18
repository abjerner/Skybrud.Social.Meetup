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
        public string Name { get; }

        /// <summary>
        /// Gets the description of the scope.
        /// </summary>
        public string Description { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new scope with the specified <paramref name="name"/>.
        /// </summary>
        /// <param name="name">The name of the scope.</param>
        public MeetupScope(string name) {
            Name = name;
            Description = string.Empty;
        }

        /// <summary>
        /// Initializes a new scope with the specified <paramref name="name"/> and <paramref name="description"/>.
        /// </summary>
        /// <param name="name">The name of the scope.</param>
        /// <param name="description">The description of the scope.</param>
        public MeetupScope(string name, string description) {
            Name = name;
            Description = string.IsNullOrWhiteSpace(description) ? string.Empty : description.Trim();
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Returns a string representation of the scope.
        /// </summary>
        /// <returns>The name of the scope.</returns>
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
        /// <returns>Gets a scope matching the specified <paramref name="name"/>, or <c>null</c> if not found.</returns>
        public static MeetupScope GetScope(string name) {
            return Scopes.TryGetValue(name, out MeetupScope scope) ? scope : null;
        }

        /// <summary>
        /// Gets whether the scope is a known scope.
        /// </summary>
        /// <param name="name">The name of the scope.</param>
        /// <returns><c>true</c> if the specified <paramref name="name"/> matches a known scope, otherwise <c>false</c>.</returns>
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