var builder = WebApplication.CreateBuilder(args);

// add services

builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
});

var app = builder.Build();

// configure pipeline

app.MapCarter();

app.Run();
