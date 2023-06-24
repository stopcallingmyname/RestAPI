using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestAPI.Models;
using RestAPI.Models.DTO;
using RestAPI.ViewModels;

namespace RestAPI.Services.CatalogService
{
    public class CatalogService : ICatalogService
    {
        private readonly IConfiguration _configuration;
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public CatalogService(IConfiguration configuration, AppDbContext context, IMapper mapper)
        {
            _configuration = configuration;
            _context = context;
            _mapper = mapper;
        }

        public async Task<ActionResult<CatalogViewModel>> CreateCatalogProduct(CreateCatalogDto catalogProduct)
        {
            //var productType = await _context.ProductType.FindAsync(catalogProduct.ProductTypeId);
            var productType = await _context.ProductType.SingleOrDefaultAsync(x => x.Name == catalogProduct.ProductType);

            if (productType == null)
            {
                return new ObjectResult("Invalid Product Type Id")
                {
                    StatusCode = 400
                };
            }

            var result = await _context.Catalog.AddAsync(new Catalog
            {
                Name = catalogProduct.Name,
                ProductTypeId = productType.Id,
                Description = catalogProduct.Description
            });

            await _context.SaveChangesAsync();
            return _mapper.Map<CatalogViewModel>(result.Entity);
        }

        public async Task DeleteCatalogProduct(string catalogProductId)
        {
            var result = await _context.Catalog.FirstOrDefaultAsync(x => x.Id.ToString() == catalogProductId);

            if (result != null)
            {
                _context.Catalog.Remove(result);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<ActionResult<CatalogViewModel[]>> GetCatalogProducts()
        {
            var result = await _context.Catalog.Include(p => p.ProductType).ToArrayAsync();
            return _mapper.Map<CatalogViewModel[]>(result);
        }

        public async Task<ActionResult<CatalogViewModel>> UpdateCatalogProduct(CatalogViewModel catalogProduct)
        {
            var result = await _context.Catalog.FirstOrDefaultAsync(x => x.Id == catalogProduct.Id);

            if (result != null)
            {
                var productType = await _context.ProductType.FirstOrDefaultAsync(x => x.Name == catalogProduct.ProductType);

                if (productType == null)
                {
                    return new ObjectResult("Invalid Product Type")
                    {
                        StatusCode = 400
                    };
                }

                result.Name = catalogProduct.Name;
                result.ProductTypeId = productType.Id;
                result.Description = catalogProduct.Description;

                if (catalogProduct.Id != null)
                    result.Id = catalogProduct.Id;

                await _context.SaveChangesAsync();
                return _mapper.Map<CatalogViewModel>(result);
            }

            return null;
        }
    }
}
