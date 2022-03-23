
using Shared.Interfaces.Services;
using Shared.Interfaces.Repository;
using Shared.Services;
using Core.Configuration;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using Data.Entity;
using Shared.Repository;
using Web.Filters;
using Microsoft.AspNetCore.Identity;

namespace Web.Extensions
{
    internal static class DependentServiceCollection
    {
        internal static IServiceCollection AddCustomServiceBuilder(this IServiceCollection services, IConfiguration config)
        {
            // Add services to the container.
            services.AddRazorPages()
                .AddMvcOptions(options =>
                {
                    options.Filters.Add<ValidateFilter>();
                });

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

            // Identity Service
            services.AddDefaultIdentity<ApplicationUser>(opt =>
            {
                opt.Lockout.AllowedForNewUsers = true;
                opt.SignIn.RequireConfirmedAccount = false;
                opt.Password.RequiredLength = 6;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireDigit = false;

            }).AddEntityFrameworkStores<FortuneDbContext>();

            // Inject Code Services
            services.AddScoped<IMailMessage, MailMessageService>();
            services.AddScoped<DataContext>();
            services.AddTransient<DataReposit>();
            services.AddScoped<IBlogPostService, BlogPostService>();

            services.AddScoped<IDataStore<Post>, PostRepository>();
            services.AddScoped<IStringIdStore<IdentityUser>, UserRepository>();
            services.AddScoped<IDataStore<Comment>, CommentRepository>();
            services.AddScoped<IDataStore<Category>, CategoryRepository>();

            services.AddScoped<IUserService, UserService>();

            services.AddSingleton<IMailMessage, MailMessageService>();

            //services.AddScoped<IDataStore<Post>, PostService>();
            //services.AddScoped<IDataStore<User>, UserService>();
            //services.AddScoped<IDataStore<Comment>, CommentService>();

            return services;
        }
    }
}
