using DIRSHotelManagement.Interfaces;

namespace DIRSHotelManagement.Models
{
    public class Product : BaseProduct, IProduct
    {
        public string CategoryName { get; set; }
        public int Capacity { get; set; }
        public decimal PricePerNight { get; set; }
    }
}
