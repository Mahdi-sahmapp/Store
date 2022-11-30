using Infrastructure;
using Web;

var builder = WebApplication.CreateBuilder(args);

//Configuration
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.AddWebService();

//build
var app = builder.Build();
await app.AddWebConfigureService().ConfigureAwait(false);
