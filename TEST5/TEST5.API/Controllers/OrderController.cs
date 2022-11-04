using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TEST5.API.Models.DTO;
using TEST5.API.Repositories;

namespace TEST5.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : Controller
    {
        private readonly IOrderInterface orderInterface;
        private readonly IMapper mapper;

        public OrderController(IOrderInterface orderInterface,IMapper mapper)
        {
            this.orderInterface = orderInterface;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders=await orderInterface.GetAllOrdersAsync();
            var ordersDTO=mapper.Map<List<Models.DTO.Order>>(orders);
            return Ok(ordersDTO);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetOrderAsync")]
        public async Task<IActionResult> GetOrderAsync(Guid id)
        {
            var order = await orderInterface.GetOrderAsync(id);
            var orderDTO=mapper.Map<Models.DTO.Order>(order);
            if(order==null)
            {
                return NotFound();
            }
            return Ok(orderDTO);
        }
        [HttpPost]
        public async Task<IActionResult> AddOrderAsync(AddOrderRequest addOrderRequest)
        {
            var order = new Models.Domain.Order()
            {
                OrderDate = DateTime.Now,
                Status = addOrderRequest.Status,
                CustomerID = addOrderRequest.CustomerID,
                ProductID = addOrderRequest.ProductID
            };

            order=await orderInterface.AddOrderAsync(order);

            var orderDTO = new Models.DTO.Order
            {
                ID= order.ID,
                OrderDate= order.OrderDate,
                Status = order.Status,
                ProductID= order.ProductID,
                CustomerID= order.CustomerID
            };
            return CreatedAtAction(nameof(GetOrderAsync), new { id = order.ID }, orderDTO);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteOrderAsync(Guid id)
        {
            var order=await orderInterface.DeleteOrderAsync(id);
            if(order==null)
            {
                return NotFound();
            }
            var orderDTO = new Models.DTO.Order
            {
                ID = order.ID,
                Status = order.Status,
                OrderDate = order.OrderDate,
                CustomerID = order.CustomerID,
                ProductID = order.ProductID
            };
            return Ok(orderDTO);
        }

        [HttpPut]
        [Route("{id:guid}")]

        public async Task<IActionResult> UpdateOrderAsync(Guid id,UpdateOrderRequest updateOrderRequest)
        {
            var order = new Models.Domain.Order
            {
                OrderDate = updateOrderRequest.OrderDate,
                Status = updateOrderRequest.Status,
                CustomerID = updateOrderRequest.CustomerID,
                ProductID= updateOrderRequest.ProductID
            };

            order=await orderInterface.UpdateOrderAsync(id, order);

            if(order==null)
            {
                return NotFound();
            }

            var orderDTO = new Models.DTO.Order
            {
                ID = order.ID,
                OrderDate = order.OrderDate,
                Status = order.Status,
                CustomerID = order.CustomerID,
                ProductID = order.ProductID
            };
            return Ok(orderDTO);
        }

        [HttpGet]
        [Route("/Orderdetails/{id:guid}")]
        public async Task<IActionResult> GetOrderDetailsAsync(Guid id)
        {
            var orderdetails = await orderInterface.GetOrderDetailsAsync(id);
            var orderdetailsDTO = mapper.Map<Models.DTO.OrderDetails>(orderdetails);
            if (orderdetails == null)
            {
                return NotFound();
            }
            return Ok(orderdetailsDTO);
        }
    }
}
