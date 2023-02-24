using Microsoft.OpenApi.Models;
using System.Reflection;

namespace ahk.lyra.API.Configurations
{
    public static class SwaggerConfiguration
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Lyra-teste",
                    Version = "v1"
                });
                c.SwaggerGeneratorOptions.Servers =
                    new List<OpenApiServer> {
                    new OpenApiServer {Url = "https://localhost:5000" }
                    };
            });

            return services;
        }

        public static WebApplication UseSwaggerService(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Lyra-test v1"));

            return app;
        }
    }
}
