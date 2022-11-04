using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public async Task<Product> AddProductAsync(Product product)
        {
            product.ID = Guid.NewGuid();
            await tEST5DbContext.AddAsync(product);
            await tEST5DbContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product> DeleteProductAsync(Guid id)
        {
            var product = await tEST5DbContext.Products.FirstOrDefaultAsync(x => x.ID == id);
            if(product == null)
            {
                return null;
            }

            tEST5DbContext.Products.Remove(product);
            await tEST5DbContext.SaveChangesAsync();
            return product;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await tEST5DbContext.Products.ToListAsync();
        }

        public async Task<Product> GetAsync(Guid id)
        {
            return await tEST5DbContext.Products.FirstOrDefaultAsync(x => x.ID == id);
        }
    }
}
