using GalleryWebShop.Models;
using Humanizer;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Buffers.Text;
using System.Diagnostics.Metrics;
using System.Drawing;

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
                { 2, "A type of paint that dries slowly and consists of pigment particles suspended in oil for drying, mostly linseed oil.", "", "Oil" },
                { 3, "Ink wash painting uses tonality and shading achieved by varying the ink density, both by differential grinding of the ink stick in water and by varying the ink load and pressure within a single brushstroke.", "", "Ink wash technic" },
                { 4, "Drawing is a form of visual art in which an artist uses instruments to mark paper or other two-dimensional surface. Drawing instruments include graphite pencils, pen and ink, various kinds of paints, inked brushes, colored pencils, crayons, charcoal, chalk, pastels, erasers, markers, styluses, and metals.", "", "Drawing" },
                { 5, "Wet On Dry. A beautiful beginner's technique that allows the semi-transparent nature of the watercolors to really shine. Watercolor paint will only travel where the paper is wet/damp. The dry paper areas around the dampness, will act as locked gates, preventing the paint from escaping.", "", "Watercolor" },
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
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

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