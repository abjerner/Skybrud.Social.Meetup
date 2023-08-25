using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.Meetup.Models.Members;

namespace Skybrud.Social.Meetup.Responses.Members; 

/// <summary>
/// Class representing a response of a call to get information about a <see cref="MeetupMember"/>.
/// </summary>
public class MeetupGetMemberResponse : MeetupResponse<MeetupMember> {

    #region Constructors

    private MeetupGetMemberResponse(IHttpResponse response) : base(response) {
        Body = ParseJsonObject(response.Body, MeetupMember.Parse)!;
    }

    #endregion

    #region Static methods

    /// <summary>
    /// Parses the specified <paramref name="response"/> into an instance of <see cref="MeetupGetMemberResponse"/>.
    /// </summary>
    /// <param name="response">The instance of <see cref="IHttpResponse"/> representing the raw response.</param>
    /// <returns>An instance of <see cref="MeetupGetMemberResponse"/> representing the response.</returns>
    public static MeetupGetMemberResponse ParseResponse(IHttpResponse response) {
        if (response == null) throw new ArgumentNullException(nameof(response));
        return new MeetupGetMemberResponse(response);
    }

    #endregion

}