using TEST5.API.Models.Domain;

namespace TEST5.API.Repositories
{
    public interface IProductInterface
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
    }
}
