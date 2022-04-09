using Web.Extensions;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

if (builder.Environment.IsDevelopment())
{
    builder.Configuration.AddUserSecrets(Assembly.GetExecutingAssembly());
}

var envName = builder.Environment.EnvironmentName;

if (!string.IsNullOrEmpty(envName)) 
    builder.Configuration.AddJsonFile($"appsettings.{envName}.json");

builder.Configuration.AddEnvironmentVariables();
// Add services to the container.
builder.Services.AddCustomServiceBuilder(builder.Configuration);

builder.Host.ConfigureLogging(log =>
{
    log.AddEventLog();
    log.AddFile(f =>
    {
        f.FileName = $"File_Log.{DateTime.Now:d}";
    });
});

var app = builder.Build();

app.UseCustomServiceBuilder(app.Environment);

app.Run();
