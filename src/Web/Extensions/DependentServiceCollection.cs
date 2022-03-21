
using Core.Interfaces.Services;
using Core.Interfaces.Repository;
using Shared.Services;
using Core.Configuration;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using Data.Entity;
using Shared.Repository;

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
            services.AddHealthChecks();

            // Configure Services
            services.Configure<EmailProp>(config.GetSection(nameof(EmailProp)));
            services.Configure<ConnectionStrings>(config.GetSection(nameof(ConnectionStrings)));

            var connString = config.GetConnectionString("DefaultConnection");
            services.AddDbContext<FortuneDbContext>(opt => opt.UseSqlServer(connString));

            // Inject Code Services
            services.AddScoped<IMailMessage, MailMessageService>();
            services.AddScoped<DataContext>();
            services.AddTransient<DataReposit>();
            services.AddScoped<IBlogPostService, BlogPostService>();

            services.AddScoped<IDataStore<Post>, PostRepository>();
            services.AddScoped<IDataStore<User>, UserRepository>();
            services.AddScoped<IDataStore<Comment>, CommentRepository>();
            services.AddScoped<IDataStore<Category>, CategoryRepository>();

            //services.AddScoped<IDataStore<Post>, PostService>();
            //services.AddScoped<IDataStore<User>, UserService>();
            //services.AddScoped<IDataStore<Comment>, CommentService>();

            return services;
        }
    }
}
