﻿using Restaurants.Domains.Models;

namespace Restaurants.Domains.DTOs
{
    public class ResturantDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public bool HasDelivery { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }

        public List<Dish> Dishes { get; set; } = [];
    }
}
