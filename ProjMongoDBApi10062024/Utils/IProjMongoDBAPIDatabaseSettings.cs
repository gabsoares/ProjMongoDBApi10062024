namespace ProjMongoDBApi10062024.Utils
{
    public interface IProjMongoDBAPIDatabaseSettings
    {
        string CustomerCollectionName {  get; set; }
        string AddressCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}