using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TEST5.API.Models.Domain;
using TEST5.API.Repositories;

namespace TEST5.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : Controller
    {
        private readonly ICustomerInterface customerInterface;
        private readonly IMapper mapper;

        public CustomerController(ICustomerInterface customerInterface, IMapper mapper)
        {
            this.customerInterface = customerInterface;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            var customers=await customerInterface.GetAllAsync();

            //return DTO regions
            //var customersDTO = new List<Models.DTO.Customer>();
            //customers.ToList().ForEach(Customer =>
            //{
            //    var customerDTO = new Models.DTO.Customer()
            //    {
            //        ID=Customer.ID,
            //        Name=Customer.Name,
            //        Age=Customer.Age,
            //        MobileNumber=Customer.MobileNumber
            //    };
            //    customersDTO.Add(customerDTO);
            //}

            //);
            var customersDTO=mapper.Map<List<Models.DTO.Customer>>(customers);
            return Ok(customersDTO);
        }
    }
}
