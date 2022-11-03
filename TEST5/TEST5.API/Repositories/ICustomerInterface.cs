using Microsoft.EntityFrameworkCore;
using TEST5.API.Models.Domain;

namespace TEST5.API.Repositories
{
    public interface ICustomerInterface
    {
        Task<IEnumerable<Customer>> GetAllAsync();

        Task<Customer> GetAsync(Guid id);

        Task<Customer> AddAync(Customer customer);

        Task<Customer> DeleteAsync(Guid id);

    }
}
