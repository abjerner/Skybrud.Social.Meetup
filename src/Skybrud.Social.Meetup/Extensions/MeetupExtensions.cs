using System;
using System.Globalization;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Time;
using Skybrud.Essentials.Time.Xml;

namespace Skybrud.Social.Meetup.Extensions; 

internal static class MeetupExtensions {

    internal static bool TryParse(string iso8601, out DateTimeOffset result) {
        return DateTimeOffset.TryParseExact(iso8601, DateTimeFormats, CultureInfo.InvariantCulture, DateTimeStyles.None, out result);
    }

    internal static readonly string[] DateTimeFormats = {
        "yyyy-MM-ddTHH:mm:ssZ",
        "yyyy-MM-ddTHH:mm:ssK",
        "yyyy-MM-ddTHH:mm:ss.fffZ",
        "yyyy-MM-ddTHH:mm:ss.fffK",
        "yyyy-MM-ddTHH:mmZ",
        "yyyy-MM-ddTHH:mmK"
    };

    internal static EssentialsTime? GetEssentialsTime(this JObject json, string propertyName) {

        JToken? value = json?.GetValue(propertyName);

        switch (value?.Type) {

            case JTokenType.String:
                string str = (string) value;
                if (string.IsNullOrWhiteSpace(str)) return null;
                try {
                    return DateTimeOffset.ParseExact(str, DateTimeFormats, CultureInfo.InvariantCulture, DateTimeStyles.None);
                } catch (Exception ex) {
                    throw new Exception($"Failed parsing value of the '{propertyName}' property: {value}", ex);
                }

            default:
                return null;

        }

    }

    internal static TimeSpan? GetTimeSpanOrNull(this JObject json, string propertyName)  {
        JToken? value = json?.GetValue(propertyName);
        return value?.Type switch {
            JTokenType.String => XmlSchemaUtils.ParseDuration((string)value),
            _ => null
        };
    }

}