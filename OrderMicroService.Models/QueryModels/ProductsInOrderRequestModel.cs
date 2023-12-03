namespace OrderMicroService.QueryModels
{
    public class ProductsInOrderRequestModel
    {
        public int OrderId { get; set; }
        public IEnumerable<int> ProductIds { get; set; }
    }
}
