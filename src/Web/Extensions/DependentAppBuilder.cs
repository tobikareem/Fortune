
using Microsoft.AspNetCore.HttpOverrides;

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

            // Configure the HTTP request pipeline.
            if (!env.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseForwardedHeaders(new ForwardedHeadersOptions
                {
                    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
                });
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();

            app.UseAuthorization();

            _ = app.UseEndpoints(endPoints =>
            {
                endPoints.MapRazorPages();
                endPoints.MapHealthChecks("/health");
                endPoints.MapGet("/tests", async endPoints => { await endPoints.Response.WriteAsync("Hello World"); });
            });

            return app;
        }
    }
}
