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

           // Seed additional Users
           if (await context.Users.CountAsync() < 2)
           {
               var users = new List<User>
               {
                   new User
                   {
                       Email = "user1@disasterready.com",
                       PasswordHash = "user1pass",
                       FullName = "John Doe",
                       Location = "City A",
                       Role = UserRoleEnum.User,
                       IsSubscribedToAlerts = true,
                       CreatedAt = DateTime.UtcNow
                   },
                   new User
                   {
                       Email = "user2@disasterready.com",
                       PasswordHash = "user2pass",
                       FullName = "Jane Smith",
                       Location = "City B",
                       Role = UserRoleEnum.User,
                       IsSubscribedToAlerts = false,
                       CreatedAt = DateTime.UtcNow
                   }
               };
               await context.Users.AddRangeAsync(users);
               await context.SaveChangesAsync();
           }

           // Seed Households
           if (!await context.Households.AnyAsync())
           {
               var user1 = await context.Users.FirstOrDefaultAsync(u => u.Email == "user1@disasterready.com");
               var user2 = await context.Users.FirstOrDefaultAsync(u => u.Email == "user2@disasterready.com");
               var households = new List<Household>
               {
                   new Household { UserId = user1?.Id ?? 0, Adults = 2, Children = 1, HasPets = true, HasMedicalNeeds = false, Notes = "Has a dog." },
                   new Household { UserId = user2?.Id ?? 0, Adults = 1, Children = 0, HasPets = false, HasMedicalNeeds = true, Notes = "Requires medication." }
               };
               await context.Households.AddRangeAsync(households);
               await context.SaveChangesAsync();
           }

           // Seed Alerts
           if (!await context.Alerts.AnyAsync())
           {
               var earthquakeType = await context.DisasterTypes.FirstOrDefaultAsync(dt => dt.Name == DisasterTypeEnum.Earthquake);
               var floodType = await context.DisasterTypes.FirstOrDefaultAsync(dt => dt.Name == DisasterTypeEnum.Flood);
               var alerts = new List<Alert>
               {
                   new Alert { Title = "Earthquake Alert", Message = "Strong earthquake detected.", Location = "City A", SeverityLevel = SeverityLevelEnum.High, Region = RegionEnum.Global, IsActive = true, DisasterTypeId = earthquakeType?.Id ?? 0, CreatedAt = DateTime.UtcNow, ExpiresAt = DateTime.UtcNow.AddDays(1) },
                   new Alert { Title = "Flood Warning", Message = "Flooding expected in low-lying areas.", Location = "City B", SeverityLevel = SeverityLevelEnum.Medium, Region = RegionEnum.Global, IsActive = true, DisasterTypeId = floodType?.Id ?? 0, CreatedAt = DateTime.UtcNow, ExpiresAt = DateTime.UtcNow.AddDays(2) }
               };
               await context.Alerts.AddRangeAsync(alerts);
               await context.SaveChangesAsync();
           }

           // Seed Checklists
           if (!await context.Checklists.AnyAsync())
           {
               var user1 = await context.Users.FirstOrDefaultAsync(u => u.Email == "user1@disasterready.com");
               var user2 = await context.Users.FirstOrDefaultAsync(u => u.Email == "user2@disasterready.com");
               var checklists = new List<Checklist>
               {
                   new Checklist { UserId = user1?.Id ?? 0, Title = "Earthquake Prep", Description = "Checklist for earthquake preparedness.", IsCompleted = false },
                   new Checklist { UserId = user2?.Id ?? 0, Title = "Flood Prep", Description = "Checklist for flood preparedness.", IsCompleted = true }
               };
               await context.Checklists.AddRangeAsync(checklists);
               await context.SaveChangesAsync();
           }

           // Seed ChecklistItems
           if (!await context.ChecklistItems.AnyAsync())
           {
               var checklist1 = await context.Checklists.FirstOrDefaultAsync(c => c.Title == "Earthquake Prep");
               var checklist2 = await context.Checklists.FirstOrDefaultAsync(c => c.Title == "Flood Prep");
               var items = new List<ChecklistItem>
               {
                   new ChecklistItem { ChecklistId = checklist1?.Id ?? 0, Title = "Water", Description = "Store enough water.", IsCompleted = false, Priority = PriorityEnum.High },
                   new ChecklistItem { ChecklistId = checklist1?.Id ?? 0, Title = "First Aid Kit", Description = "Prepare a first aid kit.", IsCompleted = true, Priority = PriorityEnum.Medium },
                   new ChecklistItem { ChecklistId = checklist2?.Id ?? 0, Title = "Sandbags", Description = "Place sandbags at doors.", IsCompleted = true, Priority = PriorityEnum.High }
               };
               await context.ChecklistItems.AddRangeAsync(items);
               await context.SaveChangesAsync();
           }

           // Seed Feedback
           if (!await context.Feedbacks.AnyAsync())
           {
               var user1 = await context.Users.FirstOrDefaultAsync(u => u.Email == "user1@disasterready.com");
               var feedbacks = new List<Feedback>
               {
                   new Feedback { UserId = user1?.Id ?? 0, Type = FeedbackTypeEnum.Suggestion, Content = "Add more tips for earthquakes.", SubmittedAt = DateTime.UtcNow },
                   new Feedback { UserId = user1?.Id ?? 0, Type = FeedbackTypeEnum.Bug, Content = "Checklist not saving.", SubmittedAt = DateTime.UtcNow }
               };
               await context.Feedbacks.AddRangeAsync(feedbacks);
               await context.SaveChangesAsync();
           }

           // Seed RecommendationRules
           if (!await context.RecommendationRules.AnyAsync())
           {
               var rules = new List<RecommendationRule>
               {
                   new RecommendationRule { ConditionTag = ConditionTagEnum.Elderly, Recommendation = "Ensure elderly have access to medication." },
                   new RecommendationRule { ConditionTag = ConditionTagEnum.Children, Recommendation = "Prepare toys and comfort items for children." }
               };
               await context.RecommendationRules.AddRangeAsync(rules);
               await context.SaveChangesAsync();
           }
       }
   }
} 