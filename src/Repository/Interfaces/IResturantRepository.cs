using Microsoft.AspNetCore.Mvc;
using Restaurants.Models.Domains;
using Restaurants.Models.DTOs;

namespace Restaurants.Repository.Interfaces
{
    public interface IResturantRepository
    {
        Task<List<Resturant>> GetResturantsAsync();
        Task<Resturant?> GetResturantByIdAsync(int id);
        Task AddResturantAsync(Resturant add_resturant);

    }
}
