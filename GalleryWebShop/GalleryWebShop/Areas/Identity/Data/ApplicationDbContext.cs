using GalleryWebShop.Areas.Identity.Data;
using GalleryWebShop.Areas.Identity.Models;
using GalleryWebShop.Common;
using GalleryWebShop.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Reflection.Emit;

namespace GalleryWebShop.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{

    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {

        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);

        // Data seeding for table Category
        Category acrylic = new Category() { Id = 1, Title = "Acril", Description = "Acrylic paints are water-based and acrylic paint tends to be more vibrant in color due to its fast dry time." };
        Category oil = new Category() { Id = 2, Title = "Oil", Description = "A type of paint that dries slowly and consists of pigment particles suspended in oil for drying, mostly linseed oil." };
        Category ink = new Category() { Id = 3, Title = "Ink wash technic", Description = "Ink wash painting uses tonality and shading achieved by varying the ink density, both by differential grinding of the ink stick in water and by varying the ink load and pressure within a single brushstroke." };
        Category drawing = new Category() { Id = 4, Title = "Drawing", Description = "Drawing is a form of visual art in which an artist uses instruments to mark paper or other two-dimensional surface. Drawing instruments include graphite pencils, pen and ink, various kinds of paints, inked brushes, colored pencils, crayons, charcoal, chalk, pastels, erasers, markers, styluses, and metals." };
        Category watercolor = new Category() { Id = 5, Title = "Watercolor", Description = "Wet On Dry. A beautiful beginner's technique that allows the semi-transparent nature of the watercolors to really shine. Watercolor paint will only travel where the paper is wet/damp. The dry paper areas around the dampness, will act as locked gates, preventing the paint from escaping." };

        builder.Entity<Category>().HasData(acrylic, oil);

        // Data seeding for table Product
        builder.Entity<Product>().HasData(TestData.GetProducts());

        //Seeding data for Table ProductCategory - assigning a category to a product
        builder.Entity<ProductCategory>().HasData(TestData.GetProductsCategory());

        // Seeding roles and role assignment to main administrator user

        //Set data for Table ASPNetRoles
        string adminRoleId = "cd565eeb-2aa6-4d57-b195-61fc9aa24d7b";
        string adminRoleTitle = "Admin";
        string customerRoleId = "eb4dfb7e-763f-4109-8de3-fd3e59219d80";
        string customerRoleTitle = "Customer";

        // Seeding data for Table ASPNetRoles
        builder.Entity<IdentityRole>().HasData(
            new IdentityRole() { Id = adminRoleId, Name = adminRoleTitle, NormalizedName = adminRoleTitle.ToUpper() },
            new IdentityRole() { Id = customerRoleId, Name = customerRoleTitle, NormalizedName = customerRoleTitle.ToUpper() }
            );

        // Set data for User-Admin: Table AspNetUsers
        string adminId = "a7966536-0d4c-4a62-ae00-88a09ab5a000";
        string admin = "ana@gmail.com"; // username and email value
        string adminFirstName = "Ana";
        string adminLastName = "Programerić";
        string adminPassword = "Secret22";  //password
        string adminAddress = "Ulica grada Vukovara 22";


        // Set data for User-Customer: Table AspNetUsers
        string customerId = "0723229f-5f2d-41d6-9623-dfa2f77b9c4a";
        string customer = "miki@gmail.com"; // username and email value
        string customerFirstName = "Mićo";
        string customerLastName = "Dizajnerić";
        string customerPassword = "Miki23@";  //password
        string customerAddress = "Ulica Ivana Kozarca 28";

        // Hash password convert to secret string
        var hasher = new PasswordHasher<ApplicationUser>();

        //Seeding data for User-Admin: Table AspNetUsers
        builder.Entity<ApplicationUser>().HasData(
            new ApplicationUser
            {
                Id = adminId,
                UserName = admin,
                NormalizedUserName = admin.ToUpper(),
                Email = admin,
                EmailConfirmed = false,
                NormalizedEmail = admin.ToUpper(),
                FirstName = adminFirstName,
                LastName = adminLastName,
                Address = adminAddress,
                PasswordHash = hasher.HashPassword(null, adminPassword),
                Image = "2023-06-26-10-59-11_ana.jpg"
            }
        );

        //Seeding data for User-Customer: Table AspNetUsers
        builder.Entity<ApplicationUser>().HasData(
            new ApplicationUser
            {
                Id = customerId,
                UserName = customer,
                NormalizedUserName = customer.ToUpper(),
                Email = customer,
                EmailConfirmed = false,
                NormalizedEmail = customer.ToUpper(),
                FirstName = customerFirstName,
                LastName = customerLastName,
                Address = customerAddress,
                PasswordHash = hasher.HashPassword(null, customerPassword),
                Image = "2023-06-26-05-42-10_mico.jpg"
            }
        );


        //Seeding data for Table AspNetUserRoles - assigning a role to a user
        builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>()
                {
                    UserId = adminId,
                    RoleId = adminRoleId
                }
            );

        //Seeding data for Table AspNetUserRoles - assigning a role to a customer
        builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>()
                {
                    UserId = customerId,
                    RoleId = customerRoleId
                }
            );

        builder.Entity<User>().ToTable(nameof(User), t => t.ExcludeFromMigrations());
        builder.Entity<EditUser>().ToTable(nameof(EditUser), t => t.ExcludeFromMigrations()).HasNoKey();
        base.OnModelCreating(builder);
    }
}
