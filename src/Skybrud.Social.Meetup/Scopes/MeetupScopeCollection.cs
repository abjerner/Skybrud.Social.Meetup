using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Skybrud.Social.Meetup.Scopes; 

/// <summary>
/// Class representing a collection of scopes for the Meetup API.
/// </summary>
public class MeetupScopeCollection : IEnumerable<MeetupScope> {

    #region Private fields

    private readonly List<MeetupScope> _list = new List<MeetupScope>();

    #endregion

    #region Properties

    /// <summary>
    /// Gets an array of all the scopes added to the collection.
    /// </summary>
    public MeetupScope[] Items => _list.ToArray();

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new collection based on the specified <paramref name="array"/> of scopes.
    /// </summary>
    /// <param name="array">Array of scopes.</param>
    public MeetupScopeCollection(params MeetupScope[] array) {
        _list.AddRange(array);
    }

    #endregion

    #region Member methods

    /// <summary>
    /// Adds the specified <paramref name="scope"/> to the collection.
    /// </summary>
    /// <param name="scope">The scope to be added.</param>
    public void Add(MeetupScope scope) {
        _list.Add(scope);
    }

    /// <summary>
    /// Returns an array of scopes based on the collection.
    /// </summary>
    /// <returns>Array of scopes contained in the location.</returns>
    public MeetupScope[] ToArray() {
        return _list.ToArray();
    }

    /// <summary>
    /// Returns an array of strings representing each scope in the collection.
    /// </summary>
    /// <returns>Array of strings representing each scope in the collection.</returns>
    public string[] ToStringArray() {
        return (from scope in _list select scope.Name).ToArray();
    }

    /// <summary>
    /// Returns an enumerator that iterates through the collection.
    /// </summary>
    /// <returns>An instance of <see cref="IEnumerator{FacebookScope}"/>.</returns>
    public IEnumerator<MeetupScope> GetEnumerator() {
        return _list.GetEnumerator();
    }

    /// <summary>
    /// Returns a string representing the scopea added to the collection using a comma as a separator.
    /// </summary>
    /// <returns>String of scopes separated by a plus sign.</returns>
    public override string ToString() {
        return string.Join("+", from scope in _list select scope.Name);
    }

    IEnumerator IEnumerable.GetEnumerator() {
        return GetEnumerator();
    }

    #endregion

    #region Operator overloading

    /// <summary>
    /// Initializes a new collection based on a single <paramref name="scope"/>.
    /// </summary>
    /// <param name="scope">The scope the collection should be based on.</param>
    /// <returns>A new collection based on a single <paramref name="scope"/>.</returns>
    public static implicit operator MeetupScopeCollection(MeetupScope scope) {
        return new MeetupScopeCollection(scope);
    }

    /// <summary>
    /// Initializes a new collection based on an <paramref name="array"/> of scopes.
    /// </summary>
    /// <param name="array">The array of scopes the collection should be based on.</param>
    /// <returns>A new collection based on an <paramref name="array"/> of scopes.</returns>
    public static implicit operator MeetupScopeCollection(MeetupScope[] array) {
        return new MeetupScopeCollection(array ?? new MeetupScope[0]);
    }

    /// <summary>
    /// Adds support for adding a <paramref name="scope"/> to the <paramref name="collection"/> using the plus operator.
    /// </summary>
    /// <param name="collection">The collection to which <paramref name="scope"/> will be added.</param>
    /// <param name="scope">The scope to be added to the <paramref name="collection"/>.</param>
    public static MeetupScopeCollection operator +(MeetupScopeCollection collection, MeetupScope scope) {
        collection.Add(scope);
        return collection;
    }

    #endregion

}