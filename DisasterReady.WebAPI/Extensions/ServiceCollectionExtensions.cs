using DisasterReady.Application.Extentions;
using DisasterReady.Persistence.Data;
using DisasterReady.Persistence.Extensions;
using DisasterReady.Persistence.Extentions;
using DisasterReady.WebAPI.Filters;
using Microsoft.EntityFrameworkCore;

namespace DisasterReady.WebAPI.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddProjectServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Application layer
            services.AddApplicationServices();

            // Infrastructure layer
            services.AddInfrastructureServices();

            // Persistence layer + DbContext
            services.AddPersistenceServices(configuration);
            services.AddDbContext<DisasterReadyDbContext>(options =>
                options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));

            // Controllers with global filter
            services.AddControllers(options =>
            {
                options.Filters.Add<ApiResponseFilter>();
            });


            return services;
        }
    }
}
