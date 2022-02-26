using Web.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCustomServices();
var app = builder.Build();
app.UseCustomBuilder(app.Environment);

app.Run();
