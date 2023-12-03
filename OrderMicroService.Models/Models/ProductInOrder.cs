using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderMicroService.Models
{
    public class ProductInOrder
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }

        [ForeignKey("OrderId")]
        public virtual Order Order { get; set; }
    }
}
