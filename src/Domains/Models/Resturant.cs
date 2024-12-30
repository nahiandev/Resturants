namespace Restaurants.Domains.Models
{
    public class Resturant
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required string Category { get; set; }
        public bool HasDelivery { get; set; }

        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }



        public bool Equals(Resturant? to_be_compared)
        {
            if (to_be_compared is Resturant another_resturant)
            {
                return Name == another_resturant.Name
                    && Description == another_resturant.Description
                    && Category == another_resturant.Category
                    && HasDelivery == another_resturant.HasDelivery
                    && PhoneNumber == another_resturant.PhoneNumber
                    && Email == another_resturant.Email;
            }

            return false;
        }
    }
}
