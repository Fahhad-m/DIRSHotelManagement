namespace DIRSHotelManagement.Models
{
    public class MongoDbSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string ProductsCollectionName { get; set; }
        public string AvailabilitiesCollectionName { get; set; }
    }
}
