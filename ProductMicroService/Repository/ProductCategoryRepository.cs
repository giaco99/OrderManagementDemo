using Microsoft.EntityFrameworkCore;
using ProductMicroService.Data;
using ProductMicroService.Models;

namespace ProductMicroService.Repository
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly DataContext _dbContext;

        public ProductCategoryRepository(DataContext dataContext)
        {
            _dbContext = dataContext;
        }
        public async Task AddAsync(ProductCategory productCategoryToAdd)
        {
            await _dbContext.ProductCategories.AddAsync(productCategoryToAdd);

            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int productCategoryId)
        {
            var productCategoryToDelete = await _dbContext.ProductCategories.FirstOrDefaultAsync(x => x.Id == productCategoryId);
            if (productCategoryToDelete == null)
                throw new Exception("product category not present");

            _dbContext.ProductCategories.Remove(productCategoryToDelete);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<ProductCategory> GetByIdAsync(int productCategoryId)
        {
            return await _dbContext.ProductCategories.FirstOrDefaultAsync(x => x.Id == productCategoryId);
        }

        public async Task UpdateAsync(ProductCategory productCategoryToUpdate)
        {
            var toUpdate = await _dbContext.ProductCategories.FirstOrDefaultAsync(x => x.Id == productCategoryToUpdate.Id);
            if (toUpdate == null)
                throw new Exception("product category not present");

            toUpdate.Name = productCategoryToUpdate.Name;
            toUpdate.Description = productCategoryToUpdate.Description;

            await _dbContext.SaveChangesAsync();
        }
    }

    public interface IProductCategoryRepository
    {
        Task AddAsync(ProductCategory productCategoryToAdd);
        Task DeleteByIdAsync(int productCategoryId);
        Task<ProductCategory> GetByIdAsync(int productCategoryId);
        Task UpdateAsync(ProductCategory productCategoryToUpdate);
    }
}
