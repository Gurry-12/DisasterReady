using DisasterReady.WebAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddProjectServices(builder.Configuration)
    .AddSwaggerDocumentation()
    .AddControllers();

var app = builder.Build();

app.ConfigurePipeline();

app.Run();
