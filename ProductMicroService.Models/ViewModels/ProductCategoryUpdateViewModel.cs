using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMicroService.Models.ViewModels
{
    public class ProductCategoryUpdateViewModel: ProductCategoryAddViewModel
    {
        public int Id { get; set; }
    }
}
