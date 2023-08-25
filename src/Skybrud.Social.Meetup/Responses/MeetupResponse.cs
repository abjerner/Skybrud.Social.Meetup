using System.Net;
using Skybrud.Essentials.Http;
using Skybrud.Social.Meetup.Exceptions;

namespace Skybrud.Social.Meetup.Responses; 

/// <summary>
/// Class representing a response from the Meetup API.
/// </summary>
public class MeetupResponse : HttpResponseBase {

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="response"/>.
    /// </summary>
    /// <param name="response">The instance of <see cref="IHttpResponse"/> representing the raw response.</param>
    protected MeetupResponse(IHttpResponse response) : base(response) {

        // Skip error checking if the server responds with an OK status code
        if (response.StatusCode == HttpStatusCode.OK) return;

        throw new MeetupHttpException(response);

    }

}

/// <summary>
/// Class representing a response from the Meetup API.
/// </summary>
public class MeetupResponse<T> : MeetupResponse {

    #region Properties

    /// <summary>
    /// Gets the body of the response.
    /// </summary>
    public T Body { get; protected set; } = default!;

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="response"/>.
    /// </summary>
    /// <param name="response">The instance of <see cref="IHttpResponse"/> representing the raw response.</param>
    protected MeetupResponse(IHttpResponse response) : base(response) { }

    #endregion

}