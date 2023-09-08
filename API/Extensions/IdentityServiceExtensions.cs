using System.Text;
using Core.Entities.Identity;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace API.Extensions
{
    public static class IdentityServiceExtensions
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<AppIdentityDbContext>(opt =>
            {
                opt.UseNpgsql(config.GetConnectionString("IdentityConnection"));
            });

            services.AddIdentityCore<AppUser>(opt =>
            {
                // can change identity options like password requirements, Lockout password attempts, etc..
            })
            .AddEntityFrameworkStores<AppIdentityDbContext>() // required to store our users in a database (EF core)
            .AddSignInManager<SignInManager<AppUser>>(); // we'll use this for signing in

            // Authentication always comes before authorization as we can't authorize someone to do something without authenticating them
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => // Options here are saying what do we want to do to validate this token
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true, // If false then any JWT will be accepted, true means only one signed by our server can be accepted
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Token:Key"])), // The same we used inside our TokenService
                        ValidIssuer = config["Token:Issuer"],
                        ValidateIssuer = true, // Makes sure the token contains the issuer from our server
                        ValidateAudience = false
                    };
                });


            services.AddAuthorization();

            return services;
        }
    }
}