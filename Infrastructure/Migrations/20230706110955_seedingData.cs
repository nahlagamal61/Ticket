using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seedingData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "ID", "City", "CreationDateTime", "Description", "District", "Governorate", "PhoneNumber", "TicketStatus" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 7, 5, 14, 9, 54, 824, DateTimeKind.Local).AddTicks(5220), "Lorem ipsum dolor sit amet", "Nasr City", 5, "1234567890", 1 },
                    { 2, 0, new DateTime(2023, 7, 4, 14, 9, 54, 824, DateTimeKind.Local).AddTicks(5275), "Consectetur adipiscing elit", "Roushdy", 0, "9876543210", 0 },
                    { 3, 2, new DateTime(2023, 7, 3, 14, 9, 54, 824, DateTimeKind.Local).AddTicks(5291), "Sed do eiusmod tempor incididunt", "Dokki", 10, "5555555555", 0 },
                    { 4, 3, new DateTime(2023, 7, 2, 14, 9, 54, 824, DateTimeKind.Local).AddTicks(5297), "Ut labore et dolore magna aliqua", "Luxor City", 13, "9999999999", 1 },
                    { 5, 5, new DateTime(2023, 7, 1, 14, 9, 54, 824, DateTimeKind.Local).AddTicks(5302), "Excepteur sint occaecat cupidatat non proident", "Asyut Center", 2, "1111111111", 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "ID",
                keyValue: 5);
        }
    }
}
