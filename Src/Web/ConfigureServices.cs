
using Infrastructure.Persistence.SeedData;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Web
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddWebService( this WebApplicationBuilder builder)
        {
            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            return builder.Services;
        }

        public static async  Task<IApplicationBuilder> AddWebConfigureService(this WebApplication app)
        {

            // get service
            var scope = app.Services.CreateScope();
            var Services = scope.ServiceProvider;
            var context = Services.GetRequiredService<ApplicationDbContext>();
            var loggerFactory = Services.GetRequiredService<ILoggerFactory>();
            //autoMigration
            try
            {
                await context.Database.MigrateAsync();
                await GenerateData.SeedDataAsync(context, loggerFactory);
            }
            catch (Exception e)
            {
                var logger = loggerFactory.CreateLogger<Program>();
                logger.LogError(e, "Migration Error!");
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            app.MapControllers();

            await app.RunAsync();

            return app; 
        }
    }
}
