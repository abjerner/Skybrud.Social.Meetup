using System.Collections.Generic;
using Skybrud.Social.Meetup.Options.GraphQl;
using Skybrud.Social.Meetup.Responses.GraphQl;

namespace Skybrud.Social.Meetup.Endpoints; 

/// <summary>
/// Implementation of the <strong>GraphQL</strong> endpoint.
/// </summary>
public class MeetupGraphQlEndpoint {

    #region Properties

    /// <summary>
    /// Gets a reference to the parent service.
    /// </summary>
    public MeetupHttpService Service { get; }

    /// <summary>
    /// Gets a reference to the raw endpoint.
    /// </summary>
    public MeetupGraphQlRawEndpoint Raw => Service.Client.GraphQl;

    #endregion

    #region Constructors

    internal MeetupGraphQlEndpoint(MeetupHttpService service) {
        Service = service;
    }

    #endregion

    #region Member methods

    /// <summary>
    /// Returns information about the group matching the specified <paramref name="query"/>.
    /// </summary>
    /// <param name="query">The GraphQL query.</param>
    /// <returns>An instance of <see cref="MeetupGroupResponse"/> representing the response from the API.</returns>
    public MeetupGroupResponse GetGroupByUrlname(string query) {
        return GetGroupByUrlname(new MeetupGraphQlOptions(query));
    }

    /// <summary>
    /// Returns information about the group matching the specified <paramref name="query"/>.
    /// </summary>
    /// <param name="query">The GraphQL query.</param>
    /// <param name="variables">A dictionary with variable to be used with the query.</param>
    /// <returns>An instance of <see cref="MeetupGroupResponse"/> representing the response from the API.</returns>
    public MeetupGroupResponse GetGroupByUrlname(string query, Dictionary<string, string>? variables) {
        return GetGroupByUrlname(new MeetupGraphQlOptions(query, variables));
    }

    /// <summary>
    /// Returns a group matching the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="MeetupGroupResponse"/> representing the response from the API.</returns>
    public MeetupGroupResponse GetGroupByUrlname(MeetupGraphQlOptions options) {
        return new MeetupGroupResponse(Raw.GetGroupByUrlname(options));
    }

    #endregion

}