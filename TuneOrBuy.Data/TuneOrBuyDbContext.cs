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

            builder
               .Entity<Car>()
               .Property(c => c.Price)
               .HasPrecision(18, 2);

            builder
               .Entity<Part>()
               .Property(p => p.Price)
               .HasPrecision(18, 2);

            builder
               .Entity<Town>()
               .HasData(SeedTowns());

            base.OnModelCreating(builder);
        }

        public DbSet<Seller> Sellers { get; set; }
        public DbSet<CarServiceOwner> CarServiceOwners { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<CarService> CarServices { get; set; }
        public DbSet<Town> Towns { get; set; }

        private List<Town> SeedTowns()
        {
            List<Town> towns = new List<Town>()
            {
                new Town()
                {
                    Id = 1,
                    Name = "София",
                },
                new Town()
                {
                    Id = 2,
                    Name = "Варна",
                },
                new Town()
                {
                    Id = 3,
                    Name = "Пловдив",
                },
                new Town()
                {
                    Id = 4,
                    Name = "Враца",
                },
                new Town()
                {
                    Id = 5,
                    Name = "Бургас",
                },
                new Town()
                {
                    Id = 6,
                    Name = "Дупница",
                },
                new Town()
                {
                    Id = 7,
                    Name = "Стара Загора",
                },
                new Town()
                {
                    Id = 8,
                    Name = "Монтана",
                },
                new Town()
                {
                    Id = 9,
                    Name = "Плевен",
                },
                new Town()
                {
                    Id = 10,
                    Name = "Хасково",
                },
                new Town()
                {
                    Id = 11,
                    Name = "Русе",
                },
                new Town()
                {
                    Id = 12,
                    Name = "Шумен",
                },
                new Town()
                {
                    Id = 13,
                    Name = "Сливен",
                },
                new Town()
                {
                    Id = 14,
                    Name = "Добрич",
                },
                new Town()
                {
                    Id = 15,
                    Name = "Велико Търново",
                },
                new Town()
                {
                    Id = 16,
                    Name = "Перник",
                },
                new Town()
                {
                    Id = 17,
                    Name = "Благоевград",
                },
                new Town()
                {
                    Id = 18,
                    Name = "Пазарджик",
                },
                new Town()
                {
                    Id = 19,
                    Name = "Габрово",
                },
                new Town()
                {
                    Id = 20,
                    Name = "Казанлък",
                },
                new Town()
                {
                    Id = 21,
                    Name = "Силистра",
                },
                new Town()
                {
                    Id = 22,
                    Name = "Кюстендил",
                },
                new Town()
                {
                    Id = 23,
                    Name = "Разград",
                },
                new Town()
                {
                    Id = 24,
                    Name = "Кърджали",
                },
                new Town()
                {
                    Id = 25,
                    Name = "Търговище",
                },
                new Town()
                {
                    Id = 26,
                    Name = "Димитровград",
                },
                new Town()
                {
                    Id = 27,
                    Name = "Троян",
                },
                new Town()
                {
                    Id = 28, 
                    Name = "Петрич"
                },
                new Town()
                {
                    Id = 29,
                    Name = "Видин",
                },
                new Town()
                {
                    Id = 30,
                    Name = "Лясковец",
                },
                new Town()
                {
                    Id = 31,
                    Name = "Гоце Делчев",
                },
                new Town()
                {
                    Id = 32,
                    Name = "Ямбол",
                },
                new Town()
                {
                    Id = 33,
                    Name = "Асеновград",
                },
                new Town()
                {
                    Id = 34,
                    Name = "Горна Оряховица",
                },
                new Town()
                {
                    Id = 35,
                    Name = "Провадия",
                },
                new Town()
                {
                    Id = 36,
                    Name = "Елин Пелин",
                },
                new Town()
                {
                    Id = 37,
                    Name = "Червенбряг",
                },
                new Town()
                {
                    Id = 38,
                    Name = "Панагюрище",
                },
                new Town()
                {
                    Id = 39,
                    Name = "Карлово",
                },
                new Town()
                {
                    Id = 40,
                    Name = "Драгичево",
                },
                new Town()
                {
                    Id = 41,
                    Name = "Карнобат",
                },
                new Town()
                {
                    Id = 42,
                    Name = "Смолян",
                },
                new Town()
                {
                    Id = 43,
                    Name = "Свищов",
                },
                new Town()
                {
                    Id = 44,
                    Name = "Луковит",
                },
                new Town()
                {
                    Id = 45,
                    Name = "Велинград",
                },
                new Town()
                {
                    Id = 46,
                    Name = "Новипазар",
                },
                new Town()
                {
                    Id = 47,
                    Name = "Първомайци",
                },
                new Town()
                {
                    Id = 48,
                    Name = "Ловеч",
                },
                new Town()
                {
                    Id = 49,
                    Name = "Севлиево",
                },
                new Town()
                {
                    Id = 50,
                    Name = "Своге",
                }
            };

            return towns;
        }
    }
}