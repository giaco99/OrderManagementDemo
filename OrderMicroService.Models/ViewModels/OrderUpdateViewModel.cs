using SharedModels.Order.ViewModels;

namespace OrderMicroService.Models.ViewModels
{
    public class OrderUpdateViewModel : OrderAddViewModel
    {
        public int Id { get; set; }
    }
}
