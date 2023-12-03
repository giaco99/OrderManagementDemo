using AutoMapper;
using ProductMicroService.Models;
using ProductMicroService.Models.ViewModels;
using ProductMicroService.Repository;

namespace ProductMicroService.Services
{
    public class ProductCategoryService: IProductCategoryService
    {
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductCategoryService(
            IProductCategoryRepository productCategoryRepository,
            IProductService productService,
            IMapper mapper)
        {
            _productCategoryRepository = productCategoryRepository;
            _productService = productService;
            _mapper = mapper;
        }

        public async Task AddAsync(ProductCategoryAddViewModel productCategoryToAdd)
        {
            var dto = _mapper.Map<ProductCategory>(productCategoryToAdd);
            await _productCategoryRepository.AddAsync(dto);
        }

        public async Task DeleteByIdAsync(int productCategoryId)
        {
            var categoryProducts = await _productService.GetByCategoryIdAsync(productCategoryId);
            if (categoryProducts.Any())
                throw new Exception("you can't delete a category that has products!");

            await _productCategoryRepository.DeleteByIdAsync(productCategoryId);
        }

        public async Task<ProductCategoryUpdateViewModel> GetByIdAsync(int productCategoryId)
        {
            var result = await _productCategoryRepository.GetByIdAsync(productCategoryId);
            return _mapper.Map<ProductCategoryUpdateViewModel>(result);
        }

        public async Task UpdateAsync(ProductCategoryUpdateViewModel productCategoryToUpdate)
        {
            var dto = _mapper.Map<ProductCategory>(productCategoryToUpdate);
            await _productCategoryRepository.UpdateAsync(dto);
        }
    }

    public interface IProductCategoryService
    {
        Task AddAsync(ProductCategoryAddViewModel productCategoryToAdd);
        Task DeleteByIdAsync(int productCategoryId);
        Task<ProductCategoryUpdateViewModel> GetByIdAsync(int productCategoryId);
        Task UpdateAsync(ProductCategoryUpdateViewModel productCategoryToUpdate);
    }
}
