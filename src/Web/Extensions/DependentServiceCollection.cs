
using Core.Interfaces.Services;
using Core.Interfaces.Repository;
using Shared.Services;


namespace Web.Extensions
{
    internal static class DependentServiceCollection
    {
        internal static IServiceCollection AddCustomServiceBuilder(this IServiceCollection services)
        {
            // Add services to the container.
            services.AddRazorPages();
            services.Configure<RouteOptions>(options => {
                options.AppendTrailingSlash = true;
                options.LowercaseUrls = true;
                options.LowercaseQueryStrings = true;
            });

            services.AddHealthChecks();

            services.AddScoped<DataContext>();
            services.AddTransient<DataReposit>();
            services.AddScoped<IBlogPostService, BlogPostService>();
            return services;
        }
    }
}
