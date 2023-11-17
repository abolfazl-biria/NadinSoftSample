using Common.Configurations;
using Domain.Entities.Users;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Persistence;
using System.Text;

namespace EndPoint.Api.Api.Extensions.DependencyInjection;

public static class IdentityInjection
{
    public static IServiceCollection AddConfiguredIdentity(this IServiceCollection services,
        IConfiguration configuration)
    {
        JwtConfig.Secret = configuration["JWT:Secret"]!;
        JwtConfig.ValidAudience = configuration["JWT:ValidAudience"]!;
        JwtConfig.ValidIssuer = configuration["JWT:ValidIssuer"]!;

        services.AddIdentity<MyUser, MyRole>(options =>
            {
                options.User.RequireUniqueEmail = false;

                options.Password.RequiredUniqueChars = 0;

                options.Password.RequiredLength = 6;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;

                //Lokout Setting
                options.Lockout.MaxFailedAccessAttempts = 3;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMilliseconds(10);

                //SignIn Setting
                options.SignIn.RequireConfirmedAccount = false;
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;

            })
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();

        services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })

            // Adding Jwt Bearer
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = JwtConfig.ValidAudience,
                    ValidIssuer = JwtConfig.ValidIssuer,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtConfig.Secret))
                };
            });

        return services;
    }
}