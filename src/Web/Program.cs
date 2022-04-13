using Web.Extensions;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

if (builder.Environment.IsDevelopment())
{
    builder.Configuration.AddUserSecrets(Assembly.GetExecutingAssembly());
}

var envName = builder.Environment.EnvironmentName;
if (!string.IsNullOrEmpty(envName))
{
    builder.Configuration.AddJsonFile($"appsettings.{envName}.json");
}

builder.Configuration.AddEnvironmentVariables();
builder.Services.AddCustomServiceBuilder(builder.Configuration);
builder.Host.ConfigureLogging(log =>
{
    log.AddEventLog();
    log.AddFile(f =>
    {
        f.FileName = $"File_Log.{DateTime.Now:d}";
    });
});

builder.WebHost.UseIIS();
builder.WebHost.UseIISIntegration();

var app = builder.Build();
app.UseCustomServiceBuilder(app.Environment);
app.Run();
