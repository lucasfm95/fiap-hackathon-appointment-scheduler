using System.Text;
using Fiap.Hackathon.AppointmentScheduler.Application;
using Fiap.Hackathon.AppointmentScheduler.Application.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Fiap.Hackathon.AppointmentScheduler.Api;

public static class ConfigureAuthExtensions
{
    public static void ConfigureAuth(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<AuthTokenService>();
        
        var jwtTokenOptions = builder.Configuration.GetSection("JwtTokenOptions").Get<JwtTokenOptions>();
        var key = Encoding.ASCII.GetBytes(jwtTokenOptions.Secret);

        builder.Services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

    }
}