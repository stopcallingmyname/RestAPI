using Microsoft.AspNetCore.Mvc;
using RestAPI.Models.DTO;
using RestAPI.Services.ProductService;
using RestAPI.ViewModels;

namespace RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public Task<ActionResult<ProductViewModel[]>> GetProducts()
        {
            return _productService.GetProducts();
        }

        [HttpPost]
        public Task<ActionResult<ProductViewModel>> CreateProduct([FromBody] CreateProductDto product)
        {
            return _productService.CreateProduct(product);
        }

        [HttpPut]
        public Task<ActionResult<ProductViewModel>> UpdateProduct([FromBody] ProductViewModel productViewModel)
        {
            return _productService.UpdateProduct(productViewModel);
        }

        [HttpDelete("{productId}")]
        public Task DeleteProduct(string productId)
        {
            return _productService.DeleteProduct(productId);
        }
    }
}
