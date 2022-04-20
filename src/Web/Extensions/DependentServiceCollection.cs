
using System.Reflection;
using Shared.Interfaces.Services;
using Shared.Interfaces.Repository;
using Shared.Services;
using Core.Configuration;
using Core.Constants;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using Data.Entity;
using Shared.Repository;
using Web.Customs.Filter;
using Web.Customs.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Azure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration.AzureAppConfiguration;

namespace Web.Extensions
{
    internal static class DependentServiceCollection
    {
        internal static IServiceCollection AddCustomServiceBuilder(this IServiceCollection services, WebApplicationBuilder builder)
        {
            var config = builder.Configuration;

            services.AddRazorPages()
                .AddMvcOptions(options =>
                {
                    options.Filters.Add<ValidateFilter>();
                });
            services.AddHealthChecks();
            services.AddHsts(opt => opt.MaxAge = TimeSpan.FromHours(1));

            #region Configurations And DbContext
            services.Configure<EmailProp>(config.GetSection(nameof(EmailProp)));
            services.Configure<ConnectionStrings>(config.GetSection(nameof(ConnectionStrings)));
            services.Configure<GoggleAnalytics>(config.GetSection(nameof(GoggleAnalytics)));
            services.Configure<RouteOptions>(options =>
            {
                options.AppendTrailingSlash = true;
                options.LowercaseUrls = true;
                options.LowercaseQueryStrings = true;
            });

            builder.Configuration.AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json");

            if (builder.Environment.IsDevelopment())
            {
                builder.Configuration.AddUserSecrets(Assembly.GetExecutingAssembly());
            }
            builder.Configuration.AddEnvironmentVariables();

            if (!builder.Environment.IsDevelopment())
            {
                builder.Configuration.AddAzureAppConfiguration(opt =>
                {
                    var cred = new DefaultAzureCredential();

                    var appEndPoint = config[nameof(ConfigAppSetting.AppEndPoint)];

                    opt.Connect(new Uri(appEndPoint), cred).Select(KeyFilter.Any, ConfigAppSetting.ProductionLabelFilter);

                    opt.ConfigureRefresh(refresh =>
                    {
                        refresh.Register(KeyFilter.Any, ConfigAppSetting.ProductionLabelFilter, true).SetCacheExpiration(TimeSpan.FromDays(1));
                    });
                });

            }

            var connString = config.GetConnectionString(nameof(ConnectionStrings.DefaultConnection));
            services.AddDbContext<FortuneDbContext>(opt => opt.UseSqlServer(connString));

            #endregion

            #region Identity/Authorization
            services.AddAuthorization(opt =>
            {
                opt.AddPolicy(ResourcePolicy.IsTobiKareem, pol =>
                {
                    pol.RequireClaim(ClaimTypes.Role, ResourceAction.FortuneAdmin);
                });

                opt.AddPolicy(ResourcePolicy.HasWriteAccess, pol =>
                {
                    pol.RequireClaim(ClaimTypes.Role, ResourceAction.CanWritePost);
                });

                opt.AddPolicy(ResourcePolicy.HasEditAccess, pol =>
                {
                    pol.RequireClaim(ClaimTypes.Role, ResourceAction.CanEditPost);
                });

                opt.AddPolicy(ResourcePolicy.HasFullCreateAccess, pol =>
                {
                    pol.AddRequirements(new AllowedFullAccessRequirement());
                });

                opt.AddPolicy(ResourcePolicy.OwnerCanEdit, pol =>
                {
                    pol.AddRequirements(new IsPostOwnerRequirement());
                });
            });

            services.AddSingleton<IAuthorizationHandler, FullAccessHandler>();
            services.AddScoped<IAuthorizationHandler, IsPostOwnerRequirementHandler>();


            services.AddDefaultIdentity<ApplicationUser>(opt =>
            {
                opt.Lockout.AllowedForNewUsers = true;
                opt.SignIn.RequireConfirmedAccount = false;
                opt.Password.RequiredLength = 6;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireDigit = false;

            }).AddEntityFrameworkStores<FortuneDbContext>();
            #endregion

            #region Code Services

            services.AddScoped<IServiceCalls, CallsService>();
            services.AddScoped<IBlogPostService, BlogPostService>();
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IDataStore<Post>, PostRepository>();
            services.AddScoped<IStringIdStore<IdentityUser>, UserRepository>();
            services.AddScoped<IDataStore<Comment>, CommentRepository>();
            services.AddScoped<IDataStore<Category>, CategoryRepository>();
            services.AddScoped<IBaseStore<Suggestions>, SuggestionRepository>();

            #endregion

            #region Host Settings / Logging / Deployment

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

            #endregion

            return services;
        }
    }
}
