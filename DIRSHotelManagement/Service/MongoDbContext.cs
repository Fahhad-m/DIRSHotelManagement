using DIRSHotelManagement.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace DIRSHotelManagement.Service
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(IOptions<MongoDbSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            _database = client.GetDatabase(settings.Value.DatabaseName);
        }
        public IMongoCollection<Product> GetProductsCollection()
        {
            return _database.GetCollection<Product>(nameof(Product));
        }

        public IMongoCollection<Availability> GetAvailabilitiesCollection()
        {
            return _database.GetCollection<Availability>(nameof(Availability));
        }
    }

}
