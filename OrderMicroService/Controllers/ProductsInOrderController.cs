using Microsoft.AspNetCore.Mvc;
using OrderMicroService.QueryModels;
using OrderMicroService.Services;

namespace OrderMicroService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsInOrderController: ControllerBase
    {
        private readonly IProductsInOrderService _productsInOrderService;

        public ProductsInOrderController(IProductsInOrderService productsInOrderService)
        {
            _productsInOrderService = productsInOrderService;
        }

        [HttpPost("addMany")]
        public async Task AddManyAsync(ProductsInOrderRequestModel requestModel)
        {
            await _productsInOrderService.AddManyAsync(requestModel.ProductIds,requestModel.OrderId);
        }

        [HttpDelete("deleteMany")]
        public async Task DeleteManyAsync(ProductsInOrderRequestModel requestModel)
        {
            await _productsInOrderService.AddManyAsync(requestModel.ProductIds, requestModel.OrderId);
        }
    }
}
