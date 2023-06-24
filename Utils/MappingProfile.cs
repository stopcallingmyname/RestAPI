using AutoMapper;
using RestAPI.Models;
using RestAPI.ViewModels;

namespace RestAPI.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductViewModel>()
                .ForMember(dest => dest.ProductType, opt => opt.MapFrom(src => src.ProductType.Name));

            CreateMap<Catalog, CatalogViewModel>()
               .ForMember(dest => dest.ProductType, opt => opt.MapFrom(src => src.ProductType.Name));
        }
    }
}
