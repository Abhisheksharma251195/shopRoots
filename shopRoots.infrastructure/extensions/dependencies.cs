using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using shopRoots.infrastructure.helpers;
using shopRoots.infrastructure.services;
using shopRootsAdmin.core.interfaces;
using shopRootsAdmin.core.models;

namespace shopRoots.infrastructure.extensions
{
   public static class dependencies
    {
        public static IServiceCollection AddDependencies(this IServiceCollection service) {
            service.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            service.AddScoped(typeof(DbContext), typeof(dbHelper));
            service.AddScoped<IUserService, userService>();
            service.AddScoped<IAddressService, AddressService>();
            service.AddScoped<IAuthentication, AuthenticationService>();
            service.AddScoped<ILogInService, LogInService>();
            service.AddScoped<Ilogger, LoggerService>();

            return service;
        }
        public static IServiceCollection AddDatabaseDeveloperPageExceptionFilter(this IServiceCollection services) {

            return services; 
        }
    }
}
