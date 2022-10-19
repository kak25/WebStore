using Microsoft.EntityFrameworkCore;
using Store.Models;


namespace Store.DataAccess.Data
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        } 

        public DbSet<Category> Categories { get; set; }
        
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
