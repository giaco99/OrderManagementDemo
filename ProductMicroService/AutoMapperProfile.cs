using AutoMapper;
using ProductMicroService.Models;
using ProductMicroService.Models.ViewModels;

namespace ProductMicroService
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, ProductViewModel>();

            CreateMap<ProductViewModel, Product>();

            CreateMap<ProductCategoryViewModel, ProductCategory>();

            CreateMap<ProductCategory, ProductCategoryViewModel>();
        }
    }
}
