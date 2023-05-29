using GalleryWebShop.Areas.Identity.Data;
using GalleryWebShop.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace GalleryWebShop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = "";
            if (!builder.Environment.IsEnvironment("Production"))
            {
                connectionString = builder.Configuration.GetConnectionString("Default");
            }
            else
            {
                connectionString = Environment.GetEnvironmentVariable("WEB_MODUL9_CONN_STRING");
            }

            //Service for creating context class object resources
            builder.Services.AddDbContext<ApplicationDbContext>(
                options => options
                .UseSqlServer(connectionString));

            //Service that the ApplicationUser class is the main one for user identification
            builder.Services.AddDefaultIdentity<ApplicationUser>(
                options => options.SignIn.RequireConfirmedAccount = false)
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Creating a service to use RazorPageoptions
            builder.Services.AddRazorPages(); //without it the @page in login.cshtml.cs doesn't work 

           

            //Kreiraj servis za sesiju
            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddSession();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();


            //application settings for handling decimal value
            var ci = new CultureInfo("de-De");
            ci.NumberFormat.NumberDecimalSeparator = ".";
            ci.NumberFormat.CurrencyDecimalSeparator = ".";

            app.UseRequestLocalization(
                    new RequestLocalizationOptions
                    {
                        DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture(ci),
                        SupportedCultures = new List<CultureInfo> { ci },
                        SupportedUICultures = new List<CultureInfo> { ci },
                    }
                );

            app.UseRouting();
            app.UseAuthentication();

            app.UseAuthorization();

            // Set admin roll for area acces
            app.MapAreaControllerRoute(
            name: "Admin",
            areaName: "Admin",
            pattern: "admin/{Controller}/{action}/{id?}"
            );

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            // Mapping razor pages
            app.MapRazorPages();

            app.Run();
        }
    }
}