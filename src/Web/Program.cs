using NLog;
using NLog.Web;
using Web.Extensions;
var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();

logger.Debug("Initialized main method");

try
{
    var builder = WebApplication.CreateBuilder(args);
    builder.Services.ConfigureCustomServices(builder);

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

