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

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return await tEST5DbContext.Orders.ToListAsync();
        }

        public async Task<Order> GetOrderAsync(Guid id)
        {
            return await tEST5DbContext.Orders.FirstOrDefaultAsync(x => x.ID == id);
        }
    }
}
