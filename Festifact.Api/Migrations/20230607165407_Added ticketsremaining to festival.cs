using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Festifact.Api.Migrations
{
    /// <inheritdoc />
    public partial class Addedticketsremainingtofestival : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TicketsRemaining",
                table: "Festivals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Festivals",
                keyColumn: "Id",
                keyValue: 1,
                column: "TicketsRemaining",
                value: 246);

            migrationBuilder.UpdateData(
                table: "Shows",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDateTime", "StartDateTime" },
                values: new object[] { new DateTime(2023, 6, 7, 20, 54, 7, 779, DateTimeKind.Local).AddTicks(8107), new DateTime(2023, 6, 7, 18, 54, 7, 779, DateTimeKind.Local).AddTicks(8067) });

            migrationBuilder.UpdateData(
                table: "Shows",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDateTime", "StartDateTime" },
                values: new object[] { new DateTime(2023, 6, 7, 20, 54, 7, 779, DateTimeKind.Local).AddTicks(8122), new DateTime(2023, 6, 7, 18, 54, 7, 779, DateTimeKind.Local).AddTicks(8120) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateOfBirth",
                value: new DateTime(2003, 6, 7, 18, 54, 7, 779, DateTimeKind.Local).AddTicks(8158));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TicketsRemaining",
                table: "Festivals");

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
    }
}
