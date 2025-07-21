using Microsoft.OpenApi.Models;

namespace BeFast.API.Configurations
{
    public static class ApiConfiguration
    {
        public static IServiceCollection AddApiConfiguration(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                   new OpenApiInfo
                   {
                       Title = "BeFast API",
                       Description = "BeFast API Documentation",
                       Version = "v1",
                   });

                // c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                // {
                //     In = ParameterLocation.Header,
                //     Description = "Please enter token",
                //     Name = "Authorization",
                //     Type = SecuritySchemeType.Http,
                //     BearerFormat = "JWT",
                //     Scheme = "bearer"
                // });
            });

            return services;
        }
    }
}
