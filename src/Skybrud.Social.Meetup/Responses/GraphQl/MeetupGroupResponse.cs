using Skybrud.Essentials.Http;
using Skybrud.Social.Meetup.Models.GraphQl;

namespace Skybrud.Social.Meetup.Responses.GraphQl; 

/// <summary>
/// Class representing a response with information about a Meetup group.
/// </summary>
public class MeetupGroupResponse  : MeetupResponse<MeetupGraphQlGroupResult> {

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="response"/>.
    /// </summary>
    /// <param name="response">The instance of <see cref="IHttpResponse"/> representing the raw response.</param>
    public MeetupGroupResponse(IHttpResponse response) : base(response) {
        Body = ParseJsonObject(response.Body, MeetupGraphQlGroupResult.Parse)!;
    }

}