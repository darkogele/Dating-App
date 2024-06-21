using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace API.Extensions;

public static class IdentityServiceExtensions
{
    public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
          .AddJwtBearer(options =>
          {
              var tokenKey = config["TokenKey"]
                    ?? throw new Exception("TokenKey is missing");
              var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey));

              options.TokenValidationParameters = new TokenValidationParameters
              {
                  ValidateIssuerSigningKey = true,
                  IssuerSigningKey = key,
                  ValidateIssuer = false,
                  ValidateAudience = false,
                  // ValidateLifetime = true,
                  // ClockSkew = TimeSpan.Zero,
              };
          });

        return services;
    }
}