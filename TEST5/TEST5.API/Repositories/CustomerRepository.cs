using Microsoft.EntityFrameworkCore;
using TEST5.API.Data;
using TEST5.API.Models.Domain;

namespace TEST5.API.Repositories
{
    public class CustomerRepository : ICustomerInterface
    {
        private readonly TEST5DbContext tEST5DbContext;

        public CustomerRepository(TEST5DbContext tEST5DbContext)
        {
            this.tEST5DbContext = tEST5DbContext;
        }
        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await tEST5DbContext.Customers.ToListAsync();
        }
    }
}
