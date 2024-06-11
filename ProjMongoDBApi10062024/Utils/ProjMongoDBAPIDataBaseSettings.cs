namespace ProjMongoDBApi10062024.Utils
{
    public class ProjMongoDBAPIDataBaseSettings : IProjMongoDBAPIDatabaseSettings
    {
        public string CustomerCollectionName { get; set; }
        public string AddressCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
