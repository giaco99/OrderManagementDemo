using SharedModels.Order.ViewModels;

namespace OrderMicroService.QueryModels
{
    public class OrderCreationQueryModel
    {
        public OrderViewModel Order { get; set; }

        public IEnumerable<int>? ProductIds { get; set; }
    }
}
