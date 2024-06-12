using DIRSHotelManagement.Interfaces;
using DIRSHotelManagement.Models;
using MongoDB.Driver;

namespace DIRSHotelManagement.Service
{
    public class ProductRepository : IProductRepository
    { 
        private readonly IMongoCollection<Product> _products;

        public ProductRepository(MongoDbContext context)
        {
            _products = context.GetProductsCollection();
        }

        public async Task<IEnumerable<Product>> GetAllAsync(int page, int pageSize, string categoryName = null)
        {
            var filter = Builders<Product>.Filter.Empty;

            if (!string.IsNullOrEmpty(categoryName))
            {
                filter = Builders<Product>.Filter.Eq(p => p.CategoryName, categoryName);
            }

            return await _products.Find(filter)
                .Skip((page - 1) * pageSize)
                .Limit(pageSize)
                .ToListAsync();

            //return await _products.Find(product => true).ToListAsync();
        }

        public async Task<Product> GetByIdAsync(string id)
        {
            return await _products.Find<Product>(product => product.Id == id).FirstOrDefaultAsync();
        }

        public async Task AddAsync(Product product)
        {
            await _products.InsertOneAsync(product);
        }

        public async Task UpdateAsync(string id, Product product)
        {
            await _products.ReplaceOneAsync(p => p.Id == id, product);
        }

        public async Task DeleteAsync(string id)
        {
            await _products.DeleteOneAsync(p => p.Id == id);
        }
    }
}
