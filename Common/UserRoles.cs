using System.Text.Json.Serialization;

namespace Core.Auth.Common;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum UserRoles
{
    User,
    Admin
}