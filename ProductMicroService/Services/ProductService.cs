using AutoMapper;
using ProductMicroService.Models;
using ProductMicroService.Models.ViewModels;
using ProductMicroService.Repository;


namespace ProductMicroService.Services
{
    public class ProductService: IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(ProductAddViewModel productToAdd)
        {
            var product = _mapper.Map<Product>(productToAdd);
            await _productRepository.AddAsync(product);
        }

        public async Task DeleteByIdAsync(int productId)
        {
            await _productRepository.DeleteByIdAsync(productId);
        }

        public async Task<IEnumerable<ProductUpdateViewModel>> GetByCategoryIdAsync(int productCategoryId)
        {
            var productList =  await _productRepository.GetByCategoryIdAsync(productCategoryId);
            return _mapper.Map<IEnumerable<ProductUpdateViewModel>>(productList);
        }

        public async Task<ProductUpdateViewModel> GetByIdAsync(int productId)
        {
            var product =  await _productRepository.GetByIdAsync(productId);
            return _mapper.Map<ProductUpdateViewModel>(product);           
        }

        public async Task UpdateAsync(ProductUpdateViewModel productToUpdate)
        {
            var product = _mapper.Map<Product>(productToUpdate);
            await _productRepository.UpdateAsync(product);
        }
    }

    public interface IProductService
    {
        Task AddAsync(ProductAddViewModel productToAdd);
        Task DeleteByIdAsync(int productId);
        Task<IEnumerable<ProductUpdateViewModel>> GetByCategoryIdAsync(int productCategoryId);
        Task<ProductUpdateViewModel> GetByIdAsync(int productId);
        Task UpdateAsync(ProductUpdateViewModel productToUpdate);
    }
}
