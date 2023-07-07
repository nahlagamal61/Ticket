using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class setdatevalidation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Tickets",
                type: "datetime2",
                nullable: false,
                computedColumnSql: "GETUTCDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Tickets",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComputedColumnSql: "GETUTCDATE()");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreationDateTime",
                value: new DateTime(2023, 7, 5, 14, 9, 54, 824, DateTimeKind.Local).AddTicks(5220));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreationDateTime",
                value: new DateTime(2023, 7, 4, 14, 9, 54, 824, DateTimeKind.Local).AddTicks(5275));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreationDateTime",
                value: new DateTime(2023, 7, 3, 14, 9, 54, 824, DateTimeKind.Local).AddTicks(5291));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreationDateTime",
                value: new DateTime(2023, 7, 2, 14, 9, 54, 824, DateTimeKind.Local).AddTicks(5297));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreationDateTime",
                value: new DateTime(2023, 7, 1, 14, 9, 54, 824, DateTimeKind.Local).AddTicks(5302));
        }
    }
}
