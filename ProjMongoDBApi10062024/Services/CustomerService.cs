using MongoDB.Driver;
using ProjMongoDBApi10062024.Models;
using ProjMongoDBApi10062024.Utils;

namespace ProjMongoDBApi10062024.Services
{
    public class CustomerService
    {
        private readonly IMongoCollection<Customer> _customer;

        public CustomerService(IProjMongoDBAPIDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _customer = database.GetCollection<Customer>(settings.CustomerCollectionName);
        }

        public List<Customer> Get() => _customer.Find(customer => true).ToList();

        public Customer GetById(string id) => _customer.Find<Customer>(customer => customer.Id == id).FirstOrDefault();

        public Customer Insert(Customer customer)
        {
            _customer.InsertOne(customer);
            return customer;
        }

        public Customer Update(Customer customer)
        {
            _customer.ReplaceOne(c => c.Id == customer.Id, customer);
            return customer;
        }

        public void Delete(string id)
        {
            _customer.DeleteOne(c => c.Id == id);
        }
    }
}