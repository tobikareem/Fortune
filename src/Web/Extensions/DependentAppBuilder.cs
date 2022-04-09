
namespace Web.Extensions
{
    public static class DependentAppBuilder
    {
        public static IApplicationBuilder UseCustomServiceBuilder(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            
            //app.UseStatusCodePagesWithReExecute("/{0}");
            app.UseStatusCodePages();

            // TODO: Use this to display a razor page generic error.
            //  Use app.UseDeveloperExceptionPage(new DeveloperExceptionPageOptions { SourceCodeLineCount = 5 }); to display more details and where the error came from
            // app.UseExceptionHandler("/Error");  

            // Configure the HTTP request pipeline.
            if (!env.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseForwardedHeaders();
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
