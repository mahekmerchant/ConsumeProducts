using ConsumeProducts.Models;

namespace ConsumeProducts.Services
{
    public interface IProductService
    {
        Task<ProductData> GetProductAsync(int id);
        Task<IEnumerable<ProductData>> GetAllProductsAsync();
    }
}
