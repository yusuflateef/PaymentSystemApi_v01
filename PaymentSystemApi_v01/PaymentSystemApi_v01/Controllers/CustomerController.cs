using Microsoft.AspNetCore.Mvc;
using PaymentSystemApi_v01.Contracts;
using PaymentSystemApi_v01.Core;
using PaymentSystemApi_v01.DTO;

namespace PaymentSystemApi_v01.Controllers
{
    [ApiController]
    [Route("api/Customer")]
    public class CustomerController : ControllerBase
    {
        public ICustomerService _customerProvider { get; }
        public CustomerController(ICustomerService customerProvider)
        {
            _customerProvider = customerProvider;
        }

        [HttpPost]
        public ActionResult<IEnumerable<CustomerDto>> Customers(CustomerDto input)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var customers = _customerProvider.Customer(input);

            return Ok(customers);
        }

        [HttpGet]
        public ActionResult<IEnumerable<CustomerDto>> Customers()
        {
            var customers = _customerProvider.Customers().Result.customers;

            return Ok(customers);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDto>> CustomerId(string id)
        {
            var customers = await _customerProvider.CustomerById(id);

            return Ok(customers.customer);
        }

        [HttpGet("CustomerHistory/{nationalId}")]
        public async Task<ActionResult<(bool success,IEnumerable<TransactionHistoryDto> transaction, bool fail)>> CustomerByNationalId(string nationalId)
        {
            var (successful, transaction, fail) = await _customerProvider.TransactionHistory(nationalId);

            return Ok(new { successful, fail, transaction });
        }
    }

}
