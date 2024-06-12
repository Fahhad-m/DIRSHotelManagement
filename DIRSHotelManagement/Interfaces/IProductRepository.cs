using DIRSHotelManagement.Models;

namespace DIRSHotelManagement.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync(int page, int pageSize, string categoryName = null);
        Task<Product> GetByIdAsync(string id);
        Task AddAsync(Product product);
        Task UpdateAsync(string id, Product product);
        Task DeleteAsync(string id);
    }
}
