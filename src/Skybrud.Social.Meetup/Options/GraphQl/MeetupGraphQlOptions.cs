using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Options;

namespace Skybrud.Social.Meetup.Options.GraphQl;

/// <summary>
/// Options for making a GraphQL request to the meetup.com API.
/// </summary>
public class MeetupGraphQlOptions : IHttpRequestOptions {

    #region Properties

    /// <summary>
    /// Gets or sets the GraphQL query of the request.
    /// </summary>
    public string Query { get; set; } = null!;

    /// <summary>
    /// Gets or sets the GraphQL variables of the request.
    /// </summary>
    public Dictionary<string, string> Variables { get; set; }

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance with default options.
    /// </summary>
    public MeetupGraphQlOptions() {
        Variables = new Dictionary<string, string>();
    }

    /// <summary>
    /// Initializes a new instance with the specified <paramref name="query"/>.
    /// </summary>
    /// <param name="query">The GraphQL query.</param>
    public MeetupGraphQlOptions(string query) {
        Query = query;
        Variables = new Dictionary<string, string>();
    }

    /// <summary>
    /// Initializes a new instance with the specified <paramref name="query"/> and <paramref name="variables"/>.
    /// </summary>
    /// <param name="query">The GraphQL query.</param>
    /// <param name="variables">A dictionary with variable to be used with the query.</param>
    public MeetupGraphQlOptions(string query, Dictionary<string, string>? variables) {
        Query = query;
        Variables = variables ?? new Dictionary<string, string>();
    }

    #endregion

    #region Member methods

    /// <inheritdoc />
    public IHttpRequest GetRequest() {

        // Validate required parameters
        if (string.IsNullOrWhiteSpace(Query)) throw new PropertyNotSetException(nameof(Query));

        // Initialize the POST body
        JObject body = new() {
            {"query", Query}
        };

        // Append the variables if specified
        if (Variables is { Count: > 0 }) body.Add("variables", JObject.FromObject(Variables));

        // Initialize a new POST request
        return HttpRequest.Post("/gql", body);

    }

    #endregion

}