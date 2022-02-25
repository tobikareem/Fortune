

namespace Web.Extensions
{
    internal static class DependentServiceCollection
    {
        internal static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            // Add services to the container.
            services.AddRazorPages();
            services.Configure<RouteOptions>(options => {
                options.AppendTrailingSlash = true;
                options.LowercaseUrls = true;
                options.LowercaseQueryStrings = true;
            });

            services.AddHealthChecks();
            return services;
        }
    }
}
