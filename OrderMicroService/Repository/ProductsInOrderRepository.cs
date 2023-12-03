using Microsoft.EntityFrameworkCore;
using OrderMicroService.Data;
using OrderMicroService.Models;

namespace OrderMicroService.Repository
{
    public class ProductsInOrderRepository: IProductsInOrderRepository
    {
        private readonly DataContext _dbContext;

        public ProductsInOrderRepository(DataContext dataContext)
        {
            _dbContext = dataContext;
        }

        public async Task AddManyAsync(IEnumerable<int> productIds, int orderId)
        {
            var productsInOrder = new List<ProductInOrder>();

            foreach (var productId in productIds)
                productsInOrder.Add(new ProductInOrder() { OrderId = orderId, ProductId = productId });

            await _dbContext.AddRangeAsync(productsInOrder);

            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveManyAsync(IEnumerable<int> productIds, int orderId)
        {
            var productsInOrderToRemove = await _dbContext.ProductsInOrders.Where(x => productIds.Contains(x.ProductId) && x.OrderId == orderId).ToListAsync();

            _dbContext.RemoveRange(productsInOrderToRemove);

            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveByOrderIdAsync(int orderId)
        {
            var productsInOrderToRemove = await _dbContext.ProductsInOrders.Where(x => x.OrderId == orderId).ToListAsync();

            _dbContext.RemoveRange(productsInOrderToRemove);

            await _dbContext.SaveChangesAsync();
        }
    }

    public interface IProductsInOrderRepository
    {
        Task AddManyAsync(IEnumerable<int> productIds, int orderId);
        Task RemoveManyAsync(IEnumerable<int> productIds, int orderId);
        Task RemoveByOrderIdAsync(int orderId);
    }
}
