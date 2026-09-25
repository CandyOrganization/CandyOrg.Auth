using System.Text.Json.Serialization;
using CandyOrg.Auth.Common;

namespace CandyOrg.Auth.Tokens;

public class TokenPayload
{
    public required Guid UserId { get; set; }
    [JsonPropertyName(System.Security.Claims.ClaimTypes.Role)]
    public required UserRoles UserRole { get; set; }
    [JsonPropertyName("exp")]
    public required long Exp { get; set; }
    [JsonPropertyName("iss")]
    public required string Iss { get; set; }
    [JsonPropertyName("aud")]
    public required string Aud { get; set; }
}