using Microsoft.EntityFrameworkCore;
using ProductMicroService.Data;
using ProductMicroService.Models;

namespace ProductMicroService.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _dbContext;

        public ProductRepository(DataContext dataContext)
        {
            _dbContext = dataContext;
        }

        public async Task AddAsync(Product productToAdd)
        {
            await _dbContext.Products.AddAsync(productToAdd);

            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int productId)
        {
            var productToDelete = await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == productId);
            if (productToDelete == null)
                throw new Exception("product not present");

            _dbContext.Products.Remove(productToDelete);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> GetByCategoryIdAsync(int productCategoryId)
        {
            return await _dbContext.Products.Where(x => x.CategoryId == productCategoryId).ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int productId)
        {
            return await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == productId);
        }

        public async Task UpdateAsync(Product productToUpdate)
        {
            var toUpdate = await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == productToUpdate.Id);
            if (toUpdate == null)
                throw new Exception("product not present");

            toUpdate.Price= productToUpdate.Price;
            toUpdate.Name= productToUpdate.Name;
            toUpdate.Description = productToUpdate.Description;
            toUpdate.CategoryId= productToUpdate.CategoryId;

            await _dbContext.SaveChangesAsync();
        }
    }

    public interface IProductRepository
    {
        Task AddAsync(Product productToAdd);
        Task DeleteByIdAsync(int productId);
        Task<IEnumerable<Product>> GetByCategoryIdAsync(int productCategoryId);
        Task<Product> GetByIdAsync(int productId);
        Task UpdateAsync(Product productToUpdate);
    }
}
