using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Core.Auth.Common.Settings;

public class JwtSettings
{
    public string Secret { get; set; }
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public int AccessTokenExpiryInMinutes { get; set; } = 60 * 24 * 7;
    public int RefreshTokenExpiryInMinutes { get; set; } = 60 * 24 * 7;
    
    public SymmetricSecurityKey GetSymmetricSecurityKey()
    {
        return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Secret));
    }
}