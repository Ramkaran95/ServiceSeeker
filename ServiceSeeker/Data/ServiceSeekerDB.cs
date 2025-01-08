using Microsoft.EntityFrameworkCore;
using ServiceSeeker.Model;

namespace ServiceSeeker.Data
{
    public class ServiceSeekerDB : DbContext
    {
        public ServiceSeekerDB(DbContextOptions<ServiceSeekerDB> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Provider> Providers { get; set; }  


       protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure a unique constraint for multiple properties
            modelBuilder.Entity<User>()
                .HasIndex(e => new { e.Email, e.UserName})
                .IsUnique();
        }

    }
}
