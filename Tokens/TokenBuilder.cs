using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using CandyOrg.Auth.Common.Settings;
using Microsoft.IdentityModel.Tokens;

namespace CandyOrg.Auth.Tokens;

public class TokenBuilder
{
    private JwtSettings _jwtSettings;

    public TokenBuilder(JwtSettings jwtSettings)
    {
        _jwtSettings = jwtSettings;
    }
    
    public string Build(List<Claim> claims, int expireInMinutes)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = _jwtSettings.GetSymmetricSecurityKey();

        var token = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(expireInMinutes),
            signingCredentials: new SigningCredentials(
                key,
                SecurityAlgorithms.HmacSha256)
        );

        return tokenHandler.WriteToken(token);
    }
}