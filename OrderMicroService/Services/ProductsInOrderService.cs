using OrderMicroService.Repository;

namespace OrderMicroService.Services
{
    public class ProductsInOrderService: IProductsInOrderService
    {
        private readonly IProductsInOrderRepository _productsInOrderRepository;

        public ProductsInOrderService(IProductsInOrderRepository productsInOrderRepository)
        {
            _productsInOrderRepository = productsInOrderRepository;
        }

        public async Task AddManyAsync(IEnumerable<int> productIds, int orderId)
        {
            await _productsInOrderRepository.AddManyAsync(productIds, orderId);
        }

        public async Task RemoveByOrderIdAsync(int orderId)
        {
            await _productsInOrderRepository.RemoveByOrderIdAsync(orderId);
        }

        public async Task RemoveManyAsync(IEnumerable<int> productIds, int orderId)
        {
            await _productsInOrderRepository.RemoveManyAsync(productIds, orderId);
        }
    }

    public interface IProductsInOrderService
    {
        Task AddManyAsync(IEnumerable<int> productIds, int orderId);
        Task RemoveManyAsync(IEnumerable<int> productIds, int orderId);
        Task RemoveByOrderIdAsync(int orderId);
    }
}
