using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Festifact.Api.Migrations
{
    /// <inheritdoc />
    public partial class SmallchangetoShow : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Shows",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDateTime", "FilmId", "StartDateTime" },
                values: new object[] { new DateTime(2023, 6, 1, 13, 12, 33, 658, DateTimeKind.Local).AddTicks(4474), null, new DateTime(2023, 6, 1, 11, 12, 33, 658, DateTimeKind.Local).AddTicks(4432) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateOfBirth",
                value: new DateTime(2003, 6, 1, 11, 12, 33, 658, DateTimeKind.Local).AddTicks(4499));

            migrationBuilder.UpdateData(
                table: "Shows",
                keyColumn: "Id",
                keyValue: 1,
                column: "FilmId",
                value: null
                );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Shows",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDateTime", "FilmId", "StartDateTime" },
                values: new object[] { new DateTime(2023, 6, 1, 13, 0, 40, 607, DateTimeKind.Local).AddTicks(8715), 1, new DateTime(2023, 6, 1, 11, 0, 40, 607, DateTimeKind.Local).AddTicks(8672) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateOfBirth",
                value: new DateTime(2003, 6, 1, 11, 0, 40, 607, DateTimeKind.Local).AddTicks(8745));

            migrationBuilder.UpdateData(
                table: "Shows",
                keyColumn: "Id",
                keyValue: 1,
                column: "FilmId",
                value: null
                );
        }
    }
}
