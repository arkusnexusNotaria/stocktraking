using Arkusnexus.StockTaking.ApplicationCore.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Arkusnexus.StockTaking.Infrastructure.Data
{
    public class StockTakingDbContext : IdentityDbContext<IdentityUser>
    {
        public StockTakingDbContext(DbContextOptions<StockTakingDbContext> options) : base(options) 
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Device> Devices { get; set; }
        public DbSet<DeviceItem> DeviceItems { get; set; }

    }
}
