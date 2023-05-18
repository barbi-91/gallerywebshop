using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GalleryWebShop.Migrations
{
    public partial class CreateAdminAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cd565eeb-2aa6-4d57-b195-61fc9aa24d7b", "17c81f6d-49b1-4909-8d40-7ddf8ebd899a", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "eb4dfb7e-763f-4109-8de3-fd3e59219d80", "83d276bb-bfb0-4401-901b-3aa58787f90c", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a7966536-0d4c-4a62-ae00-88a09ab5a000", 0, "Ulica grada Vukovara 22", "cfb1f5f6-be1d-4234-ae35-487a8ee5cb47", "ana@gmail.com", false, "Ana", "Programerić", false, null, "ANA@GMAIL.COM", "ANA@GMAIL.COM", "AQAAAAEAACcQAAAAEKgASBU4ye9nbLbxhmCgoDqF2Ds0YtpjrrXSevUMPFcu4QpChoyscW9ehJCX+uzB8A==", null, false, "aece8c6c-cd67-49d0-94b6-c74875b07fb8", false, "ana@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "cd565eeb-2aa6-4d57-b195-61fc9aa24d7b", "a7966536-0d4c-4a62-ae00-88a09ab5a000" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eb4dfb7e-763f-4109-8de3-fd3e59219d80");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "cd565eeb-2aa6-4d57-b195-61fc9aa24d7b", "a7966536-0d4c-4a62-ae00-88a09ab5a000" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cd565eeb-2aa6-4d57-b195-61fc9aa24d7b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a7966536-0d4c-4a62-ae00-88a09ab5a000");
        }
    }
}
