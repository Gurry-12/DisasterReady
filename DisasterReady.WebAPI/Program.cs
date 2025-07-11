using DisasterReady.Application.Services.AbstractServices;
using DisasterReady.Application.Services.ConcreteServices;
using DisasterReady.Infrastructure.Repositories.AbstractRepositories;
using DisasterReady.Infrastucture.ConcreteRepositories;
using DisasterReady.Persistence.Data;
using DisasterReady.Persistence.Extensions;
using DisasterReady.WebAPI.Middleware;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Add Application Services
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAlertService, AlertService>();
builder.Services.AddScoped<IChecklistService, ChecklistService>();
builder.Services.AddScoped<IEmergencyTipService, EmergencyTipService>();
builder.Services.AddScoped<IDisasterTypeService, DisasterTypeService>();
builder.Services.AddScoped<IHouseholdService, HouseholdService>();
builder.Services.AddScoped<IFeedbackService, FeedbackService>();

// Add Persistence Services
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddDbContext<DisasterReadyDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

// Initialize Database
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<DisasterReadyDbContext>();
    //await DbInitializer.InitializeAsync(context);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapGet("/", context => {
        context.Response.Redirect("/swagger");
        return Task.CompletedTask;
    });
}

app.UseHttpsRedirection();

// Add Global Exception Handler
app.UseMiddleware<GlobalExceptionHandler>();

app.UseAuthorization();

app.MapControllers();

app.Run();
