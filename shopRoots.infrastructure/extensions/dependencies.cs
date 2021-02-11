using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using shopRoots.infrastructure.services;
using shopRootsAdmin.core.interfaces;
using shopRootsAdmin.core.models;

namespace shopRoots.infrastructure.extensions
{
   public static class dependencies
    {
        public static IServiceCollection AddDependencies(this IServiceCollection service) {
            service.AddScoped<IUserService, userService>();
            service.AddScoped<IAddressService, AddressService>();

            return service;
        }
        public static IServiceCollection AddDatabaseDeveloperPageExceptionFilter(this IServiceCollection services) {

            return services; 
        }
    }
}
