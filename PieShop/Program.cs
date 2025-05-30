using Microsoft.EntityFrameworkCore;
using PieShop.Models;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;

namespace PieShop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString
                 ("PieShopDbContextConnection") ?? throw new InvalidOperationException("Connection string 'PieShopDbContextConnection' not found.");

            builder.Services.AddControllersWithViews()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                });

            builder.Services.AddScoped<IPieRepository, PieRepository>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<IShoppingCart, ShoppingCart>(sp => ShoppingCart.GetCart(sp));
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();

            builder.Services.AddSession();
            builder.Services.AddHttpContextAccessor();

            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();
            builder.Services.AddDbContext<PieShopDbContext>(options =>
            {
                options.UseSqlServer(
                    builder.Configuration["ConnectionStrings:PieShopDbContextConnection"]);
            });

            builder.Services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<PieShopDbContext>();

			var app = builder.Build();


            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseSession();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapRazorPages();
            DbInitializer.Seed(app);

            app.Run();
        }
    }
}
