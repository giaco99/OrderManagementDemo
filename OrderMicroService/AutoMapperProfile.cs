using AutoMapper;
using OrderMicroService.Models;
using OrderMicroService.Models.ViewModels;
using SharedModels.Order.ViewModels;

namespace OrderMicroService
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Order, OrderAddViewModel>();

            CreateMap<OrderAddViewModel, Order>();

            CreateMap<Order, OrderUpdateViewModel>();

            CreateMap<OrderUpdateViewModel, Order>();
        }
    }
}
