using SharedModels.Order.ViewModels;

namespace OrderMicroService.QueryModels
{
    public class OrderCreationQueryModel
    {
        public OrderAddViewModel Order { get; set; }

        public IEnumerable<int>? ProductIds { get; set; }
    }
}
