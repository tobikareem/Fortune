using NLog;
using NLog.Web;
using Web.Extensions;
using Azure.Identity;
var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();

logger.Debug("Initialized main method");

try
{
    var builder = WebApplication.CreateBuilder(args);
    builder.Services.AddCustomServiceBuilder(builder);

    var app = builder.Build();
    app.UseCustomServiceBuilder(app.Environment);
    app.Run();
}
catch (Exception e)
{
    logger.Error(e, "Stopped program because of exception");
    throw;
}
finally
{
    LogManager.Shutdown();
}

