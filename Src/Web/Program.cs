using Application;
using Infrastructure;
using Web;

var builder = WebApplication.CreateBuilder(args);

//Configuration
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.AddWebService();

//build
var app = builder.Build();
app.UseStaticFiles();
await app.AddWebConfigureService().ConfigureAwait(false);
