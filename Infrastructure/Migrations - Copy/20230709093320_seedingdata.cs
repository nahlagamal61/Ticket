using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seedingdata : Migration
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

            migrationBuilder.AddColumn<DateTime>(
                name: "ManualCreationDateTime",
                table: "Tickets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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
                values: new object[] { "d65be664-947b-4af3-9858-eca62937db3a", "0d79de92-59c1-46ac-b604-6682fc5af709", "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "91768849-ae80-43a7-b648-93aa543dceb1", 0, "18f6115d-a829-4062-9f4e-47687ce1b255", "admin@gmail.com", true, false, null, "admin@gmail.com", "Admin", "AQAAAAEAACcQAAAAEKBgfZHMiiHJygEIoUz5ltzzf+nRaYACzUq9efc063bpy+9GoTOdfSkjRJUkw3jAsw==", null, false, "cf8ad9b2-29c5-4875-8614-143f69bee7b4", false, "Admin" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "ID",
                keyValue: 1,
                column: "ManualCreationDateTime",
                value: new DateTime(2023, 7, 9, 12, 33, 19, 794, DateTimeKind.Local).AddTicks(4081));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "ID",
                keyValue: 2,
                column: "ManualCreationDateTime",
                value: new DateTime(2023, 7, 9, 12, 33, 19, 794, DateTimeKind.Local).AddTicks(4091));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "ID",
                keyValue: 3,
                column: "ManualCreationDateTime",
                value: new DateTime(2023, 7, 9, 12, 33, 19, 794, DateTimeKind.Local).AddTicks(4095));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "ID",
                keyValue: 4,
                column: "ManualCreationDateTime",
                value: new DateTime(2023, 7, 9, 12, 33, 19, 794, DateTimeKind.Local).AddTicks(4099));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "ID",
                keyValue: 5,
                column: "ManualCreationDateTime",
                value: new DateTime(2023, 7, 9, 12, 33, 19, 794, DateTimeKind.Local).AddTicks(4103));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "d65be664-947b-4af3-9858-eca62937db3a", "91768849-ae80-43a7-b648-93aa543dceb1" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d65be664-947b-4af3-9858-eca62937db3a", "91768849-ae80-43a7-b648-93aa543dceb1" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d65be664-947b-4af3-9858-eca62937db3a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "91768849-ae80-43a7-b648-93aa543dceb1");

            migrationBuilder.DropColumn(
                name: "ManualCreationDateTime",
                table: "Tickets");

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
