namespace Restaurants.Models.DTOs
{
    public class AddResturantDTO
    {
        //[Required]
        //[MinLength(3, ErrorMessage = "Name can't be less than 3 characters.")]
        //[MaxLength(50, ErrorMessage = "Maximum 50 characters allowed.")]
        public string Name { get; set; }

        //[Required]
        //[MaxLength(300, ErrorMessage = "Maximum 300 characters allowed.")]
        public string Description { get; set; }

        //[Required]
        //[MaxLength(10, ErrorMessage = "Maximum 10 characters allowed.")]
        public string Category { get; set; }

        //[Required]
        public bool HasDelivery { get; set; }

        public string? PhoneNumber { get; set; }

        //[EmailAddress(ErrorMessage = "Invalid email address format.")]
        public string? Email { get; set; }
    }
}
