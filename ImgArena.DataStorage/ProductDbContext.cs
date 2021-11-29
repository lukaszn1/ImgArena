using Microsoft.EntityFrameworkCore;

namespace ImgArena.DataStorage
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options)
            : base(options)
        { }

        public DbSet<Product.Product> Products { get; set; }
    }
}
