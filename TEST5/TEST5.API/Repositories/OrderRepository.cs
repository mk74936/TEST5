using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TEST5.API.Data;
using TEST5.API.Models.Domain;

namespace TEST5.API.Repositories
{
    public class OrderRepository : IOrderInterface
    {
        private readonly TEST5DbContext tEST5DbContext;

        public OrderRepository(TEST5DbContext tEST5DbContext)
        {
            this.tEST5DbContext = tEST5DbContext;
        }

        public async Task<Order> AddOrderAsync(Order order)
        {
            order.ID = order.ID;
            await tEST5DbContext.AddAsync(order);
            await tEST5DbContext.SaveChangesAsync();
            return order;
        }

        public async Task<Order> DeleteOrderAsync(Guid id)
        {
           var order=await tEST5DbContext.Orders.FirstOrDefaultAsync(x=>x.ID==id);
            if(order==null)
            {
                return null;
            }

            tEST5DbContext.Orders.Remove(order);
            tEST5DbContext.SaveChangesAsync();
            return order;
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return await tEST5DbContext.Orders.ToListAsync();
        }

        public async Task<Order> GetOrderAsync(Guid id)
        {
            return await tEST5DbContext.Orders.FirstOrDefaultAsync(x => x.ID == id);
        }

        public async Task<Order> UpdateOrderAsync(Guid id, Order order)
        {
            var exorder=await tEST5DbContext.Orders.FirstOrDefaultAsync(x=>x.ID==id);
            if(exorder==null)
            {
                return null;
            }

            exorder.OrderDate = order.OrderDate;
            exorder.Status = order.Status;
            exorder.CustomerID = order.CustomerID;
            exorder.ProductID=order.ProductID;

            await tEST5DbContext.SaveChangesAsync();

            return exorder;


        }
        
        public async Task<OrderDetails> GetOrderDetailsAsync(Guid id)
        {
            return await tEST5DbContext.orderDetails.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
