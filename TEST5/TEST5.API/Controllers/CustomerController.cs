using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using TEST5.API.Models.Domain;
using TEST5.API.Models.DTO;
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

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetCustomerAsync")]
        public async Task<IActionResult> GetCustomerAsync(Guid id)
        {
           var customer= await customerInterface.GetAsync(id);
           var customerDTO= mapper.Map<Models.DTO.Customer>(customer);

            if(customer==null)
            {
                return NotFound();
            }
            return Ok(customerDTO);

        }

        [HttpPost]
        public async Task<IActionResult> AddCustomerAsync(AddCustomerRequest addCustomerRequest)
        {
            //Request(DTO) to Domain Model
            var customer = new Models.Domain.Customer()
            {
                Name = addCustomerRequest.Name,
                Age = addCustomerRequest.Age,
                MobileNumber = addCustomerRequest.MobileNumber
            };

            //Pass details to Repository
            customer= await customerInterface.AddAync(customer);

            //Covert back to DTO

            var customerDTO = new Models.DTO.Customer
            {
                ID = customer.ID,
                Name = customer.Name,
                Age = customer.Age,
                MobileNumber = customer.MobileNumber
            };

            return CreatedAtAction(nameof(GetCustomerAsync), new { id = customerDTO.ID }, customerDTO);
        }

        [HttpDelete]
        [Route("{id:guid}")]

        public async Task<IActionResult> DeleteCustomerAsync(Guid id)
        {
            var customer=await customerInterface.DeleteAsync(id);
            if(customer == null)
            {
                return NotFound();
            }
            var customerDTO = new Models.DTO.Customer
            {
                ID = customer.ID,
                Name = customer.Name,
                Age = customer.Age,
                MobileNumber = customer.MobileNumber
            };
            return Ok(customerDTO);
        }
    }
}
