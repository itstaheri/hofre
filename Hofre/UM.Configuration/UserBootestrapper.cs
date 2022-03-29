using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UM.Application;
using UM.Application.Contract.User;
using UM.Application.Contract.UserRole;
using UM.Domain.UserAgg;
using UM.Domain.UserRoleAgg;
using UM.Infrastracture.Efcore;
using UM.Infrastracture.Efcore.Repositories;

namespace UM.Configuration
{
    public class UserBootestrapper
    {
        public static void Configuration(IServiceCollection services, string ConnectionString)
        {
            services.AddDbContext<UserContext>(x => { x.UseSqlServer(ConnectionString); });
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserApplication, UserApplication>(); 
            services.AddTransient<IUserRoleRepository, UserRoleRepository>();
            services.AddTransient<IUserRoleApplication, UserRoleApplication>();
        }
            
    }
}
