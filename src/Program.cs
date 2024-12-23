
using Microsoft.EntityFrameworkCore;
using Restaurants.DataAccessor;

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

        private delegate int Trev(int x, int y);

        private static void Hello()
        {
            var s = string.Empty;
        }
    }
}
