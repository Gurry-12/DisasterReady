using Microsoft.OpenApi.Models;

namespace DisasterReady.WebAPI.Extensions
{
    public static class SwaggerServiceExtensions
    {
        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options =>
            {
                var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);

                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "DisasterReady API",
                    Version = "v1",
                    Description = "API documentation for DisasterReady"
                });
            });
            return services;
        }

        public static WebApplication UseSwaggerDocumentation(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            app.MapGet("/", ctx =>
            {
                ctx.Response.Redirect("/swagger");
                return Task.CompletedTask;
            });
            return app;
        }
    }
}
