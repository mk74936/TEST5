using TEST5.API.Models.Domain;

namespace TEST5.API.Repositories
{
    public interface IOrderInterface
    {
        Task<IEnumerable<Order>> GetAllOrdersAsync();
        Task<Order> GetOrderAsync(Guid id);
        Task<Order> AddOrderAsync(Order order);

        Task<Order> DeleteOrderAsync(Guid id);

        Task<Order> UpdateOrderAsync(Guid id, Order order);

        Task<OrderDetails> GetOrderDetailsAsync(Guid id);
    }
}
