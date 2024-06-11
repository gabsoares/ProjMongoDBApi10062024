using Microsoft.AspNetCore.Mvc;
using ProjMongoDBApi10062024.Models;
using ProjMongoDBApi10062024.Services;

namespace ProjMongoDBApi10062024.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly CustomerService _customerService;
        private readonly AddressService _adressService;

        public CustomersController(CustomerService customerService, AddressService adressService)
        {
            _customerService = customerService;
            _adressService = adressService;
        }

        [HttpGet]
        public ActionResult<List<Customer>> Get() => _customerService.Get();

        [HttpGet("{id:length(24)}", Name = "GetCustomerById")]
        public ActionResult<Customer> GetById(string id)
        {
            var customer = _customerService.GetById(id);
            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        [HttpPost]
        public ActionResult<Customer> Insert(Customer customer)
        {
            Address address = _adressService.Insert(customer.CustomerAddress);
            customer.CustomerAddress = address;
            var c = _customerService.Insert(customer);

            if (c == null)
            {
                return BadRequest();
            }
            return CreatedAtRoute("GetCustomerById", new { id = c.Id }, c);
        }
    }
}
