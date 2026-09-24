using Core.Auth.Common.Settings;
using Core.Auth.Tokens;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Auth;

public static class DependencyInjection
{
    public static IServiceCollection AddJwtSettings(this IServiceCollection services, IConfigurationSection configurationSection)
    {
        var jwtSettings = configurationSection.Get<JwtSettings>();
        if (jwtSettings is null)
        {
            throw new ArgumentNullException(nameof(jwtSettings));
        }

        return services.AddSingleton(jwtSettings);
    }

    public static IServiceCollection AddTokenBuilder(this IServiceCollection services)
    {
        return services.AddSingleton<TokenBuilder>();
    }
}