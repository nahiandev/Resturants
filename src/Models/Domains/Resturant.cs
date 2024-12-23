namespace Restaurants.Models.Domains
{
    public class Resturant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public bool HasDelivery { get; set; }

        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }

        public Address? Address { get; set; }
        public List<Dish> Dishes { get; set; }
    }
}
