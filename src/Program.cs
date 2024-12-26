using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Restaurants.Actions.Commands.AddResturant;
using Restaurants.DataAccessor;
using Restaurants.Repository.Implementations;
using Restaurants.Repository.Interfaces;
using Serilog;
using Serilog.Events;
using System.Reflection;


namespace Restaurants
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("ResturantConnection");

            builder.Services.AddDbContext<ResturantDbContext>(db => db.UseSqlServer(connectionString));
            builder.Services.AddControllers();

            builder.Services.AddFluentValidationAutoValidation();
            builder.Services.AddValidatorsFromAssemblyContaining<AddResturantCommandValidator>();

            builder.Services.AddScoped<IResturantRepository, ResturantRepository>();

            // Register MediatR and scan for handlers in the current assembly
            builder.Services.AddMediatR(conf => conf.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var log_file = builder.Configuration.GetSection("Logging:File").Value;

            builder.Host.UseSerilog((context, configuration) =>
            {
                configuration
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Information)
                // .WriteTo.Console(outputTemplate: "[{Timestamp:dd-MM-yyyy HH:mm:ss} {Level:u3}] |{SourceContext}| {NewLine}{Message}{NewLine}")
                .WriteTo.File(log_file!, rollingInterval: RollingInterval.Hour, outputTemplate: "[{Timestamp:dd-MM-yyyy HH:mm:ss} {Level:u3}] |{SourceContext}| {NewLine}{Message}{NewLine}");
            });

            var app = builder.Build();

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
