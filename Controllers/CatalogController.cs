using Microsoft.AspNetCore.Mvc;
using RestAPI.Models.DTO;
using RestAPI.Services.CatalogService;
using RestAPI.ViewModels;

namespace RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : Controller
    {
        private readonly ICatalogService _catalogService;
        public CatalogController(ICatalogService catalogService)
        {   
            _catalogService = catalogService;
        }

        [HttpGet]
        public Task<ActionResult<CatalogViewModel[]>> GetCatalogProducts()
        {
            return _catalogService.GetCatalogProducts();
        }

        [HttpPost]
        public Task<ActionResult<CatalogViewModel>> CreateCatalogProduct([FromBody] CreateCatalogDto catalogProduct)
        {
            return _catalogService.CreateCatalogProduct(catalogProduct);
        }

        [HttpPut]
        public Task<ActionResult<CatalogViewModel>> UpdateCatalogProduct([FromBody] CatalogViewModel catalogProductViewModel)
        {
            return _catalogService.UpdateCatalogProduct(catalogProductViewModel);
        }

        [HttpDelete("{catalogProductId}")]
        public Task DeleteCatalogProduct(string catalogProductId)
        {
            return _catalogService.DeleteCatalogProduct(catalogProductId);
        }
    }
}
