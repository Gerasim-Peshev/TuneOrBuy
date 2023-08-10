using Microsoft.EntityFrameworkCore;
using TuneOrBuy.Data.Models;
using TuneOrBuy.Web.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TuneOrBuy.Services.CarServiceOwners;
using TuneOrBuy.Services.CarServices;
using TuneOrBuy.Services.Contracts;
using TuneOrBuy.Services.Parts;
using TuneOrBuy.Services.Sellers;
using CarService = TuneOrBuy.Services.Cars.CarService;
using static TuneOrBuy.Web.Areas.Admin.AdminConstants;

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
               .AddRoles<IdentityRole<Guid>>()
               .AddEntityFrameworkStores<TuneOrBuyDbContext>();

            builder
               .Services
               .AddControllersWithViews(options =>
                {
                    options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
                });

            builder
               .Services
               .AddScoped<ISellerService, SellerService>();
            builder
               .Services
               .AddScoped<ICarService, CarService>();
            builder
               .Services
               .AddScoped<ICarServiceOwnerService, CarServiceOwnerService>();
            builder
               .Services
               .AddScoped<IPartService, PartService>();
            builder
               .Services
               .AddScoped<ICarServiceService, CarServiceService>();

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
            app.MapControllerRoute(
                name: "Areas",
                pattern: "{area}/{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();
            app.UseAuthentication();

            //Creating admin
            using (var scope = app.Services.CreateScope())
            {
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<Buyer>>();
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

                Task.Run(async () =>
                {
                    if (await roleManager.RoleExistsAsync(AdministratorRoleName))
                    {
                        return;
                    }

                    var role = new IdentityRole<Guid>(AdministratorRoleName);

                    await roleManager.CreateAsync(role);

                    string adminEmail = "admin@tob.com";
                    string adminPassword = "admin123";

                    var buyer = new Buyer()
                    {
                        Email = adminEmail,
                        UserName = adminEmail,
                        FirstName = "Admin",
                        LastName = "Admin"
                    };

                    await userManager.CreateAsync(buyer, adminPassword);

                    await userManager.AddToRoleAsync(buyer, role.Name);
                })
                    .GetAwaiter()
                    .GetResult();
            }

            app.Run();
        }
    }
}