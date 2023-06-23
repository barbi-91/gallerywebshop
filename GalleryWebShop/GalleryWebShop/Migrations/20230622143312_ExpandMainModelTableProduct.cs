using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GalleryWebShop.Migrations
{
    public partial class ExpandMainModelTableProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "Products",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

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
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "Size",
                value: "30x45");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "Size",
                value: "30x30");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Size",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cd565eeb-2aa6-4d57-b195-61fc9aa24d7b",
                column: "ConcurrencyStamp",
                value: "fb4d7694-c637-4cc0-beb3-6405f7c01c9e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eb4dfb7e-763f-4109-8de3-fd3e59219d80",
                column: "ConcurrencyStamp",
                value: "06ee7cdc-9e72-461e-b926-aae21981ace6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a7966536-0d4c-4a62-ae00-88a09ab5a000",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9808f0f1-d5a4-4a35-b250-ba55321d4012", "AQAAAAEAACcQAAAAEG0OTVQJ4Spr0a2svTcWhyUkrnqhD2gwXXZ4XvhVoDKXPwKcP1Naq5vEJW9VXVJ9mA==", "9c4165e4-99c8-4a35-a867-6eb0e154fb2c" });
        }
    }
}
