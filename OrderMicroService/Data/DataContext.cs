using Microsoft.EntityFrameworkCore;
using OrderMicroService.Models;

namespace OrderMicroService.Data
{
    public class DataContext: DbContext, IDataContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<ProductInOrder> ProductsInOrders { get; set; }
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {
            
        }
    }

    public interface IDataContext
    {
        
    }
}
