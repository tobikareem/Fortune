
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
using Web.Customs.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Azure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration.AzureAppConfiguration;
using Microsoft.Extensions.Logging.AzureAppServices;

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
                    // options.Filters.Add<ValidateFilter>();
                });
            services.AddHealthChecks();
            services.AddHsts(opt => opt.MaxAge = TimeSpan.FromHours(1));
            services.AddHttpClient();
            services.AddMemoryCache();


            #region Configurations And DbContext

            if (!builder.Environment.IsDevelopment())
            {
                builder.Configuration.AddAzureAppConfiguration(opt =>
                {
                    opt.Connect(new Uri("https://fortuneappconfig.azconfig.io"), new DefaultAzureCredential()).Select(KeyFilter.Any, "Production");
                });
            }
            
            services.Configure<EmailProp>(config.GetSection(ConfigAppSetting.EmailPropOptions));
            services.Configure<ConnectionStrings>(config.GetSection(ConfigAppSetting.ConnectionStringsOptions));
            services.Configure<GoogleAnalytics>(config.GetSection(ConfigAppSetting.GoogleAnalyticsOptions));
            services.Configure<FacebookSignIn>(config.GetSection(ConfigAppSetting.FacebookSignInOptions));
            services.Configure<TwitterSignIn>(config.GetSection(ConfigAppSetting.TwitterSignInOptions));
            services.Configure<GoogleDriveApi>(config.GetSection(ConfigAppSetting.GoogleDriveApiOptions));
            services.Configure<SingleProperty>(config.GetSection(ConfigAppSetting.SinglePropertyOptions));
            services.Configure<ConfigAppSetting>(config.GetSection(nameof(ConfigAppSetting)));
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

            var connString = config.GetConnectionString(nameof(ConnectionStrings.DefaultConnection));

            if (!builder.Environment.IsDevelopment())
            {
                connString = config.GetConnectionString(nameof(ConnectionStrings.ProductionConnection));
            }
            services.AddDbContext<FortuneDbContext>(opt => opt.UseSqlServer(connString));

            #endregion

            #region Identity/Authorization/Authentication
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
            services.AddAuthentication().AddFacebook(f =>
            {
                var facebookAuth = config.GetSection(ConfigAppSetting.FacebookSignInOptions).Get<FacebookSignIn>();

                f.AppId = facebookAuth.Facebookappid;
                f.AppSecret = facebookAuth.Facebookappsecret;
                f.AccessDeniedPath = "/Account/AccessDenied";
            }).AddTwitter(t =>
            {
                var twitterAuth = config.GetSection(ConfigAppSetting.TwitterSignInOptions).Get<TwitterSignIn>();

                t.ConsumerKey = twitterAuth.Twitterconsumerkey;
                t.ConsumerSecret = twitterAuth.Twitterconsumersecret;
                t.AccessDeniedPath = "/Account/AccessDenied";
            });
            services.AddSingleton<IAuthorizationHandler, FullAccessHandler>();
            services.AddScoped<IAuthorizationHandler, IsPostOwnerRequirementHandler>();


            services.AddDefaultIdentity<ApplicationUser>(opt =>
            {
                opt.Lockout.AllowedForNewUsers = true;
                opt.SignIn.RequireConfirmedAccount = true;
                opt.Password.RequiredLength = 6;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireDigit = false;
                opt.Tokens.EmailConfirmationTokenProvider = TokenOptions.DefaultEmailProvider;
                opt.Tokens.PasswordResetTokenProvider = TokenOptions.DefaultEmailProvider;

            }).AddDefaultTokenProviders().AddEntityFrameworkStores<FortuneDbContext>();


            services.ConfigureApplicationCookie(opt =>
            {
                opt.ExpireTimeSpan = TimeSpan.FromDays(5);
                opt.SlidingExpiration = true;
            });

            #endregion

            #region Code Services
            services.AddScoped<IBlogPostService, BlogPostService>();
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IDataStore<Post>, PostRepository>();
            services.AddScoped<IStringIdStore<IdentityUser>, UserRepository>();
            services.AddScoped<IDataStore<Comment>, CommentRepository>();
            services.AddScoped<IDataStore<Category>, CategoryRepository>();
            services.AddScoped<IBaseStore<Suggestions>, SuggestionRepository>();
            services.AddScoped<IDataStore<UserDetail>, UserDetailRepository>();
            services.AddScoped<IHttpRepository, HttpRepository>();
            services.AddScoped<IExternalApiCalls, ExternalApiCalls>();

            services.AddScoped<ICacheService, CacheService>();


            services.AddTransient<IEmailSender, EmailSender>();

            #endregion

            #region Host Settings / Logging / Deployment

            builder.Logging.AddFile(f =>
            {
                f.FileName = $"File_Log.{DateTime.Now:d}";
            });
            builder.Logging.AddAzureWebAppDiagnostics();

            // Default log location: D:\\home\\LogFiles\\Application
            // Default file name: diagnostics-yyyymmdd.txt
            // Default blob name: {app-name}{timestamp}/yyyy/mm/dd/hh/{guid}-applicationLog.txt.
            builder.Services.Configure<AzureFileLoggerOptions>(options =>
            {
                options.FileName = "app-diagnostics-";
                options.FileSizeLimit = 50 * 1024;
                options.RetainedFileCountLimit = 5;
            });
            builder.Services.Configure<AzureBlobLoggerOptions>(options =>
            {
                options.BlobName = "app-log.txt";
            });

            builder.WebHost.UseIIS();
            builder.WebHost.UseIISIntegration();

            #endregion

            return services;
        }
    }
}
