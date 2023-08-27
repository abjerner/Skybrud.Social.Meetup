# Groups

The Meetup GraphQL API contains an endpoint for getting information about a Meetup group based on the group's URL name. Depending on your GraphQL query, you can request basic information about a group like in the example below:

```cshtml
@using Skybrud.Social.Meetup
@using Skybrud.Social.Meetup.Exceptions
@using Skybrud.Social.Meetup.Models.GraphQl.Groups
@using Skybrud.Social.Meetup.Options.GraphQl
@using Skybrud.Social.Meetup.Responses.GraphQl
@inherits RazorPage<MeetupHttpService>

@try {
    
    // Declare the GraphQL query
    string query = @"query($urlname: String!) { groupByUrlname(urlname: $urlname) { id name } }";

    // Make the request to the Meetup GraphQL API
    MeetupGroupResponse response = Model.GraphQl.GetGroupByUrlName(new MeetupGraphQlOptions {
        Query = query,
        Variables = new Dictionary<string, string> {
            {"urlname", "the-london-umbraco-meetup"}
        }
    });

    // Get the group from the response body
    MeetupGroup group = response.Body.Data.GroupByUrlName;

    <div style="padding: 25px;">
        <h3>Group</h3>
        <table class="table details">
            <tr>
                <th>ID</th>
                <td><code>@group.Id</code></td>
            </tr>
            <tr>
                <th>Name</th>
                <td>@group.Name</td>
            </tr>
        </table>
    </div>

} catch (MeetupHttpException ex) {

    <pre>@ex.Response.StatusCode</pre>
    <pre>@ex.Response.Body</pre>

}
```

This example requests the ID and name of the Meetup group with the `the-london-umbraco-meetup` URL name.

By extending the query, you can request even more information about the group it self, or additional information from one of the group's edges - eg. upcoming events:

```cshtml
@using Skybrud.Social.Meetup
@using Skybrud.Social.Meetup.Exceptions
@using Skybrud.Social.Meetup.Models.GraphQl.Events
@using Skybrud.Social.Meetup.Models.GraphQl.Groups
@using Skybrud.Social.Meetup.Options.GraphQl
@using Skybrud.Social.Meetup.Responses.GraphQl
@inherits RazorPage<MeetupHttpService>

@try {

    // Declare the GraphQL query
    string query = @"
query ($urlname: String!) {
  groupByUrlname(urlname: $urlname) {
    id
    name
    logo {
      id
      baseUrl
    }
    latitude
    longitude
    description
    urlname
    timezone
    city
    state
    country
    zip
    link
    joinMode
    welcomeBlurb
    upcomingEvents(input: {first: 25}) {
      count
      pageInfo {
        endCursor
      }
      edges {
        cursor
        node {
          id
          title
          eventUrl
          description
          shortDescription
          howToFindUs
          venue {
            id
            name
            address
            city
            state
            postalCode
            crossStreet
            country
            neighborhood
            lat
            lng
            zoom
            radius
          }
          status
          dateTime
          duration
          timezone
          endTime
          createdAt
          eventType
          shortUrl
          isOnline
        }
      }
    }
  }
}
";

    // Make the request to the Meetup GraphQL API
    MeetupGroupResponse response = Model.GraphQl.GetGroupByUrlName(new MeetupGraphQlOptions {
        Query = query,
        Variables = new Dictionary<string, string> {
            {"urlname", "the-london-umbraco-meetup"}
        }
    });

    // Get the group from the response body
    MeetupGroup group = response.Body.Data.GroupByUrlName;

    <div style="padding: 25px;">
        <h3>Group</h3>
        <table class="table details">
            <tr>
                <th>ID</th>
                <td><code>@group.Id</code></td>
            </tr>
            <tr>
                <th>Name</th>
                <td>@group.Name</td>
            </tr>
            <tr>
                <th>Latitude</th>
                <td><code>@group.Latitude</code></td>
            </tr>
            <tr>
                <th>Longitude</th>
                <td><code>@group.Longitude</code></td>
            </tr>
        </table>
        @foreach (UpcomingEventsEdge ev in group.UpcomingEvents!.Edges!) {
            <h4>@ev.Node!.Title</h4>
            <table class="table details">
                <tr>
                    <th>ID</th>
                    <td><code>@ev.Node!.Id</code></td>
                </tr>
                <tr>
                    <th>Title</th>
                    <td>@ev.Node!.Title</td>
                </tr>
                <tr>
                    <th>Description</th>
                    <td>@ev.Node!.Description</td>
                </tr>
                <tr>
                    <th>DateTime</th>
                    <td>@ev.Node!.DateTime</td>
                </tr>
                <tr>
                    <th>EndTime</th>
                    <td>@ev.Node!.EndTime</td>
                </tr>
                <tr>
                    <th>TimeZone</th>
                    <td>@ev.Node!.TimeZone</td>
                </tr>
                <tr>
                    <th>EventType</th>
                    <td>@ev.Node!.EventType</td>
                </tr>
            </table>
        }
    </div>

} catch (MeetupHttpException ex) {

    <pre>@ex.Response.StatusCode</pre>
    <pre>@ex.Response.Body</pre>

}
```
