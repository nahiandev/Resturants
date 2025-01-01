using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Restaurants.Actions.Commands.AddResturant;
using Restaurants.DataAccessor;
using Restaurants.Middlewares;
using Restaurants.Repository.Implementations;
using Restaurants.Repository.Interfaces;
using Restaurants.Seeders;
using Resturants.Repository.Implementations;
using Resturants.Repository.Interfaces;
using Serilog;
using System.Reflection;


namespace Restaurants
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("ResturantConnection");

            builder.Services.AddDbContext<ResturantDbContext>(DATABASE => DATABASE.UseSqlServer(connectionString));
            builder.Services.AddControllers();

            builder.Services.AddFluentValidationAutoValidation();
            builder.Services.AddValidatorsFromAssemblyContaining<AddResturantCommandValidator>();

            builder.Services.AddScoped<IResturantRepository, ResturantRepository>();
            builder.Services.AddScoped<IDishesRepository, DishesRepository>();

            builder.Services.AddScoped<ErrorHandler>();
            builder.Services.AddScoped<IResturantSeeder, ResturantSeeder>();

            // Register MediatR and scan for handlers in the current assembly
            builder.Services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));

            var app = builder.Build();

            var scope = app.Services.CreateScope();
            var seeder = scope.ServiceProvider.GetRequiredService<IResturantSeeder>();

            await seeder.SeedAsync();

            app.UseMiddleware<ErrorHandler>();
            app.UseSerilogRequestLogging();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
