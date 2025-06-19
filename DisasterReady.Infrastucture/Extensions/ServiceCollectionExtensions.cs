
using DisasterReady.Infrastructure.Repositories.AbstractRepositories;
using DisasterReady.Infrastucture.ConcreteRepositories;
using DisasterReady.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DisasterReady.Persistence.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Add DbContext
            services.AddDbContext<DisasterReadyDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(DisasterReadyDbContext).Assembly.FullName)
                ));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAlertRepository, AlertRepository>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));


            return services;
        }
    }
} 