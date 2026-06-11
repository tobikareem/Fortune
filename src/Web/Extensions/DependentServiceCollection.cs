
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
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Logging.AzureAppServices;
using NLog;
using NLog.Web;
using SpotifyAPI.Web;
using static SpotifyAPI.Web.Scopes;
using Category = Data.Entity.Category;

namespace Web.Extensions
{
    internal static class DependentServiceCollection
    {
        internal static IServiceCollection ConfigureCustomServices(this IServiceCollection services, WebApplicationBuilder builder, Logger logger)
        {
            logger.Debug("... Configuring services");

            var config = builder.Configuration;

            // Configuration sources (appsettings.json, appsettings.{Environment}.json,
            // user secrets in Development, environment variables) are wired by
            // WebApplication.CreateBuilder — do not re-add them here, or the later
            // sources (user secrets) get overridden.

            #region Logging
            builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
            builder.Host.UseNLog();
            // LogManager.Configuration.Variables["logDir"] = builder.Configuration["Logging:NLog:logPath"];
            builder.Logging.AddAzureWebAppDiagnostics();
            
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
            #endregion


            builder.WebHost.UseIIS();
            builder.WebHost.UseIISIntegration();


            #region Configurations
            services.Configure<EmailProp>(config.GetSection(ConfigAppSetting.EmailPropOptions));
            services.Configure<RouteOptions>(options =>
            {
                options.AppendTrailingSlash = true;
                options.LowercaseUrls = true;
            });
            #endregion

            #region Database Context
            var connString = config.GetConnectionString(nameof(ConnectionStrings.DefaultConnection));

            if (!builder.Environment.IsDevelopment())
            {
                connString = config.GetConnectionString(nameof(ConnectionStrings.ProductionConnection));
            }
            services.AddDbContext<FortuneDbContext>(opt => opt.UseSqlServer(connString));
            #endregion

            services.AddRazorPages()
                .AddMvcOptions(options =>
                {
                    // options.Filters.Add<ValidateFilter>();
                    // options.Filters.Add<LogPageViewCountPageFilter>();
                });
            services.AddHealthChecks();
            services.AddHsts(opt => opt.MaxAge = TimeSpan.FromHours(1));
            services.AddHttpClient();
            services.AddMemoryCache();


            #region Configurations And DbContext
            services.Configure<ConnectionStrings>(config.GetSection(ConfigAppSetting.ConnectionStringsOptions));
            services.Configure<GoogleAnalytics>(config.GetSection(ConfigAppSetting.GoogleAnalyticsOptions));
            services.Configure<FacebookSignIn>(config.GetSection(ConfigAppSetting.FacebookSignInOptions));
            services.Configure<TwitterSignIn>(config.GetSection(ConfigAppSetting.TwitterSignInOptions));
            services.Configure<GoogleDriveApi>(config.GetSection(ConfigAppSetting.GoogleDriveApiOptions));
            services.Configure<SingleProperty>(config.GetSection(ConfigAppSetting.SinglePropertyOptions));
            services.Configure<Spotify>(config.GetSection(ConfigAppSetting.SpotifyOptions));
            services.Configure<Instagram>(config.GetSection(ConfigAppSetting.InstagramOptions));

            services.Configure<ConfigAppSetting>(config.GetSection(nameof(ConfigAppSetting)));


            // In Development, secrets come from User Secrets (loaded automatically by
            // the host). In other environments they come from Azure App Configuration /
            // environment variables — fail fast if the Facebook credentials are missing.
            if (!builder.Environment.IsDevelopment())
            {
                var facebookAppId = config["Authentications:FacebookSignIn:facebookappid"];
                var facebookAppSecret = config["Authentications:FacebookSignIn:facebookappsecret"];

                if (string.IsNullOrEmpty(facebookAppId) || string.IsNullOrEmpty(facebookAppSecret))
                {
                    throw new InvalidOperationException(
                        "Facebook credentials are missing from configuration (Azure App Configuration / environment variables).");
                }
            }



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
            }).AddSpotify(opt =>
            {
                var spotifyAuth = config.GetSection(ConfigAppSetting.SpotifyOptions).Get<Spotify>();
                opt.ClientId = spotifyAuth.ClientId;
                opt.ClientSecret = spotifyAuth.ClientSecret;
                opt.AccessDeniedPath = "/Account/AccessDenied";
                opt.SaveTokens = true;
                var scopes = new List<string>
                {
                    UserReadEmail, UserReadPrivate, PlaylistReadPrivate, PlaylistReadCollaborative,
                    UserReadCurrentlyPlaying, UserFollowRead, UserLibraryRead, UserTopRead, UserReadRecentlyPlayed
                };

                opt.Scope.Add(string.Join(",", scopes));
            });
            services.AddSingleton<IAuthorizationHandler, FullAccessHandler>();
            services.AddScoped<IAuthorizationHandler, IsPostOwnerRequirementHandler>();
            services.AddSingleton(SpotifyClientConfig.CreateDefault());
            services.AddCustomIdentity(config);
            #endregion

            #region Code Services
            services.AddScoped<IBlogPostService, BlogPostService>();
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<IUserService, UserService>();

            services.AddTransient<IDataStore<Post>, PostRepository>();
            services.AddTransient<IStringIdStore<IdentityUser>, UserRepository>();
            services.AddTransient<IDataStore<Comment>, CommentRepository>();
            services.AddTransient<IDataStore<Category>, CategoryRepository>();
            services.AddTransient<IBaseStore<Suggestions>, SuggestionRepository>();
            services.AddTransient<IDataStore<UserDetail>, UserDetailRepository>();
            services.AddTransient<IHttpRepository, HttpRepository>();
            services.AddScoped<IExternalApiCalls, ExternalApiCalls>();
            services.AddScoped<ICacheService, CacheService>();
            services.AddTransient<IEmailSender, EmailSender>();
            #endregion

            return services;
        }

        public static IServiceCollection AddCustomIdentity(this IServiceCollection services, IConfiguration config)
        {
            services.AddDefaultIdentity<ApplicationUser>(opt =>
            {
                opt.Lockout.AllowedForNewUsers = true;
                opt.SignIn.RequireConfirmedAccount = true;
                opt.Password.RequiredLength = 6;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireDigit = false;
                opt.Tokens.EmailConfirmationTokenProvider = TokenOptions.DefaultEmailProvider;
                opt.Tokens.PasswordResetTokenProvider = TokenOptions.DefaultEmailProvider;
            })
            .AddDefaultTokenProviders()
            .AddEntityFrameworkStores<FortuneDbContext>()
            .AddTokenProvider("Spotify", typeof(DataProtectorTokenProvider<ApplicationUser>));

            services.ConfigureApplicationCookie(opt =>
            {
                opt.ExpireTimeSpan = TimeSpan.FromDays(5);
                opt.SlidingExpiration = true;
            });

            return services;
        }

    }


}
