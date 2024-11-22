using Microsoft.EntityFrameworkCore;
using AutoShopManager.Models;

namespace AutoShopManager.Data
{
    public class AutoShopContext : DbContext
    {
        public AutoShopContext(DbContextOptions<AutoShopContext> options)
            : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; } = default!;
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Repair> Repairs { get; set; } = default!;
        public DbSet<Part> Parts { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        public DbSet<User> Users { get; set; }
    }
}