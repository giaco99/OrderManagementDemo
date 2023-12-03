namespace SharedModels.Order.ViewModels
{
    public class OrderAddViewModel
    {
        public string OrderPaymentMethod { get; set; }
        public bool IsOrderDelivered { get; set; }
        public int CustomerAccountId { get; set; }
        public int CustomerAddressId { get; set; }
    }
}
