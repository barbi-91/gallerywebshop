using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GalleryWebShop.Migrations
{
    public partial class ExtandUserTablePropertyImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "AspNetUsers",
                type: "nvarchar(200)",
                nullable: true);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "AspNetUsers");

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
    }
}
