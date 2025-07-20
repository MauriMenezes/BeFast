using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeFast.Application.Interfaces;
using BeFast.Application.Services;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace BeFast.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // Services
            services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
            // services.AddScoped<IUserService, UserService>();

            // Adicione outros services aqui
            // services.AddScoped<IProductService, ProductService>();
            // services.AddScoped<IOrderService, OrderService>();

            // MediatR
            // services.AddMediatR(cfg =>
            //     cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));

            // FluentValidation
            services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);

            // AutoMapper (se estiver usando)
            // services.AddAutoMapper(typeof(DependencyInjection).Assembly);

            return services;
        }
    }
}