using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateonticket : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0d711509-56ce-4efc-a8fc-1b81964e3f83", "bef2eb31-62e3-4760-8fe4-95bfaa35bc5d" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0d711509-56ce-4efc-a8fc-1b81964e3f83");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bef2eb31-62e3-4760-8fe4-95bfaa35bc5d");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Tickets",
                type: "datetime2",
                nullable: false,
                computedColumnSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComputedColumnSql: "GETUTCDATE()");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3b2d9c8a-0588-41ac-856e-7ee176308c12", "e97bd6ab-2582-46d2-9c26-4e067154baeb", "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "c985b20d-b3f6-4a71-a669-20249ef3a078", 0, "056b15b0-074f-4e04-a3a6-2fa6420794d6", "admin@gmail.com", true, false, null, "admin@gmail.com", "Admin", "AQAAAAEAACcQAAAAECM8WgnGWjOnyNMBqDbNoM4TA5M4DBVRoh1mlcX1IfqotJ6WbSH4dzoLeyKaS7PpXw==", null, false, "f29935f8-5b4a-4063-b87c-45525fb755b6", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "3b2d9c8a-0588-41ac-856e-7ee176308c12", "c985b20d-b3f6-4a71-a669-20249ef3a078" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3b2d9c8a-0588-41ac-856e-7ee176308c12", "c985b20d-b3f6-4a71-a669-20249ef3a078" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3b2d9c8a-0588-41ac-856e-7ee176308c12");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c985b20d-b3f6-4a71-a669-20249ef3a078");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Tickets",
                type: "datetime2",
                nullable: false,
                computedColumnSql: "GETUTCDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComputedColumnSql: "GETDATE()");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0d711509-56ce-4efc-a8fc-1b81964e3f83", "992e3247-03dd-4d15-acf7-b5edbc628622", "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "bef2eb31-62e3-4760-8fe4-95bfaa35bc5d", 0, "f6414000-e67e-4644-9e67-9834e5f024ac", "admin@gmail.com", true, false, null, "admin@gmail.com", "Admin", "AQAAAAEAACcQAAAAEFbGT6nAJFj/TjyRvjMMYVf/yv3XYrmDkYrMTtwJW5c5u/wHZPpJoMC1S+yC3gaQeg==", null, false, "b2d2fc2c-a8bf-4f02-b81d-777b83a94fe0", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "0d711509-56ce-4efc-a8fc-1b81964e3f83", "bef2eb31-62e3-4760-8fe4-95bfaa35bc5d" });
        }
    }
}
