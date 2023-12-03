using AutoMapper;
using OrderMicroService.Models;
using SharedModels.Order.ViewModels;

namespace OrderMicroService
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Order, OrderViewModel>();

            CreateMap<OrderViewModel, Order>();
        }
    }
}
