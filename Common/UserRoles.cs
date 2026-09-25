using System.Text.Json.Serialization;

namespace CandyOrg.Auth.Common;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum UserRoles
{
    Manager,
    Dispatcher,
    Coordinator,
    Driver
}