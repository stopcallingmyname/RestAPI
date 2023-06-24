using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestAPI.Models;
using RestAPI.Models.DTO;
using RestAPI.ViewModels;

namespace RestAPI.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly IConfiguration _configuration;
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public ProductService(IConfiguration configuration, AppDbContext context, IMapper mapper)
        {
            _configuration = configuration;
            _context = context;
            _mapper = mapper;
        }

        public async Task<ActionResult<ProductViewModel>> CreateProduct(CreateProductDto product)
        {
            var productType = await _context.ProductType.SingleOrDefaultAsync(x => x.Name == product.ProductType);

            if (productType == null)
            {
                return new ObjectResult("Invalid Product Type Id")
                {
                    StatusCode = 400
                };
            }

            var result = await _context.Products.AddAsync(new Product
            {
                Name = product.Name,
                ProductTypeId = productType.Id,
                Description = product.Description
            });

            await _context.SaveChangesAsync();
            return _mapper.Map<ProductViewModel>(result.Entity);
        }

        public async Task DeleteProduct(string productId)
        {
            var result = await _context.Products.FirstOrDefaultAsync(x => x.Id.ToString() == productId);

            if (result != null)
            {
                _context.Products.Remove(result);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<ActionResult<ProductViewModel[]>> GetProducts()
        {
            var result = await _context.Products.Include(p => p.ProductType).ToArrayAsync();
            return _mapper.Map<ProductViewModel[]>(result);
        }

        public async Task<ActionResult<ProductViewModel>> UpdateProduct(ProductViewModel product)
        {
            var result = await _context.Products.FirstOrDefaultAsync(x => x.Id == product.Id);

            if (result != null) 
            {
                var productType = await _context.ProductType.FirstOrDefaultAsync(x => x.Name == product.ProductType);

                if (productType == null)
                {
                    return new ObjectResult("Invalid Product Type")
                    {
                        StatusCode = 400
                    };
                }

                result.Name = product.Name;
                result.ProductTypeId = productType.Id; 
                result.Description = product.Description;

                if (product.Id != null)
                    result.Id = product.Id;

                await _context.SaveChangesAsync();
                return _mapper.Map<ProductViewModel>(result);
            }

            return null;
        }
    }
}
