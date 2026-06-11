
using Microsoft.AspNetCore.HttpOverrides;
using System.Text.Json;

namespace Web.Extensions
{
    public static class DependentAppBuilder
    {
        public static IApplicationBuilder UseCustomServiceBuilder(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStatusCodePagesWithReExecute("/StatusPage/{0}");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage(new DeveloperExceptionPageOptions { SourceCodeLineCount = 10 }); //to display more details and where the error came from

            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseForwardedHeaders(new ForwardedHeadersOptions
                {
                    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto,
                    ForwardLimit = 1 // Optional: Security improvement
                });
                app.UseHsts();
            }

            // Canonical host: 301-redirect www.tobikareem.com -> tobikareem.com
            // (preserves path + query, forces https). Keeps SEO/cookies on one host.
            app.Use(async (context, next) =>
            {
                if (string.Equals(context.Request.Host.Host, "www.tobikareem.com", StringComparison.OrdinalIgnoreCase))
                {
                    var target = $"https://tobikareem.com{context.Request.PathBase}{context.Request.Path}{context.Request.QueryString}";
                    context.Response.Redirect(target, permanent: true);
                    return;
                }
                await next();
            });

            // app.UseStaticFiles();
            app.UseHttpsRedirection();
            app.UseMiddleware<CustomErrorLogMiddleware>();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            _ = app.UseEndpoints(endPoints =>
            {
                endPoints.MapStaticAssets();
                endPoints.MapRazorPages().WithStaticAssets();
                endPoints.MapHealthChecks("/health", new Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions
                {
                    ResponseWriter = async (context, report) =>
                    {
                        context.Response.ContentType = "application/json";
                        var result = JsonSerializer.Serialize(new
                        {
                            status = report.Status.ToString(),
                            details = report.Entries.Select(e => new { key = e.Key, value = e.Value.Status.ToString() })
                        });
                        await context.Response.WriteAsync(result);
                    }
                });

            });

            return app;
        }
    }
}
