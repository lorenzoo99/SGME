using Microsoft.EntityFrameworkCore;
using SGME.Model;
using WebApplication2.Model;

namespace WebApplication2.Context
{
    public class TestContext : DbContext
    {
        public TestContext(DbContextOptions Options) : base(Options)
        {

        }

        public DbSet<User> Users{ get; set; }
        public DbSet<UserType> UserTypes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);

          
                

        }
    }
    
}
