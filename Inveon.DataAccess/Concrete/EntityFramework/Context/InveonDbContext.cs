using Inveon.Entities.Concrete;
using System.Data.Entity;

namespace Inveon.DataAccess.Concrete.EntityFramework.Context
{
    public class InveonDbContext : DbContext
    {
        public InveonDbContext() : base("Name=InveonDbContext")
        {
            Database.SetInitializer<InveonDbContext>(null);
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().ToTable("Product", "dbo");
            modelBuilder.Entity<ProductImage>().ToTable("ProductImage", "dbo");

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
    }
}
