using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GalleryWebShop.Migrations
{
    public partial class CategoryandProductDataSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Image", "Title" },
                values: new object[,]
                {
                    { 1, "Acrylic paints are water-based and acrylic paint tends to be more vibrant in color due to its fast dry time.", "", "Acril" },
                    { 2, "A type of paint that dries slowly and consists of pigment particles suspended in oil for drying, mostly linseed oil.", "", "Oil" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Image", "InStock", "Price", "Sku", "Title" },
                values: new object[,]
                {
                    { 1, "Seascape using the acrylic  on canvas technique", "", 1m, 250.00m, "1dfd314716", "Seascape 001" },
                    { 2, "Bird portrait using the oil on canvas technique.", "", 1m, 320.00m, "4632ec6f16", "Bird 001" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
