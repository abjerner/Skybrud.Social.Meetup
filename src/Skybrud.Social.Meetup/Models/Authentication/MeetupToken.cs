using System;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Meetup.Models.Authentication; 

/// <summary>
/// Class describing an access token received from the Meetup API.
/// </summary>
public class MeetupToken : MeetupObject {

    #region Properties

    /// <summary>
    /// Gets the token of the authenticated user.
    /// </summary>
    public string AccessToken { get; }

    /// <summary>
    /// Gets a refresh token that can be used to obtain a new access tokens. Refresh tokens are valid until the
    /// user revokes access.
    /// </summary>
    public string RefreshToken { get; }

    /// <summary>
    /// Gets the type of the access token.
    /// </summary>
    public string TokenType { get; }

    /// <summary>
    /// Gets the remaining lifetime on the access token.
    /// </summary>
    public TimeSpan ExpiresIn { get; }

    #endregion

    #region Constructors

    private MeetupToken(JObject obj) : base(obj) {
        AccessToken = obj.GetString("access_token")!;
        RefreshToken = obj.GetString("refresh_token")!;
        TokenType = obj.GetString("token_type")!;
        ExpiresIn = obj.GetDouble("expires_in", TimeSpan.FromSeconds);
    }

    #endregion

    /// <summary>
    /// Parses the specified <paramref name="obj"/> into an instance of <see cref="MeetupToken"/>.
    /// </summary>
    /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
    /// <returns>An instance of <see cref="MeetupToken"/>.</returns>
    [return: NotNullIfNotNull("obj")]
    public static MeetupToken? Parse(JObject? obj) {
        return obj == null ? null : new MeetupToken(obj);
    }

}