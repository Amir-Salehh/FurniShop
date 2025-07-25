﻿using FurniShop.Application.Interfaces;
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
            service.AddScoped<IProductService, ProductService>();
            service.AddScoped<ICategoryService, CategoryService>();
            service.AddScoped<IDiscountCodeService, DiscountCodeService>();

            // Infra Layer
            service.AddScoped<IUserRepository, UserRepository>();
            service.AddScoped<ICategoryRepository, CategoryRepository>();
            service.AddScoped<IProductRepository, ProductRepository>();
            service.AddScoped<IDiscountCodeRepository, DiscountCodeRepository>();
            service.AddScoped<IAttributeRepository, AttributeRepository>();
            service.AddScoped<IBankCartRepository, BankCartRepository>();

            service.AddHttpContextAccessor();
        }
    }
}
