using DisasterReady.WebAPI.Middleware;

namespace DisasterReady.WebAPI.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static WebApplication ConfigurePipeline(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwaggerDocumentation();
            }

            app.UseHttpsRedirection();

            app.UseMiddleware<GlobalExceptionHandler>();

            app.UseAuthorization();

            app.MapControllers();

            return app;
        }
    }
}
