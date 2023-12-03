using Microsoft.AspNetCore.Mvc;
using ProductMicroService.Models.ViewModels;
using ProductMicroService.Services;

namespace ProductMicroService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController: ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getById")]
        public async Task<ProductViewModel> GetByIdAsync(int productId)
        {
            return await _productService.GetByIdAsync(productId);
        }

        [HttpGet("getByCategoryId")]
        public async Task<IEnumerable<ProductViewModel>> GetByCategoryIdAsync(int productCategoryId)
        {
            return await _productService.GetByCategoryIdAsync(productCategoryId);
        }

        [HttpPost("add")]
        public async Task AddAsync(ProductViewModel productToAdd)
        {
            await _productService.AddAsync(productToAdd);
        }

        [HttpDelete("deleteById")]
        public async Task DeleteByIdAsync(int productId)
        {
            await _productService.DeleteByIdAsync(productId);
        }

        [HttpPut("update")]
        public async Task UpdateAsync(ProductViewModel productToUpdate)
        {
            await _productService.UpdateAsync(productToUpdate);
        }
    }
}
