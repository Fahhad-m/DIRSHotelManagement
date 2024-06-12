using DIRSHotelManagement.Models;

namespace DIRSHotelManagement.Interfaces
{
    public interface IAvailabilityRepository
    {
        //Task<Availability> CheckAvailability(string productId, DateTime startDate, DateTime endDate);
        //Task AddAvailability(Availability availability);

        Task<IEnumerable<Availability>> GetAllAsync();
        Task<Availability> GetByIdAsync(string id);
        Task AddAvailability(Availability availability);
        Task<bool> CheckAvailability(string productId, DateTime startDate, DateTime endDate);

    }
}
