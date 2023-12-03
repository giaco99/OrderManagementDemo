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

        public async Task AddAsync(ProductViewModel productToAdd)
        {
            var product = _mapper.Map<Product>(productToAdd);
            await _productRepository.AddAsync(product);
        }

        public async Task DeleteByIdAsync(int productId)
        {
            await _productRepository.DeleteByIdAsync(productId);
        }

        public async Task<IEnumerable<ProductViewModel>> GetByCategoryIdAsync(int productCategoryId)
        {
            var productList =  await _productRepository.GetByCategoryIdAsync(productCategoryId);
            return _mapper.Map<IEnumerable<ProductViewModel>>(productList);
        }

        public async Task<ProductViewModel> GetByIdAsync(int productId)
        {
            var product =  await _productRepository.GetByIdAsync(productId);
            return _mapper.Map<ProductViewModel>(product);           
        }

        public async Task UpdateAsync(ProductViewModel productToUpdate)
        {
            var product = _mapper.Map<Product>(productToUpdate);
            await _productRepository.UpdateAsync(product);
        }
    }

    public interface IProductService
    {
        Task AddAsync(ProductViewModel productToAdd);
        Task DeleteByIdAsync(int productId);
        Task<IEnumerable<ProductViewModel>> GetByCategoryIdAsync(int productCategoryId);
        Task<ProductViewModel> GetByIdAsync(int productId);
        Task UpdateAsync(ProductViewModel productToUpdate);
    }
}
