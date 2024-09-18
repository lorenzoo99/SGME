using Microsoft.EntityFrameworkCore;
using SGME.Model;

namespace WebApplication2.Context
{
    public class TestContext : DbContext
    {
        public TestContext(DbContextOptions Options) : base(Options)
        {

        }

        public DbSet<User> Users{ get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<Record> Records { get; set; }
        public DbSet<Comments> Comment { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);



          
                

        }
    }
    
}
