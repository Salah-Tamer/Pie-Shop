using Microsoft.EntityFrameworkCore;
using PieShop.Models;

namespace PieShop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<IPieRepository, PieRepository>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<IShoppingCart, ShoppingCart>(sp => ShoppingCart.GetCart(sp));
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();

            builder.Services.AddSession();
            builder.Services.AddHttpContextAccessor();

            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<PieShopDbContext>(options =>
            {
                options.UseSqlServer(
                    builder.Configuration["ConnectionStrings:PieShopDbContextConnection"]);
            });

			var app = builder.Build();


            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseSession();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            DbInitializer.Seed(app);

            app.Run();
        }
    }
}
