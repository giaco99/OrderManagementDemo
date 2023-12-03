namespace SharedModels.Order.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public string OrderPaymentMethod { get; set; }
        public bool IsOrderDelivered { get; set; }
        public int CustomerAccountId { get; set; }
        public int CustomerAddressId { get; set; }
    }
}
