using Microsoft.EntityFrameworkCore;
using ServiceSeeker.Model;
using System.Data;



namespace ServiceSeeker.Data
{
    public class ServiceSeekerDB : DbContext
    {
        public ServiceSeekerDB(DbContextOptions<ServiceSeekerDB> options): base (options)
        {
            
        }

       // public ServiceSeekerDB(DbContextOptions options) : base(options)
       // {
        //}

        public DbSet<User> Users { get; set; }
    }
}
