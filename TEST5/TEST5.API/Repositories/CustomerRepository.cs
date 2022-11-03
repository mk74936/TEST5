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

        public async Task<Customer> AddAync(Customer customer)
        {
            customer.ID=Guid.NewGuid();
            await tEST5DbContext.AddAsync(customer);
            await tEST5DbContext.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer> DeleteAsync(Guid id)
        {
            var customer = await tEST5DbContext.Customers.FirstOrDefaultAsync(x => x.ID == id);

            if(customer == null)
            {
                return null;
            }

            tEST5DbContext.Customers.Remove(customer);
            await tEST5DbContext.SaveChangesAsync();
            return customer;
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await tEST5DbContext.Customers.ToListAsync();
        }

        public async Task<Customer> GetAsync(Guid id)
        {
           return await tEST5DbContext.Customers.FirstOrDefaultAsync(x => x.ID == id);          
        }
    }
}
