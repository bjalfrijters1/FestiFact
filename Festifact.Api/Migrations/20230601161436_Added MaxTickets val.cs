using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Festifact.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddedMaxTicketsval : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Festivals",
                keyColumn: "Id",
                keyValue: 1,
                column: "MaxTickets",
                value: 250);

            migrationBuilder.UpdateData(
                table: "Shows",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDateTime", "StartDateTime" },
                values: new object[] { new DateTime(2023, 6, 1, 20, 14, 36, 672, DateTimeKind.Local).AddTicks(6464), new DateTime(2023, 6, 1, 18, 14, 36, 672, DateTimeKind.Local).AddTicks(6414) });

            migrationBuilder.UpdateData(
                table: "Shows",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDateTime", "StartDateTime" },
                values: new object[] { new DateTime(2023, 6, 1, 20, 14, 36, 672, DateTimeKind.Local).AddTicks(6482), new DateTime(2023, 6, 1, 18, 14, 36, 672, DateTimeKind.Local).AddTicks(6480) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateOfBirth",
                value: new DateTime(2003, 6, 1, 18, 14, 36, 672, DateTimeKind.Local).AddTicks(6516));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Festivals",
                keyColumn: "Id",
                keyValue: 1,
                column: "MaxTickets",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Shows",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDateTime", "StartDateTime" },
                values: new object[] { new DateTime(2023, 6, 1, 14, 55, 13, 183, DateTimeKind.Local).AddTicks(4418), new DateTime(2023, 6, 1, 12, 55, 13, 183, DateTimeKind.Local).AddTicks(4369) });

            migrationBuilder.UpdateData(
                table: "Shows",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDateTime", "StartDateTime" },
                values: new object[] { new DateTime(2023, 6, 1, 14, 55, 13, 183, DateTimeKind.Local).AddTicks(4433), new DateTime(2023, 6, 1, 12, 55, 13, 183, DateTimeKind.Local).AddTicks(4431) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateOfBirth",
                value: new DateTime(2003, 6, 1, 12, 55, 13, 183, DateTimeKind.Local).AddTicks(4465));
        }
    }
}
