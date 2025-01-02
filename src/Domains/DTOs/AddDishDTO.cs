namespace Resturants.Domains.DTOs
{
    public class AddDishDTO
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public decimal Price { get; set; }

        public int? KiloCalories { get; set; }

        public int RestaurantId { get; set; }
    }
}
