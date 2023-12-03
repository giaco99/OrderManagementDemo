using Microsoft.EntityFrameworkCore;
using OrderMicroService.Data;
using OrderMicroService.Models;
using OrderMicroService.Services;

namespace OrderMicroService.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext _dbContext;
        private readonly IProductsInOrderService _productsInOrderService;

        public OrderRepository(
            DataContext dataContext,
            IProductsInOrderService productsInOrderService)
        {
            _dbContext = dataContext;
            _productsInOrderService = productsInOrderService;
        }

        public async Task<int> AddAsync(Order orderToAdd)
        {
            await _dbContext.Orders.AddAsync(orderToAdd);

            await _dbContext.SaveChangesAsync();

            return orderToAdd.Id;
        }

        public async Task DeleteByIdAsync(int orderId)
        {
            var orderToDelete = await _dbContext.Orders.FirstOrDefaultAsync(x => x.Id == orderId);
            if (orderToDelete == null)
                throw new Exception("order not present");

            _dbContext.Orders.Remove(orderToDelete);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<Order> GetByIdAsync(int orderId)
        {
            return await _dbContext.Orders.FirstOrDefaultAsync(x => x.Id == orderId);
        }

        public async Task UpdateAsync(Order orderToUpdate)
        {
            var toUpdate = await _dbContext.Orders.FirstOrDefaultAsync(x => x.Id == orderToUpdate.Id);
            if (toUpdate == null)
                throw new Exception("order not present");

            toUpdate.OrderPaymentMethod = orderToUpdate.OrderPaymentMethod;
            toUpdate.IsOrderDelivered = orderToUpdate.IsOrderDelivered;

            await _dbContext.SaveChangesAsync();
        }
    }

    public interface IOrderRepository
    {
        Task<int> AddAsync(Order orderToAdd);
        Task DeleteByIdAsync(int orderId);
        Task<Order> GetByIdAsync(int orderId);
        Task UpdateAsync(Order orderToUpdate);
    }
}
