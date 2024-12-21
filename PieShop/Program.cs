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

            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<PieShopDbContext>(options =>
            {
                options.UseSqlServer(
                    builder.Configuration["ConnectionStrings:PieShopDbContextConnection"]);
            });

			var app = builder.Build();

            app.UseStaticFiles();

            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.MapDefaultControllerRoute();

            DbInitializer.Seed(app);

            app.Run();
        }
    }
}
