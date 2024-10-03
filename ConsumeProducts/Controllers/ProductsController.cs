using ConsumeProducts.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConsumeProducts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController (IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GeAllProducts()
        {
            try
            {
                var productData = await _productService.GetAllProductsAsync();
                return Ok(productData);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Failed to get product data: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            try
            {
                var productData = await _productService.GetProductAsync(id);
                return Ok(productData);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Failed to get product data: {ex.Message}");
            }
        }
    }
}
