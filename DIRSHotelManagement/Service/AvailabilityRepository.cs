using DIRSHotelManagement.Interfaces;
using DIRSHotelManagement.Models;
using MongoDB.Driver;

namespace DIRSHotelManagement.Service
{
    public class AvailabilityRepository : IAvailabilityRepository
    {
        private readonly IMongoCollection<Availability> _availabilities;

        public AvailabilityRepository(MongoDbContext context)
        {
            _availabilities = context.GetAvailabilitiesCollection();
        }

        public async Task<bool> CheckAvailability(string productId, DateTime startDate, DateTime endDate)
        {
            var availability = await _availabilities.Find(a =>
                a.ProductId == productId &&
                a.StartDate <= startDate &&
                a.EndDate >= endDate &&
                a.IsAvailable).FirstOrDefaultAsync();

            return availability != null;
        }

        public async Task AddAvailability(Availability availability)
        {
            await _availabilities.InsertOneAsync(availability);
        }
        public async Task<IEnumerable<Availability>> GetAllAsync()
        {
            return await _availabilities.Find(availability => true).ToListAsync();
        }
        public async Task<Availability> GetByIdAsync(string id)
        {
            return await _availabilities.Find<Availability>(availability => availability.Id == id).FirstOrDefaultAsync();
        }

        public async Task AddAsync(Availability availability)
        {
            await _availabilities.InsertOneAsync(availability);
        }

    }
}
