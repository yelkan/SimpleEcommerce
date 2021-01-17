using Inveon.Entities.Concrete;
using System.Data.Entity;

namespace Inveon.DataAccess.Concrete.EntityFramework.Context
{
    public class AuthenticationDbContext : DbContext
    {
        public AuthenticationDbContext() : base("Name=InveonDbContext")
        {
            Database.SetInitializer<InveonDbContext>(null);
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().ToTable("User", "dbo");
            modelBuilder.Entity<Role>().ToTable("Role", "dbo");

            modelBuilder.Entity<User>()
                .HasMany(u => u.Roles)
                .WithMany(r => r.Users)
                .Map(m =>
                {
                    m.ToTable("UserRole", "dbo");
                    m.MapLeftKey("UserId");
                    m.MapRightKey("RoleId");
                });


        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

    }
}
