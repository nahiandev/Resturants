using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Restaurants.Migrations
{
    /// <inheritdoc />
    public partial class HDHDSW : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dishes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dishes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Resturants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HasDelivery = table.Column<bool>(type: "bit", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resturants", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Resturants",
                columns: new[] { "Id", "Category", "Description", "Email", "HasDelivery", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Italian", "A cozy place for authentic Italian cuisine.", "contact@italianbistro.com", true, "Italian Bistro", "123-456-7890" },
                    { 2, "Japanese", "Fresh and delicious sushi.", "info@sushiworld.com", false, "Sushi World", "987-654-3210" },
                    { 3, "Mexican", "Best tacos in town.", "order@tacofiesta.com", true, "Taco Fiesta", "555-123-4567" },
                    { 4, "American", "Juicy burgers and crispy fries.", "support@burgerhaven.com", false, "Burger Haven", "444-555-6666" },
                    { 5, "Indian", "Authentic Indian curries.", "contact@curryhouse.com", true, "Curry House", "333-222-1111" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dishes");

            migrationBuilder.DropTable(
                name: "Resturants");
        }
    }
}
