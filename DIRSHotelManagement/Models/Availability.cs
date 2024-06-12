namespace DIRSHotelManagement.Models
{
    public class Availability
    {
        public string Id { get; set; }
        public string ProductId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsAvailable { get; set; }
    }
}
