
using Infrastructure.Persistence.SeedData;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Persistence.Context;
using Microsoft.AspNetCore.Mvc;
using Domain.Exceptions;

namespace Web
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddWebService(this WebApplicationBuilder builder)
        {
            // Add services to the container.
            builder.Services.AddControllers();
            ApiBehaviorOptions(builder);
            builder.Services.AddEndpointsApiExplorer();
            // IHttpContextAccessor
            builder.Services.AddHttpContextAccessor();

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
                //await context.Database.MigrateAsync();
                //await GenerateData.SeedDataAsync(context, loggerFactory);
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

        private static void ApiBehaviorOptions(WebApplicationBuilder builder)
        {
            // زمانیکه فرموت ورودی مطابقت نداشت
            //TODO CHECK THIS
            builder.Services.Configure<ApiBehaviorOptions>(option =>
            {
                option.InvalidModelStateResponseFactory = actionContext =>
                {
                    var errors = actionContext.ModelState
                    .Where(a => a.Value.Errors.Any())
                    .SelectMany(a => a.Value.Errors)
                    .Select(a => a.ErrorMessage).ToList();

                    return new BadRequestObjectResult(new ApiToReturn(400, errors));
                };
            });
        }
    }
}
