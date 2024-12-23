
using Microsoft.EntityFrameworkCore;
using Restaurants.DataAccessor;
using Restaurants.DataSeeder.Implementations;
using Restaurants.DataSeeder.Interfaces;


namespace Restaurants
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("ResturantConnection");

            builder.Services.AddDbContext<ResturantDbContext>(db => db.UseSqlServer(connectionString));

            builder.Services.AddControllers();

            //builder.Services.AddScoped<IResturantSeeder, ResturantSeeder>();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();


            //using (var scope = app.Services.CreateScope())
            //{
            //    var seeder = scope.ServiceProvider.GetRequiredService<IResturantSeeder>();
            //    await seeder.SeedAsync();
            //}

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
