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
            services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IPlayerService, PlayerService>();

            // MediatR
            // services.AddMediatR(cfg =>
            //     cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));

            services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);
            services.AddAutoMapper(typeof(DependencyInjection).Assembly);


            return services;
        }
    }
}