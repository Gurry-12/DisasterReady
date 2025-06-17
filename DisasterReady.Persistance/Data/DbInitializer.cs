using DisasterReady.Domain.Entities;
using DisasterReady.Shared.Enums;
using Microsoft.EntityFrameworkCore;

namespace DisasterReady.Persistence.Data
{
    public static class DbInitializer
    {
        public static async Task InitializeAsync(DisasterReadyDbContext context)
        {
            // Ensure database is created
            await context.Database.EnsureCreatedAsync();

            // Seed Disaster Types if they don't exist
            if (!await context.DisasterTypes.AnyAsync())
            {
                var disasterTypes = new List<DisasterType>
                {
                    new DisasterType { Name = DisasterTypeEnum.Earthquake, Description = "Seismic activity causing ground shaking", Region = RegionEnum.Global },
                    new DisasterType { Name = DisasterTypeEnum.Flood, Description = "Water overflow from rivers, lakes, or oceans", Region = RegionEnum.Global },
                    new DisasterType { Name = DisasterTypeEnum.Cyclone, Description = "Tropical cyclone with strong winds", Region = RegionEnum.Global },
                    new DisasterType { Name = DisasterTypeEnum.Wildfire, Description = "Uncontrolled fire in vegetation", Region = RegionEnum.Global },
                    new DisasterType { Name = DisasterTypeEnum.Tsunami, Description = "Series of ocean waves caused by underwater earthquakes", Region = RegionEnum.Global },
                    new DisasterType { Name = DisasterTypeEnum.Blackout, Description = "Power outage affecting large areas", Region = RegionEnum.Global },
                    new DisasterType { Name = DisasterTypeEnum.Landslide, Description = "Mass movement of rock, earth, or debris", Region = RegionEnum.Global },
                    new DisasterType { Name = DisasterTypeEnum.Heatwave, Description = "Extended period of extreme heat", Region = RegionEnum.Global }
                };

                await context.DisasterTypes.AddRangeAsync(disasterTypes);
                await context.SaveChangesAsync();
            }

            // Seed Emergency Tips if they don't exist
            if (!await context.EmergencyTips.AnyAsync())
            {
                var emergencyTips = new List<EmergencyTip>
                {
                    new EmergencyTip { TipTitle = "Earthquake Safety", Description = "Drop, Cover, and Hold On during an earthquake", DisasterType = DisasterTypeEnum.Earthquake },
                    new EmergencyTip { TipTitle = "Flood Safety", Description = "Move to higher ground immediately during floods", DisasterType = DisasterTypeEnum.Flood },
                    new EmergencyTip { TipTitle = "Cyclone Preparedness", Description = "Stock up on supplies and secure outdoor items", DisasterType = DisasterTypeEnum.Cyclone },
                    new EmergencyTip { TipTitle = "Wildfire Evacuation", Description = "Follow evacuation orders and have a go-bag ready", DisasterType = DisasterTypeEnum.Wildfire },
                    new EmergencyTip { TipTitle = "Tsunami Safety", Description = "Move to higher ground immediately when tsunami warning is issued", DisasterType = DisasterTypeEnum.Tsunami }
                };

                await context.EmergencyTips.AddRangeAsync(emergencyTips);
                await context.SaveChangesAsync();
            }

            // Seed Admin User if no users exist
            if (!await context.Users.AnyAsync())
            {
                var adminUser = new User
                {
                    Email = "admin@disasterready.com",
                    PasswordHash = "admin123", // In real app, this should be hashed
                    FullName = "System Administrator",
                    Location = "Global",
                    Role = UserRoleEnum.Admin,
                    IsSubscribedToAlerts = true,
                    CreatedAt = DateTime.UtcNow
                };

                await context.Users.AddAsync(adminUser);
                await context.SaveChangesAsync();
            }
        }
    }
} 