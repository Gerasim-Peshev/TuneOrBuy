﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TuneOrBuy.Web.Data;

#nullable disable

namespace TuneOrBuy.Data.Migrations
{
    [DbContext(typeof(TuneOrBuyDbContext))]
    partial class TuneOrBuyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("TuneOrBuy.Data.Models.Buyer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("TuneOrBuy.Data.Models.Car", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BodyType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("BuyerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Equipments")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FirstRegistrationYear")
                        .HasColumnType("datetime2");

                    b.Property<string>("Fuel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GearType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HorsePower")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(2048)
                        .HasColumnType("nvarchar(2048)");

                    b.Property<string>("Manufacturer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumberOfDoors")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumberOfSeats")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("SellerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("ServiceHistory")
                        .HasColumnType("bit");

                    b.Property<int>("TraveledDistance")
                        .HasColumnType("int");

                    b.Property<string>("VIN")
                        .HasMaxLength(17)
                        .HasColumnType("nvarchar(17)");

                    b.Property<DateTime>("Year")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BuyerId");

                    b.HasIndex("SellerId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("TuneOrBuy.Data.Models.CarService", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<Guid?>("BuyerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CarServiceOwnerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CloseHour")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(2048)
                        .HasColumnType("nvarchar(2048)");

                    b.Property<DateTime>("OpenHour")
                        .HasColumnType("datetime2");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Services")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TownId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BuyerId");

                    b.HasIndex("CarServiceOwnerId");

                    b.HasIndex("TownId");

