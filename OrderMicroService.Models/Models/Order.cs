using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderMicroService.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime OrderCreationTime { get; set; }
        public string OrderPaymentMethod{ get; set; }
        public bool IsOrderDelivered { get; set;  }
        public int CustomerAccountId { get; set; }
        public int CustomerAddressId { get; set; }
    }
}
