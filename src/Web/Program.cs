using Web.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCustomServiceBuilder();

var app = builder.Build();

app.UseCustomServiceBuilder(app.Environment);

app.Run();
