using Refit;
using ConsumeProducts.Models;

namespace ConsumeProducts.Services
{
    public interface IProductAPI
    {
        [Get("/Products")]
        Task<IEnumerable<ProductData>> GetAllProductsAsync();

        [Get("/Products/{id}")]
        Task<ProductData> GetProductsAsync(int id);
    }
}
