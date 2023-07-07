using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedingAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "43d0f46a-8822-45c7-9d8b-241689e0f039", "acbc9673-d87c-45dc-b7ca-412be43f22cf", "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1cc6bbf5-9fb2-4c1e-a30a-1e887b6344e9", 0, "ac622625-27b6-4722-89e2-6e9297a97b14", "admin@gmail.com", true, false, null, "admin@gmail.com", "Admin", "AQAAAAEAACcQAAAAEKBRAGObT21KWI1iN2Bj5oR25FpwFH/i8BNsKsTmg4xpBsF5Igp+4QBKygdz5juAMw==", null, false, "3d0afe69-8a42-4c3e-b56c-635258e1313f", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "43d0f46a-8822-45c7-9d8b-241689e0f039", "1cc6bbf5-9fb2-4c1e-a30a-1e887b6344e9" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "43d0f46a-8822-45c7-9d8b-241689e0f039", "1cc6bbf5-9fb2-4c1e-a30a-1e887b6344e9" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "43d0f46a-8822-45c7-9d8b-241689e0f039");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1cc6bbf5-9fb2-4c1e-a30a-1e887b6344e9");
        }
    }
}
