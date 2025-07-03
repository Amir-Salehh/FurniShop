using FurniShop.Application.Interfaces;
using FurniShop.Application.Services;
using FurniShop.Domain.Interfaces;
using Infra.Data.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurniShop.Infra.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection service)
        {
            // Application Layer
            service.AddScoped<IUserService, UserService>();

            // Infra Layer
            service.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
