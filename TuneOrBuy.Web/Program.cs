using Microsoft.EntityFrameworkCore;
using TuneOrBuy.Data.Models;
using TuneOrBuy.Web.Data;
using Microsoft.AspNetCore.Identity;
using TuneOrBuy.Services.CarServiceOwners;
using TuneOrBuy.Services.Contracts;
using TuneOrBuy.Services.Sellers;
using CarService = TuneOrBuy.Services.Cars.CarService;

namespace TuneOrBuy.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder
                                  .Configuration
                                  .GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder
               .Services
               .AddDbContext<TuneOrBuyDbContext>(options =>
                {
                    options.UseSqlServer(connectionString, b => b.MigrationsAssembly("TuneOrBuy.Data"));
                });

            builder
               .Services
               .AddDatabaseDeveloperPageExceptionFilter();

            builder
               .Services
               .AddDefaultIdentity<Buyer>(options =>
                { 
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireDigit = false;
                })
               .AddEntityFrameworkStores<TuneOrBuyDbContext>();

            builder
               .Services
               .AddControllersWithViews();

            builder
               .Services
               .AddScoped<ISellerService, SellerService>();
            builder
               .Services
               .AddScoped<ICarService, CarService>();
            builder
               .Services
               .AddScoped<ICarServiceOwner, CarServiceOwnerService>();

            var app = builder.Build();


            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }


            app.UseHttpsRedirection()
               .UseStaticFiles()
               .UseRouting()
               .UseAuthentication()
               .UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();
                        app.UseAuthentication();;

            app.Run();
        }
    }
}




