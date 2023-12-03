using Microsoft.EntityFrameworkCore;
using ProductMicroService.Models;

namespace ProductMicroService.Data
{
    public class DataContext : DbContext, IDataContext
    {
        public DbSet<Product> Products{ get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
    }

    public interface IDataContext
    {

    }
}
