using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GalleryWebShop.Migrations
{
    public partial class ExpandUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                nullable: false
                );

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                nullable: false
                );

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                nullable: false
                );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers"
                );

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers"
                );

            migrationBuilder.DropColumn(
                name: "Address",
                table: "AspNetUsers"
                );
        }
    }
}