using DevFreela.Shared.Models.UI;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Devfreela.Aplication.Extensions
{
    public static class JwtExtensions
    {
        public static void ConfigureJwt(this IServiceCollection services, ApiSettings apiSettings)
        {
            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,

                        ValidIssuer = apiSettings.JWT.Issuer,
                        ValidAudience = apiSettings.JWT.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(apiSettings.JWT.Key))
                    };
                });
        }
    }
}
