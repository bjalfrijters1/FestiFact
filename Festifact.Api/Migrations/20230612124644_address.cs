using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Festifact.Api.Migrations
{
    /// <inheritdoc />
    public partial class address : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "longitude",
                table: "Festivals",
                newName: "Longitude");

            migrationBuilder.RenameColumn(
                name: "latitude",
                table: "Festivals",
                newName: "Latitude");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Festivals",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Festivals",
                keyColumn: "Id",
                keyValue: 1,
                column: "Address",
                value: null);

            migrationBuilder.UpdateData(
                table: "Shows",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDateTime", "StartDateTime" },
                values: new object[] { new DateTime(2023, 6, 12, 16, 46, 44, 767, DateTimeKind.Local).AddTicks(5004), new DateTime(2023, 6, 12, 14, 46, 44, 767, DateTimeKind.Local).AddTicks(4959) });

            migrationBuilder.UpdateData(
                table: "Shows",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDateTime", "StartDateTime" },
                values: new object[] { new DateTime(2023, 6, 12, 16, 46, 44, 767, DateTimeKind.Local).AddTicks(5020), new DateTime(2023, 6, 12, 14, 46, 44, 767, DateTimeKind.Local).AddTicks(5018) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateOfBirth",
                value: new DateTime(2003, 6, 12, 14, 46, 44, 767, DateTimeKind.Local).AddTicks(5051));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Festivals");

            migrationBuilder.RenameColumn(
                name: "Longitude",
                table: "Festivals",
                newName: "longitude");

            migrationBuilder.RenameColumn(
                name: "Latitude",
                table: "Festivals",
                newName: "latitude");

            migrationBuilder.UpdateData(
                table: "Shows",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDateTime", "StartDateTime" },
                values: new object[] { new DateTime(2023, 6, 11, 22, 50, 11, 986, DateTimeKind.Local).AddTicks(9261), new DateTime(2023, 6, 11, 20, 50, 11, 986, DateTimeKind.Local).AddTicks(9218) });

            migrationBuilder.UpdateData(
                table: "Shows",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDateTime", "StartDateTime" },
                values: new object[] { new DateTime(2023, 6, 11, 22, 50, 11, 986, DateTimeKind.Local).AddTicks(9280), new DateTime(2023, 6, 11, 20, 50, 11, 986, DateTimeKind.Local).AddTicks(9278) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateOfBirth",
                value: new DateTime(2003, 6, 11, 20, 50, 11, 986, DateTimeKind.Local).AddTicks(9312));
        }
    }
}
