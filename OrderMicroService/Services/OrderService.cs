﻿using AutoMapper;
using OrderMicroService.Models;
using OrderMicroService.QueryModels;
using OrderMicroService.Repository;
using SharedModels.Order.ViewModels;

namespace OrderMicroService.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductsInOrderRepository _productsInOrderRepository;
        private readonly IMapper _mapper;
        public OrderService(
            IOrderRepository orderRepository,
            IProductsInOrderRepository productsInOrderRepository,
            IMapper mapper)
        {
            _orderRepository = orderRepository;
            _productsInOrderRepository = productsInOrderRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(OrderCreationQueryModel requestModel)
        {
            var orderToAdd = _mapper.Map<Order>(requestModel.Order); 
            orderToAdd.OrderCreationTime = DateTime.Now;
            
            var orderId = await _orderRepository.AddAsync(orderToAdd);

            if(requestModel.ProductIds != null && requestModel.ProductIds.Any())
            {
                await _productsInOrderRepository.AddManyAsync(requestModel.ProductIds, orderId);
            }
        }

        public async Task DeleteByIdAsync(int orderId)
        {
            await _productsInOrderRepository.RemoveByOrderIdAsync(orderId);
            await _orderRepository.DeleteByIdAsync(orderId);
        }

        public async Task<OrderViewModel> GetByIdAsync(int orderId)
        {
            var order = await _orderRepository.GetByIdAsync(orderId);
            return _mapper.Map<OrderViewModel>(order);
        }

        public async Task UpdateAsync(OrderViewModel orderToUpdate)
        {
            var order = _mapper.Map<Order>(orderToUpdate);
            await _orderRepository.UpdateAsync(order);
        }
    }

    public interface IOrderService
    {
        Task AddAsync(OrderCreationQueryModel requestModel);
        Task DeleteByIdAsync(int orderId);
        Task<OrderViewModel> GetByIdAsync(int orderId);
        Task UpdateAsync(OrderViewModel orderToUpdate);
    }
}
