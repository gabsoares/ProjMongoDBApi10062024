using MongoDB.Driver;
using ProjMongoDBApi10062024.Models;
using ProjMongoDBApi10062024.Utils;

namespace ProjMongoDBApi10062024.Services
{
    public class AddressService
    {
        private readonly IMongoCollection<Address> _address;

        public AddressService(IProjMongoDBAPIDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _address = database.GetCollection<Address>(settings.AddressCollectionName);
        }

        public List<Address> Get() => _address.Find(address => true).ToList();
        public Address GetById(string id) => _address.Find<Address>(address => address.Id == id).FirstOrDefault();
        public Address Insert(Address address)
        {
            _address.InsertOne(address);
            return address;
        }
    }
}
