using Microsoft.AspNetCore.Mvc;
using TEST5.API.Data;
using TEST5.API.Models.Domain;

namespace TEST5.API.Repositories
{
    public class ProductRepository : IProductInterface
    {
        private readonly TEST5DbContext tEST5DbContext;

        public ProductRepository(TEST5DbContext tEST5DbContext)
        {
            this.tEST5DbContext = tEST5DbContext;
        }
        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return tEST5DbContext.Products.ToList();
        }
    }
}
