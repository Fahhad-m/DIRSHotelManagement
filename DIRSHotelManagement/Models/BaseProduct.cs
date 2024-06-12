namespace DIRSHotelManagement.Models
{
    public abstract class BaseProduct
    {
        public string Id { get; set; }
        public DateTime CreatedAt { get; set; }

        protected BaseProduct()
        {
            Id = Guid.NewGuid().ToString();
            CreatedAt = DateTime.UtcNow;
        }
    }
}
