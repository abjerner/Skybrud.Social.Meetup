﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Skybrud.Social.Meetup.Fields; 

/// <summary>
/// Class representing a collection of fields in the Meetup API.
/// </summary>
public class MeetupFieldsCollection : IEnumerable<MeetupField> {

    #region Private fields

    private readonly List<MeetupField> _fields = new();

    #endregion

    #region Properties

    /// <summary>
    /// Gets the total number of fields added to the collection.
    /// </summary>
    public int Count => _fields.Count;

    /// <summary>
    /// Gets an array of all the fields added to the collection.
    /// </summary>
    public MeetupField[] Fields => _fields.ToArray();

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new collection based on the specified <paramref name="array"/> of fields.
    /// </summary>
    /// <param name="array">Array of fields.</param>
    public MeetupFieldsCollection(params MeetupField[] array) {
        _fields.AddRange(array);
    }

    #endregion

    #region Member methods

    /// <summary>
    /// Adds the specified <paramref name="field"/> to the collection.
    /// </summary>
    /// <param name="field">The field to be added.</param>
    public void Add(MeetupField field) {
        _fields.Add(field);
    }

    /// <summary>
    /// Returns an array of fields based on the collection.
    /// </summary>
    /// <returns>Array of fields contained in the collection.</returns>
    public MeetupField[] ToArray() {
        return _fields.ToArray();
    }

    /// <summary>
    /// Returns an array of strings representing each field in the collection.
    /// </summary>
    /// <returns>Array of strings representing each field in the collection.</returns>
    public string[] ToStringArray() {
        return (from field in _fields select field.Name).ToArray();
    }

    /// <summary>
    /// Returns an enumerator that iterates through the collection.
    /// </summary>
    /// <returns>An instance of <see cref="IEnumerator{FacebookField}"/>.</returns>
    public IEnumerator<MeetupField> GetEnumerator() {
        return _fields.GetEnumerator();
    }

    /// <summary>
    /// Returns a string representing the fields added to the collection using a comma as a separator.
    /// </summary>
    /// <returns>String of fields separated by a comma.</returns>
    public override string ToString() {
        return string.Join(",", from field in _fields select field.Name);
    }

    IEnumerator IEnumerable.GetEnumerator() {
        return GetEnumerator();
    }

    #endregion

    #region Operators

    /// <summary>
    /// Initializes a new collection based on the specified string of <paramref name="fields"/>.
    /// </summary>
    /// <param name="fields">The string of fields the collection should be based on.</param>
    /// <returns>A new collection based on a string of <paramref name="fields"/>.</returns>
    public static implicit operator MeetupFieldsCollection(string? fields) {
        MeetupFieldsCollection collection = new();
        foreach (string name in (fields ?? string.Empty).Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)) {
            collection.Add(name);
        }
        return collection;
    }

    /// <summary>
    /// Initializes a new collection based on the specified array of fields.
    /// </summary>
    /// <param name="fields">The array of fields the collection should be based on.</param>
    /// <returns>A new collection based on an array of <paramref name="fields"/>.</returns>
    public static implicit operator MeetupFieldsCollection(string[] fields) {
        MeetupFieldsCollection collection = new();
        foreach (string name in fields) {
            collection.Add(name);
        }
        return collection;
    }

    /// <summary>
    /// Initializes a new collection based on the specified <paramref name="field"/>.
    /// </summary>
    /// <param name="field">The field the collection should be based on.</param>
    /// <returns>A new collection based on a single <paramref name="field"/>.</returns>
    public static implicit operator MeetupFieldsCollection(MeetupField field) {
        return new MeetupFieldsCollection(field);
    }

    /// <summary>
    /// Initializes a new collection based on the specified array of <paramref name="fields"/>.
    /// </summary>
    /// <param name="fields">The fields the collection should be based on.</param>
    /// <returns>A new collection based on an array of <paramref name="fields"/>.</returns>
    public static implicit operator MeetupFieldsCollection(MeetupField[] fields) {
        return new MeetupFieldsCollection(fields);
    }

    /// <summary>
    /// Adds support for adding a <paramref name="field"/> to the <paramref name="collection"/> using the plus
    /// operator.
    /// </summary>
    /// <param name="collection">The collection to which <paramref name="field"/> will be added.</param>
    /// <param name="field">The field to be added to the <paramref name="collection"/>.</param>
    public static MeetupFieldsCollection operator +(MeetupFieldsCollection collection, MeetupField field) {
        collection.Add(field);
        return collection;
    }

    #endregion

}