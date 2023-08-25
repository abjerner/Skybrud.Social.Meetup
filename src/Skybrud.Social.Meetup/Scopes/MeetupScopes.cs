namespace Skybrud.Social.Meetup.Scopes; 

/// <summary>
/// Static class with properties representing scopes of available for the Meetup API.
/// </summary>
/// <see>
///     <cref>https://www.meetup.com/meetup_api/auth/#oauth2-scopes</cref>
/// </see>
public static class MeetupScopes {

    /// <summary>
    /// Granted by default. Gives access to basic Meetup group info and creating and editing Events and RSVP's, posting photos in version 2 API's and below.
    /// </summary>
    public static readonly MeetupScope Basic = new MeetupScope(
        "basic",
        "Gives access to basic Meetup group info and creating and editing Events and RSVP's, posting photos in version 2 API's and below."
    );

    /// <summary>
    /// Replaces the <strong>one hour</strong> expiry time from oauth2 tokens with a limit of up to <strong>two weeks</strong>.
    /// </summary>
    public static readonly MeetupScope Ageless = new MeetupScope(
        "ageless",
        "Replaces the <strong>one hour</strong> expiry time from oauth2 tokens with a limit of up to <strong>two weeks</strong>."
    );

    /// <summary>
    /// Allows the authorized application to create and make modifications to events in your Meetup groups on your behalf.
    /// </summary>
    public static readonly MeetupScope EventManagement = new MeetupScope(
        "event_management",
        "Allows the authorized application to create and make modifications to events in your Meetup groups on your behalf."
    );

    /// <summary>
    /// Allows the authorized application to edit the settings of groups you organize on your behalf.
    /// </summary>
    public static readonly MeetupScope GroupEdit = new MeetupScope(
        "group_edit",
        "Allows the authorized application to edit the settings of groups you organize on your behalf."
    );

    /// <summary>
    /// Allows the authorized application to create, modify and delete group content on your behalf.
    /// </summary>
    public static readonly MeetupScope GroupContentEdit = new MeetupScope(
        "group_content_edit",
        "Allows the authorized application to create, modify and delete group content on your behalf."
    );

    /// <summary>
    /// Allows the authorized application to join new Meetup groups on your behalf.
    /// </summary>
    public static readonly MeetupScope GroupJoin = new MeetupScope(
        "group_join",
        "Allows the authorized application to join new Meetup groups on your behalf."
    );

    /// <summary>
    /// Enables Member to Member messaging (this is now deprecated).
    /// </summary>
    public static readonly MeetupScope Messaging = new MeetupScope(
        "messaging",
        "Enables Member to Member messaging (this is now deprecated)."
    );

    /// <summary>
    /// Allows the authorized application to edit your profile information on your behalf.
    /// </summary>
    public static readonly MeetupScope ProfileEdit = new MeetupScope(
        "profile_edit",
        "Allows the authorized application to edit your profile information on your behalf."
    );

    /// <summary>
    /// Allows the authorized application to block and unblock other members and submit abuse reports on your behalf.
    /// </summary>
    public static readonly MeetupScope Reporting = new MeetupScope(
        "reporting",
        "Allows the authorized application to block and unblock other members and submit abuse reports on your behalf."
    );

    /// <summary>
    /// Allows the authorized application to RSVP you to events on your behalf.
    /// </summary>
    public static readonly MeetupScope Rsvp = new MeetupScope(
        "rsvp",
        "Allows the authorized application to RSVP you to events on your behalf."
    );


}