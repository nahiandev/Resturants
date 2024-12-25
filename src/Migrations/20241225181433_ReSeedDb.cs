using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Restaurants.Migrations
{
    /// <inheritdoc />
    public partial class ReSeedDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    { 5, "Indian", "Authentic Indian curries.", "contact@curryhouse.com", true, "Curry House", "333-222-1111" },
                    { 6, "Chinese", "Delicious", "donx@house.vox", true, "Peking Duck House", "666-777-8888" },
                    { 7, "Italian", "Delicious", "utral@hdg.co.in", true, "Pasta Palace", "666-777-8888" },
                    { 8, "Japanese", "Delicious", "serrc@olx.au", true, "Sushi Palace", "666-777-8888" },
                    { 9, "Mexican", "Delicious", "ducky@paant.kz", true, "Taco Palace", "666-777-8888" },
                    { 10, "American", "Delicious", "grave@hylux.co.uk", true, "Burger Palace", "666-777-8888" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Resturants");
        }
    }
}
