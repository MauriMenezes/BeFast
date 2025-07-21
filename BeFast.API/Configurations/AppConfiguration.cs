using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeFast.API.Configurations
{
    public static class AppConfiguration
    {
        public static WebApplication AddAppConfiguration(this WebApplication app)
        {
            // Configure the application pipeline
            app.UseHttpsRedirection();
            app.UseRouting();
            // app.UseAuthorization();

            app.MapControllers();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BeFast API v1"));
            }

            return app;
        }

    }
}