                    b.ToTable("CarServices");
                });

            modelBuilder.Entity("TuneOrBuy.Data.Models.CarServiceOwner", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BuyerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Id");

                    b.HasIndex("BuyerId");

                    b.ToTable("CarServiceOwners");
                });

            modelBuilder.Entity("TuneOrBuy.Data.Models.Part", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("BuyerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(2048)
                        .HasColumnType("nvarchar(2048)");

                    b.Property<string>("Manufacturer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Price")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("SellerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Year")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BuyerId");

                    b.HasIndex("SellerId");

                    b.ToTable("Parts");
                });

            modelBuilder.Entity("TuneOrBuy.Data.Models.Seller", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BuyerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(2048)
                        .HasColumnType("nvarchar(2048)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<int>("TownId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BuyerId");

                    b.HasIndex("TownId");

                    b.ToTable("Sellers");
                });

            modelBuilder.Entity("TuneOrBuy.Data.Models.Town", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(176)
                        .HasColumnType("nvarchar(176)");

                    b.HasKey("Id");

                    b.ToTable("Towns");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "София"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Варна"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Пловдив"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Враца"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Бургас"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Дупница"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Стара Загора"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Монтана"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Плевен"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Хасково"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Русе"
                        },
                        new
                        {
                            Id = 12,
                            Name = "Шумен"
                        },
                        new
                        {
                            Id = 13,
                            Name = "Сливен"
                        },
                        new
                        {
                            Id = 14,
                            Name = "Добрич"
                        },
                        new
                        {
                            Id = 15,
                            Name = "Велико Търново"
                        },
                        new
                        {
                            Id = 16,
                            Name = "Перник"
                        },
                        new
                        {
                            Id = 17,
                            Name = "Благоевград"
                        },
                        new
                        {
                            Id = 18,
                            Name = "Пазарджик"
                        },
                        new
                        {
                            Id = 19,
                            Name = "Габрово"
                        },
                        new
                        {
                            Id = 20,
                            Name = "Казанлък"
                        },
                        new
                        {
                            Id = 21,
                            Name = "Силистра"
                        },
                        new
                        {
                            Id = 22,
                            Name = "Кюстендил"
                        },
                        new
                        {
                            Id = 23,
                            Name = "Разград"
                        },
                        new
                        {
                            Id = 24,
                            Name = "Кърджали"
                        },
                        new
                        {
                            Id = 25,
                            Name = "Търговище"
                        },
                        new
                        {
                            Id = 26,
                            Name = "Димитровград"
                        },
                        new
                        {
                            Id = 27,
                            Name = "Троян"
                        },
                        new
                        {
                            Id = 28,
                            Name = "Петрич"
                        },
                        new
                        {
                            Id = 29,
                            Name = "Видин"
                        },
                        new
                        {
                            Id = 30,
                            Name = "Лясковец"
                        },
                        new
                        {
                            Id = 31,
                            Name = "Гоце Делчев"
                        },
                        new
                        {
                            Id = 32,
                            Name = "Ямбол"
                        },
                        new
                        {
                            Id = 33,
                            Name = "Асеновград"
                        },
                        new
                        {
                            Id = 34,
                            Name = "Горна Оряховица"
                        },
                        new
                        {
                            Id = 35,
                            Name = "Провадия"
                        },
                        new
                        {
                            Id = 36,
                            Name = "Елин Пелин"
                        },
                        new
                        {
                            Id = 37,
                            Name = "Червенбряг"
                        },
                        new
                        {
                            Id = 38,
                            Name = "Панагюрище"
                        },
                        new
                        {
                            Id = 39,
                            Name = "Карлово"
                        },
                        new
                        {
                            Id = 40,
                            Name = "Драгичево"
                        },
                        new
                        {
                            Id = 41,
                            Name = "Карнобат"
                        },
                        new
                        {
                            Id = 42,
                            Name = "Смолян"
                        },
                        new
                        {
                            Id = 43,
                            Name = "Свищов"
                        },
                        new
                        {
                            Id = 44,
                            Name = "Луковит"
                        },
                        new
                        {
                            Id = 45,
                            Name = "Велинград"
                        },
                        new
                        {
                            Id = 46,
                            Name = "Новипазар"
                        },
                        new
                        {
                            Id = 47,
                            Name = "Първомайци"
                        },
                        new
                        {
                            Id = 48,
                            Name = "Ловеч"
                        },
                        new
                        {
                            Id = 49,
                            Name = "Севлиево"
                        },
                        new
                        {
                            Id = 50,
                            Name = "Своге"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("TuneOrBuy.Data.Models.Buyer", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("TuneOrBuy.Data.Models.Buyer", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TuneOrBuy.Data.Models.Buyer", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("TuneOrBuy.Data.Models.Buyer", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TuneOrBuy.Data.Models.Car", b =>
                {
                    b.HasOne("TuneOrBuy.Data.Models.Buyer", null)
                        .WithMany("FavouriteCars")
                        .HasForeignKey("BuyerId");

                    b.HasOne("TuneOrBuy.Data.Models.Seller", "Seller")
                        .WithMany("CarsForSell")
                        .HasForeignKey("SellerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Seller");
                });

            modelBuilder.Entity("TuneOrBuy.Data.Models.CarService", b =>
                {
                    b.HasOne("TuneOrBuy.Data.Models.Buyer", null)
                        .WithMany("FavouriteCarServices")
                        .HasForeignKey("BuyerId");

                    b.HasOne("TuneOrBuy.Data.Models.CarServiceOwner", "CarServiceOwner")
                        .WithMany("CarServices")
                        .HasForeignKey("CarServiceOwnerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TuneOrBuy.Data.Models.Town", "Town")
                        .WithMany()
                        .HasForeignKey("TownId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CarServiceOwner");

                    b.Navigation("Town");
                });

            modelBuilder.Entity("TuneOrBuy.Data.Models.CarServiceOwner", b =>
                {
                    b.HasOne("TuneOrBuy.Data.Models.Buyer", "Buyer")
                        .WithMany()
                        .HasForeignKey("BuyerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Buyer");
                });

            modelBuilder.Entity("TuneOrBuy.Data.Models.Part", b =>
                {
                    b.HasOne("TuneOrBuy.Data.Models.Buyer", null)
                        .WithMany("FavouriteParts")
                        .HasForeignKey("BuyerId");

                    b.HasOne("TuneOrBuy.Data.Models.Seller", "Seller")
                        .WithMany("PartsForSell")
                        .HasForeignKey("SellerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Seller");
                });

            modelBuilder.Entity("TuneOrBuy.Data.Models.Seller", b =>
                {
                    b.HasOne("TuneOrBuy.Data.Models.Buyer", "Buyer")
                        .WithMany()
                        .HasForeignKey("BuyerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TuneOrBuy.Data.Models.Town", "Town")
                        .WithMany()
                        .HasForeignKey("TownId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Buyer");

                    b.Navigation("Town");
                });

            modelBuilder.Entity("TuneOrBuy.Data.Models.Buyer", b =>
                {
                    b.Navigation("FavouriteCarServices");

                    b.Navigation("FavouriteCars");

                    b.Navigation("FavouriteParts");
                });

            modelBuilder.Entity("TuneOrBuy.Data.Models.CarServiceOwner", b =>
                {
                    b.Navigation("CarServices");
                });

            modelBuilder.Entity("TuneOrBuy.Data.Models.Seller", b =>
                {
                    b.Navigation("CarsForSell");

                    b.Navigation("PartsForSell");
                });
#pragma warning restore 612, 618
        }
    }
}
