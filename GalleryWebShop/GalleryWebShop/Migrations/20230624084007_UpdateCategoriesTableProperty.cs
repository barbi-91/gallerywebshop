using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GalleryWebShop.Migrations
{
    public partial class UpdateCategoriesTableProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Categories");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cd565eeb-2aa6-4d57-b195-61fc9aa24d7b",
                column: "ConcurrencyStamp",
                value: "19abcbe7-2eb3-4815-bca8-00c892858a53");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eb4dfb7e-763f-4109-8de3-fd3e59219d80",
                column: "ConcurrencyStamp",
                value: "243bbf4d-fd84-4997-ad30-e542e79cac13");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a7966536-0d4c-4a62-ae00-88a09ab5a000",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "34e9b98f-0454-4673-a7d5-eb077ab168eb", "AQAAAAEAACcQAAAAEFtiPk5xjCy99aPGJ3loZ5SMvQdTfJ7GC9fkGsGOm1qpc+2iRIz9j6166kDBQL4Zzw==", "6c9975da-c5a1-4921-a673-bbe2c2a37078" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Categories",
                type: "nvarchar(200)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cd565eeb-2aa6-4d57-b195-61fc9aa24d7b",
                column: "ConcurrencyStamp",
                value: "bff3aba9-7176-48c0-a860-d21c6bab6a7d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eb4dfb7e-763f-4109-8de3-fd3e59219d80",
                column: "ConcurrencyStamp",
                value: "9863ec43-62b8-4242-87af-d19e8e2c9fec");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a7966536-0d4c-4a62-ae00-88a09ab5a000",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a0767e5b-4f98-469d-bd06-5d23d7af58cd", "AQAAAAEAACcQAAAAEImmSwXAi4kak+DaDQCTus1LPhasyuOM82oyYXU8iciB6jwPULe0cNCAam8eK/QoCw==", "e849043d-8466-4844-8669-da8d3958daca" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Image",
                value: "");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Image",
                value: "");
        }
    }
}
