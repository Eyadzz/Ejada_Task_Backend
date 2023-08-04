using System.Text;
using Application.Contracts.Authentication;
using Application.Contracts.Mailing;
using Application.Contracts.Services;
using Infrastructure.Authentication;
using Infrastructure.Mailing;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ICurrentUserService, CurrentUserService>();
        
        services.AddTransient<IJwtProvider, JwtProvider>();
        services.AddTransient<IPasswordManager, PasswordManager>();
        
        services.AddTransient<IMailSender, MailSender>();
        
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(
                o => o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:SecretKey"]!)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                }
            );

        return services;
    }
}
