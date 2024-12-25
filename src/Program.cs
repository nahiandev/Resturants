using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Restaurants.Actions.Commands.AddResturant;
using Restaurants.DataAccessor;
using Restaurants.Repository.Implementations;
using Restaurants.Repository.Interfaces;
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
