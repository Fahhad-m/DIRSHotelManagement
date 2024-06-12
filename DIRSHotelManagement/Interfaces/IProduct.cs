namespace DIRSHotelManagement.Interfaces
{
    public interface IProduct
    {
        string Id { get; set; }
        string CategoryName { get; set; }
        int Capacity { get; set; }
        decimal PricePerNight { get; set; }
    }
}
