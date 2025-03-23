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

        public DbSet<Booking> Bookings { get; set; }



    }
}
