using ConsumeProducts.Models;

namespace ConsumeProducts.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductAPI _productAPI;

        public ProductService(IProductAPI productAPI)
        {
            _productAPI = productAPI;
        }
        public async Task<IEnumerable<ProductData>> GetAllProductsAsync()
        {
            return await _productAPI.GetAllProductsAsync();
        }

        public async Task<ProductData> GetProductAsync(int id)
        {
           return await _productAPI.GetProductsAsync(id);
        }
    }
}
