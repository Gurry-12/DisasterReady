using DisasterReady.Application.Services.AbstractServices;
using DisasterReady.Application.Services.ConcreteServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterReady.Application.Extentions
{
    public static class ApplicationServiceCollectionExtentions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAlertService, AlertService>();
            services.AddScoped<IChecklistService, ChecklistService>();
            services.AddScoped<IEmergencyTipService, EmergencyTipService>();
            services.AddScoped<IDisasterTypeService, DisasterTypeService>();
            services.AddScoped<IHouseholdService, HouseholdService>();
            services.AddScoped<IFeedbackService, FeedbackService>();
            services.AddScoped<ILoginService, LoginService>();

            return services;
        }
    }
}
