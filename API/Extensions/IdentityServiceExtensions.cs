using Core.Entities.Identity;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions
{
    public static class IdentityServiceExtensions
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<AppIdentityDbContext>(opt =>
            {
                opt.UseSqlite(config.GetConnectionString("IdentityConnection"));
            });

            services.AddIdentityCore<AppUser>(opt =>
            {
                // can change identity options like password requirements, Lockout password attempts, etc..
            })
            .AddEntityFrameworkStores<AppIdentityDbContext>() // required to store our users in a database (EF core)
            .AddSignInManager<SignInManager<AppUser>>(); // we'll use this for signing in

            // Authentication always comes before authorization as we can't authorize someone to do something without authenticating them
            services.AddAuthentication();
            services.AddAuthorization();

            return services;
        }
    }
}