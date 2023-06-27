using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GalleryWebShop.Migrations
{
    public partial class SeedDataIntoTabčesProductandUserandCategoryandProductsCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cd565eeb-2aa6-4d57-b195-61fc9aa24d7b",
                column: "ConcurrencyStamp",
                value: "1b0b3ddf-1801-4444-9cee-76486f233ccf");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eb4dfb7e-763f-4109-8de3-fd3e59219d80",
                column: "ConcurrencyStamp",
                value: "0d3ddfa6-c238-4bc1-8d7a-2cfbaead6cd7");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a7966536-0d4c-4a62-ae00-88a09ab5a000",
                columns: new[] { "ConcurrencyStamp", "Image", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dc7edb68-df21-40b6-ba24-57d85aca6a7d", "2023-06-26-10-59-11_ana.jpg", "AQAAAAEAACcQAAAAEBOFGaSUUpJnMPobD1++bvBd8Th9MgbM2IwOVmtGmZU1N6yxoWXW0rD4E72+xVqwrQ==", "615564f4-6535-4df5-a6a7-e16a44485a5d" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "Image", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "0723229f-5f2d-41d6-9623-dfa2f77b9c4a", 0, "Ulica Ivana Kozarca 28", "1b957287-914d-4488-97e3-e225e07c59e7", "miki@gmail.com", false, "Mićo", "2023-06-26-05-42-10_mico.jpg", "Dizajnerić", false, null, "MIKI@GMAIL.COM", "MIKI@GMAIL.COM", "AQAAAAEAACcQAAAAEPiAgo5wuJVrylDL7FtRJSyzYN+PeCptX39aNbR0o7ruQQ6Ilg7q3s4tXwVWWWfVrA==", null, false, "7c0fe625-5a44-4d37-abd2-6454ccd7ab66", false, "miki@gmail.com" });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "CategoryId", "ProductId" },
                values: new object[,]
                {
                    { 9, 2, 2 },
                    { 21, 1, 1 }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Image", "Title" },
                values: new object[] { "Seascape using the acrylic  on canvas technique.", "2023-06-24-12-11-35_sea.jpg", "Rippling sea" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Image", "Title" },
                values: new object[] { "2023-06-23-06-52-54_bird.jpg", "Bird song" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Image", "InStock", "Price", "Size", "Sku", "Title" },
                values: new object[,]
                {
                    { 3, "Nature scape using the acrylic on canvas technique.", "2023-06-23-06-53-16_unsplash.jpg", 2m, 260.00m, "20x30", "dfa45d4dfa", "Autumn over the river" },
                    { 4, "Abstract painting of face using Oil technice.", "2023-06-22-07-11-17_face.jpg", 5m, 670.00m, "50x70", "ela45d4d11", "Conqueror's view" },
                    { 5, "Abstract painting of world with using ink wash technic.", "2023-06-22-07-12-09_abstract3.jpg", 2m, 345.00m, "50x80", "5jfd314733", "Abstract World" },
                    { 6, "A drawing made with light and shadow, i.e. tones, then such a drawing is called a tonal or painterly drawing.", "2023-06-23-06-54-50_animals.jpg", 3m, 880.00m, "50x70", "kk545d4dfa", "Forest story" },
                    { 7, "A drawing made with light and shadow, i.e. tones, then such a drawing is called a tonal or painterly drawing.", "2023-06-22-07-13-13_cats.jpg", 1m, 550.00m, "60x80", "dfa4545zuh", "Playful cats" },
                    { 8, "Deep blue sea drawn with acrylic technique.", "2023-06-22-07-13-56_water.jpg", 1m, 290.00m, "50x70", "12sd8d4d22", "Deep sea" },
                    { 9, "Flowers in a vase painted with acrylic technique", "2023-06-22-07-14-38_flower.jpg", 1m, 385.00m, "90x70", "12h23d4d22", "Garden flowers" },
                    { 10, "Flowers in a vase in summer painted with acrylic technique.", "2023-06-23-06-55-27_flowers2.jpg", 1m, 450.00m, "50x80", "dfa45fff11", "Summer touch" },
                    { 11, "Abstract painting of life using oil technic.", "2023-06-22-07-15-42_abstract2jpg.jpg", 2m, 330.00m, "90x50", "gga45d4333", "Abstract Life" },
                    { 12, "Abstract painting of soul using ink wash technic.", "2023-06-22-07-16-08_abstract4.jpg", 1m, 320.00m, "90x70", "gzt5derfa", "Abstract  Soul" },
                    { 13, "Cat portret using watercolor technic.", "2023-06-22-07-16-47_cat.jpg", 1m, 290.00m, "90x50", "89hzud4882", "Cat" },
                    { 14, "Waterfall on river using watercolor technic.", "2023-06-23-07-46-00_waterfall.jpg", 1m, 140.00m, "40x50", "ed456d2w3e", "Waterfall" },
                    { 15, "The simple shape is not too uniform and symmetrical. Apple painted using watercolor technic.", "2023-06-23-07-46-22_apple.jpg", 2m, 220.00m, "50x70", "afadj33dfa", "Apple" },
                    { 16, "Fruits in silence was painted using the acrylic technique on canvas.", "2023-06-23-06-56-22_fruit.jpg", 1m, 550.00m, "50x80", "t37dj24ddd", "Fruit in silence" },
                    { 17, "The hungry fox in the manor's court was painted using the technique of drawing on canvas.", "2023-06-23-07-46-45_fox.jpg", 2m, 310.00m, "90x70", "987bgh5rd3", "Hungry fox" },
                    { 18, "The castle captured in the time of wealth was painted using the technique of water colors.", "2023-06-23-07-47-10_castel.jpg", 3m, 680.00m, "90x70", "g38ks9e567", "Castle in time" },
                    { 19, "Little girl in her mind on the grass using ink wash technic.", "2023-06-23-07-47-40_girl.jpg", 1m, 600.00m, "90x50", "kt85ffps55", "A girl with a heavy heart" },
                    { 20, "The painting called Heaven and Hell is an abstract art created by observing the sky during a storm, and it was painted using the oil on canvas technique.", "2023-06-23-06-57-21_tunder.jpg", 2m, 490.00m, "90x70", "j8z08jut54", "Heaven and hell" },
                    { 21, "City calm is a work of art created using the drawing technique on canvas.", "2023-06-23-07-48-02_town.jpg", 4m, 270.00m, "50x70", "dh46dje9ii", "City calm" },
                    { 22, "Mountains in winter is a work of art created using the acrylic technique on canvas, which depicts the idyll of winter in a mountainous area.", "2023-06-25-09-56-41_snow.jpg", 2m, 380.00m, "50x80", "ju876tr45d", "Mountains in winterm" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "eb4dfb7e-763f-4109-8de3-fd3e59219d80", "0723229f-5f2d-41d6-9623-dfa2f77b9c4a" });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "CategoryId", "ProductId" },
                values: new object[,]
                {
                    { 1, 2, 4 },
                    { 2, 3, 5 },
                    { 3, 4, 7 },
                    { 4, 1, 8 },
                    { 5, 1, 9 },
                    { 6, 2, 11 },
                    { 7, 3, 12 },
                    { 8, 5, 13 },
                    { 10, 1, 3 },
                    { 11, 4, 6 },
                    { 12, 1, 10 },
                    { 13, 1, 16 },
                    { 14, 2, 20 },
                    { 15, 5, 14 },
                    { 16, 5, 15 },
                    { 17, 4, 17 },
                    { 18, 5, 18 },
                    { 19, 3, 19 },
                    { 20, 4, 21 },
                    { 22, 1, 22 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "eb4dfb7e-763f-4109-8de3-fd3e59219d80", "0723229f-5f2d-41d6-9623-dfa2f77b9c4a" });

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0723229f-5f2d-41d6-9623-dfa2f77b9c4a");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cd565eeb-2aa6-4d57-b195-61fc9aa24d7b",
                column: "ConcurrencyStamp",
                value: "6b4afb71-e1f5-4135-9d32-8275ef444aeb");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eb4dfb7e-763f-4109-8de3-fd3e59219d80",
                column: "ConcurrencyStamp",
                value: "78ae0217-f51a-457a-84a2-a6715ed4ce8a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a7966536-0d4c-4a62-ae00-88a09ab5a000",
                columns: new[] { "ConcurrencyStamp", "Image", "PasswordHash", "SecurityStamp" },
                values: new object[] { "32f21297-6c9f-48e5-b090-4e1cc0e61f5c", "", "AQAAAAEAACcQAAAAECnk/n1TW3LVUUuF1dFFf8rFaTu2rVMbnyZYKJ5/avuu27yLD6V34FpGQdb9ACHqfA==", "6cd1e10f-d6bc-472a-84cf-412ea97304e2" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Image", "Title" },
                values: new object[] { "Seascape using the acrylic  on canvas technique", "", "Seascape 001" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Image", "Title" },
                values: new object[] { "", "Bird 001" });
        }
    }
}
