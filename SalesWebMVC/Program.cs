using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using System.Globalization;
using SalesWebMvc.Data;
using SalesWebMvc.Services;
namespace SalesWebMvc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("SalesWebMvcContext") ?? throw new InvalidOperationException("Connection string 'SalesWebMvcContext' not found.");

            builder.Services.AddDbContext<SalesWebMvcContext>(options =>
            options.UseMySql(
            builder.Configuration.GetConnectionString("SalesWebMvcContext"),
            ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("SalesWebMvcContext"))));

            //Register SeedingService
            builder.Services.AddScoped<SeedingService>();
            //Register DepartmentService
            builder.Services.AddScoped<DepartmentService>();
            //Register SellerService
            builder.Services.AddScoped<SellerService>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var enUs = new CultureInfo("en-US");
            var localizationOptions = new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("en-US"),
                SupportedCultures = new List<CultureInfo> { enUs },
                SupportedUICultures = new List<CultureInfo> { enUs }
            };

            var app = builder.Build();

            app.UseRequestLocalization(localizationOptions);

            // Seed database
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var seedingService = services.GetRequiredService<SeedingService>();
                seedingService.Seed();
            }


            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
