using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TuneOrBuy.Data.Models;

namespace TuneOrBuy.Web.Data
{
    public class TuneOrBuyDbContext : IdentityDbContext<Buyer, IdentityRole<Guid>, Guid>
    {
        public TuneOrBuyDbContext(DbContextOptions<TuneOrBuyDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
               .Entity<Car>()
               .HasOne(c => c.Seller)
               .WithMany(s => s.CarsForSell)
               .HasForeignKey(c => c.SellerId)
               .OnDelete(DeleteBehavior.Restrict);

            builder
               .Entity<Part>()
               .HasOne(p => p.Seller)
               .WithMany(s => s.PartsForSell)
               .HasForeignKey(p => p.SellerId)
               .OnDelete(DeleteBehavior.Restrict);

            builder
               .Entity<CarService>()
               .HasOne(cs => cs.CarServiceOwner)
               .WithMany(cso => cso.CarServices)
               .HasForeignKey(cs => cs.CarServiceOwnerId)
               .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }

        public DbSet<Seller> Sellers { get; set; }
        public DbSet<CarServiceOwner> CarServiceOwners { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<CarService> CarServices { get; set; }
        public DbSet<Town> Towns { get; set; }
    }
}