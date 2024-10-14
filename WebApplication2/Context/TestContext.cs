using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders.Composite;
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
        public DbSet<PermissionPerUserType> PermissionPerUserTypes { get; set; }
        public DbSet<Permissions> Permissions { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<UsageHistory> UsageHistories { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<ContentUser> ContentUsers { get; set; } 
       

        
       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);


            modelBuilder.Entity<PermissionPerUserType>()
                   .HasKey(p => new { p.UserTypeID, p.PermissionID });

            modelBuilder.Entity<Permissions>()
                .HasKey(p => p.PermissionID);

            modelBuilder.Entity<Platform>()
                .HasKey(pl => pl.PlatformID );

            modelBuilder.Entity<UsageHistory>()
                .HasKey(uh => uh.UsageHistoryID);

            modelBuilder.Entity<Content>()
                .HasKey(c => c.ContentID);

            modelBuilder.Entity<PermissionPerUserType>()
                .HasOne(pt => pt.UserType)
                .WithMany(ut => ut.PermissionPerUserType)
                .HasForeignKey(pt => pt.UserTypeID);

            modelBuilder.Entity<PermissionPerUserType>()
                .HasOne(pt => pt.Permission)
                .WithMany(p => p.PermissionPerUserTypes)
                .HasForeignKey(pt => pt.PermissionID);

            modelBuilder.Entity<ContentUser>()
                .HasKey(cu => cu.ContentUserID);

            // Configurar relaciones en el modelo
            modelBuilder.Entity<ContentUser>()
                .HasOne(cu => cu.User)
                .WithMany( u => u.ContentUsers)
                .HasForeignKey(cu => cu.UserID);
          

            modelBuilder.Entity<ContentUser>()
                .HasOne(cu => cu.Contents)
                .WithMany(c => c.ContentUsers)
                .HasForeignKey(cu => cu.ContentID);
        
        }
    }




}
    
    

