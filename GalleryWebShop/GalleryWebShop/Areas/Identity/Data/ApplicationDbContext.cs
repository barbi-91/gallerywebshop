using GalleryWebShop.Areas.Identity.Data;
using GalleryWebShop.Areas.Identity.Models;
using GalleryWebShop.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
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
        Category acrylic = new Category() { Id = 1, Description = "Acrylic paints are water-based and acrylic paint tends to be more vibrant in color due to its fast dry time.", Title = "Acril", Image = "" };
        Category oil = new Category() { Id = 2, Description = "A type of paint that dries slowly and consists of pigment particles suspended in oil for drying, mostly linseed oil.", Title = "Oil", Image = "" };

        builder.Entity<Category>().HasData(acrylic, oil);

        // Data seeding for table Product
        Product sea = new Product()
        {
            Id = 1,
            Image = "",
            Description = "Seascape using the acrylic  on canvas technique",
            InStock = 1,
            Price = 250.00M,
            Title = "Seascape 001",
            Sku = "1dfd314716",
            Size = "30x45"
        };
        Product bird = new Product()
        {
            Id = 2,
            Image = "",
            Description = "Bird portrait using the oil on canvas technique.",
            InStock = 1,
            Price = 320.00M,
            Title = "Bird 001",
            Sku = "4632ec6f16",
            Size = "30x30"
        };
               
        builder.Entity<Product>().HasData(sea, bird);

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
                NormalizedEmail = admin.ToUpper(),
                FirstName = adminFirstName,
                LastName = adminLastName,
                Address = adminAddress,
                PasswordHash = hasher.HashPassword(null, adminPassword)
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
        builder.Entity<User>().ToTable(nameof(Areas.Identity.Models.User), t => t.ExcludeFromMigrations());
        builder.Entity<EditUser>().ToTable(nameof(EditUser), t => t.ExcludeFromMigrations()).HasNoKey();
        base.OnModelCreating(builder);
    }
}
