
using Core.Interfaces.Services;
using Core.Interfaces.Repository;
using Shared.Services;
using Core.Configuration;


namespace Web.Extensions
{
    internal static class DependentServiceCollection
    {
        internal static IServiceCollection AddCustomServiceBuilder(this IServiceCollection services, IConfiguration config)
        {
            // Add services to the container.
            services.AddRazorPages();
            services.Configure<RouteOptions>(options =>
            {
                options.AppendTrailingSlash = true;
                options.LowercaseUrls = true;
                options.LowercaseQueryStrings = true;
            });

            services.Configure<EmailProp>(config.GetSection(nameof(EmailProp)));
            services.Configure<ConnectionStrings>(config.GetSection(nameof(ConnectionStrings)));

            services.AddHealthChecks();

            services.AddScoped<IMailMessage, MailMessageService>();
            services.AddScoped<DataContext>();
            services.AddTransient<DataReposit>();
            services.AddScoped<IBlogPostService, BlogPostService>();
            return services;
        }
    }
}
