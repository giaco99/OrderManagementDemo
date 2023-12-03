using System.ComponentModel.DataAnnotations;

namespace ProductMicroService.Models
{
    public class ProductCategory
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
