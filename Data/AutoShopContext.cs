using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
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
    }
}