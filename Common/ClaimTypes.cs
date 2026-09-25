using System.Text.Json.Serialization;

namespace CandyOrg.Auth.Common;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ClaimTypes
{
    UserId
}