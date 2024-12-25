using Restaurants.Models.Domains;

namespace Restaurants.Repository.Interfaces
{
    public interface IResturantRepository
    {
        Task<List<Resturant>> GetResturantsAsync();
        Task<Resturant?> GetResturantByIdAsync(int id);
        Task<(bool exists, Resturant? resturant)> AddResturantAsync(Resturant add_resturant);
        Task<Resturant?> DeleteResturantAsync(int id);
    }
}
