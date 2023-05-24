using Microsoft.Extensions.DependencyInjection;
using Service.Services.Interfaces;
using Service.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddServiceLayer(this IServiceCollection services)
        {

            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ILocationService, LocationService>();
            services.AddScoped<ISubLocationService, SubLocationService >();
            services.AddScoped<IDriverService, DriverService >();
            //services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICurrentUserService, CurrentUserSrvice>();
            services.AddHttpContextAccessor();
            return services;
        }   
    }
}