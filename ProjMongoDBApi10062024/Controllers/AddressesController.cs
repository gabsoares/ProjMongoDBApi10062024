using Microsoft.AspNetCore.Mvc;
using ProjMongoDBApi10062024.Models;
using ProjMongoDBApi10062024.Services;

namespace ProjMongoDBApi10062024.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly AddressService _addressService;

        public AddressesController(AddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpGet]
        public ActionResult<List<Address>> Get() => _addressService.Get();

        [HttpGet("{id:length(24)}", Name = "GetAddressById")]
        public ActionResult<Address> GetById(string id)
        {
            return _addressService.GetById(id);
        }

        [HttpGet("{cep:length(8)}")]
        public ActionResult<AddressDTO> GetPostOffice(string cep)
        {
            return PostOfficeService.GetAddress(cep).Result;
        }

        [HttpPost]
        public ActionResult<Address> Insert(Address address)
        {
            _addressService.Insert(address);
            return CreatedAtRoute("GetAddressById", new { id = address.Id }, address);
        }
    }
}
