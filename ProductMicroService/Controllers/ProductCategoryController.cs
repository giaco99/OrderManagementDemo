using Microsoft.AspNetCore.Mvc;
using ProductMicroService.Models.ViewModels;
using ProductMicroService.Services;

namespace ProductMicroService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductCategoryController : ControllerBase
    {
        private readonly IProductCategoryService _productCategoryService;

        public ProductCategoryController(IProductCategoryService productCategoryService)
        {
            _productCategoryService = productCategoryService;
        }


        [HttpGet("getById")]
        public async Task<ProductCategoryUpdateViewModel> GetByIdAsync(int productCategoryId)
        {
            return await _productCategoryService.GetByIdAsync(productCategoryId);
        }

        [HttpPost("add")]
        public async Task AddAsync(ProductCategoryAddViewModel productCategoryToAdd)
        {
            await _productCategoryService.AddAsync(productCategoryToAdd);
        }

        [HttpDelete("deleteById")]
        public async Task DeleteByIdAsync(int productCategoryId)
        {
            await _productCategoryService.DeleteByIdAsync(productCategoryId);
        }

        [HttpPut("update")]
        public async Task UpdateAsync(ProductCategoryUpdateViewModel productCategoryToUpdate)
        {
            await _productCategoryService.UpdateAsync(productCategoryToUpdate);
        }
    }
}
