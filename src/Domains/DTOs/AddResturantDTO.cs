namespace Restaurants.Domains.DTOs;

public class AddResturantDTO
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required string Category { get; set; }
    public bool HasDelivery { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
}
