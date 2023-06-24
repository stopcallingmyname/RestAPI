using Microsoft.AspNetCore.Mvc;
using RestAPI.Models;
using RestAPI.Models.DTO;
using RestAPI.ViewModels;

namespace RestAPI.Services.ProductService
{
    public interface IProductService
    {
        public Task<ActionResult<ProductViewModel[]>> GetProducts();
        public Task<ActionResult<ProductViewModel>> CreateProduct(CreateProductDto product);
        public Task<ActionResult<ProductViewModel>> UpdateProduct(ProductViewModel productViewModel);
        public Task DeleteProduct(string id);
    }
}
