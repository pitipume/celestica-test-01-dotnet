using Celestica.Models;
using Celestica.Services;
using Microsoft.AspNetCore.Mvc;

namespace Celestica.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private readonly ProductService _productService;
        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("{productName}")]
        public async Task<IActionResult> GetProductStatus(string productName)
        {
            var status = await _productService.CheckProductStatusAsync(productName, DateTime.Today);

            if (status == null)
            {
                throw new Exception("Cannot find the product.");
            }

            var response = new APIResponse<ProductStatus>()
            {
                code = 200,
                message = "success",
                data = status,
                status = true,
            };

            return Ok(response);
        }
    }
}
