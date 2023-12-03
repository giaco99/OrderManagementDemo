using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrderMicroService.QueryModels;
using OrderMicroService.Services;
using SharedModels.Order.ViewModels;

namespace OrderMicroService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("getById")]
        public async Task<OrderViewModel> GetByIdAsync(int orderId)
        {
            return await _orderService.GetByIdAsync(orderId);
        }

        [HttpPost("add")]
        public async Task AddAsync(OrderCreationQueryModel requestModel)
        {
            await _orderService.AddAsync(requestModel);
        }

        [HttpDelete("deleteById")]
        public async Task DeleteByIdAsync(int orderId)
        {
            await _orderService.DeleteByIdAsync(orderId);
        }

        [HttpPut("update")]
        public async Task UpdateAsync(OrderViewModel orderToUpdate)
        {
            await _orderService.UpdateAsync(orderToUpdate);
        }
    }
}
