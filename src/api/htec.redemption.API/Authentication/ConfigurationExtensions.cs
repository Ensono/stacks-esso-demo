using Microsoft.Extensions.Configuration;

namespace htec.redemption.API.Authentication
{
    public static class ConfigurationExtensions
    {
        public static IConfigurationSection GetJwtBearerAuthenticationConfigurationSection(this IConfiguration configuration) =>
            configuration.GetSection("JwtBearerAuthentication");
    }
}
