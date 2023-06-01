using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Festifact.Api.Migrations
{
    /// <inheritdoc />
    public partial class Addednametoshow : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Shows",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Shows",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDateTime", "Name", "StartDateTime" },
                values: new object[] { new DateTime(2023, 6, 1, 14, 8, 0, 520, DateTimeKind.Local).AddTicks(2001), "Coolio", new DateTime(2023, 6, 1, 12, 8, 0, 520, DateTimeKind.Local).AddTicks(1960) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateOfBirth",
                value: new DateTime(2003, 6, 1, 12, 8, 0, 520, DateTimeKind.Local).AddTicks(2027));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Shows");

            migrationBuilder.UpdateData(
                table: "Shows",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDateTime", "StartDateTime" },
                values: new object[] { new DateTime(2023, 6, 1, 13, 12, 33, 658, DateTimeKind.Local).AddTicks(4474), new DateTime(2023, 6, 1, 11, 12, 33, 658, DateTimeKind.Local).AddTicks(4432) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateOfBirth",
                value: new DateTime(2003, 6, 1, 11, 12, 33, 658, DateTimeKind.Local).AddTicks(4499));
        }
    }
}
