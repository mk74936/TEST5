using TEST5.API.Models.Domain;

namespace TEST5.API.Repositories
{
    public interface IProductInterface
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> GetAsync(Guid id);

        Task<Product> AddProductAsync(Product product);

        Task<Product> DeleteProductAsync(Guid id);

        Task<Product> UpdateProductAsync(Guid id,Product product);
    }
}
