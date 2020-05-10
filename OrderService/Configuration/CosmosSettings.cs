namespace OrderService.Configuration
{
    public class CosmosSettings
    {
        public string PrimaryConnectionString { get; set; }
        public string DatabaseId{ get; set; }
        public string ContainerId { get; set; }
        public string PartitionKey { get; set; }

    }
}
