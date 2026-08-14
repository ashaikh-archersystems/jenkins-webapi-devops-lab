using JenkinsWebApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddScoped<IEmployeeService, EmployeeService>();

var app = builder.Build();

app.MapControllers();

app.MapGet("/health", () =>
{
    return Results.Ok("Application Healthy");
});

app.MapGet("/version", () =>
{
    return Results.Ok(new
    {
        Version = "1.0.0",
        Application = "JenkinsWebApi"
    });
});

app.Run();
