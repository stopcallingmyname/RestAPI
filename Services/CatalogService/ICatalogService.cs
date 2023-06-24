using Microsoft.AspNetCore.Mvc;
using RestAPI.Models.DTO;
using RestAPI.ViewModels;

namespace RestAPI.Services.CatalogService
{
    public interface ICatalogService
    {
        public Task<ActionResult<CatalogViewModel[]>> GetCatalogProducts();
        public Task<ActionResult<CatalogViewModel>> CreateCatalogProduct(CreateCatalogDto catalogProduct);
        public Task<ActionResult<CatalogViewModel>> UpdateCatalogProduct(CatalogViewModel catalogProductViewModel);
        public Task DeleteCatalogProduct(string id);
    }
}
