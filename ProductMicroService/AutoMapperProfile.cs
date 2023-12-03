using AutoMapper;
using ProductMicroService.Models;
using ProductMicroService.Models.ViewModels;

namespace ProductMicroService
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, ProductAddViewModel>();

            CreateMap<ProductAddViewModel, Product>();

            CreateMap<Product, ProductUpdateViewModel>();

            CreateMap<ProductUpdateViewModel, Product>();

            CreateMap<ProductCategoryAddViewModel, ProductCategory>();

            CreateMap<ProductCategory, ProductCategoryAddViewModel>();

            CreateMap<ProductCategoryUpdateViewModel, ProductCategory>();

            CreateMap<ProductCategory, ProductCategoryUpdateViewModel>();
        }
    }
}
