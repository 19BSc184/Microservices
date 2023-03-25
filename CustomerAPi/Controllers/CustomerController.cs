using CustomerAPi.Model;
using CustomerAPi.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        [HttpPost]
        public async Task Post([FromBody] Customer customer)
        {
            await _customerRepository.AddCustomer(customer);
        }



    }
}
