using Web.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCustomServiceBuilder(builder);

var app = builder.Build();
app.UseCustomServiceBuilder(app.Environment);
app.Run();
