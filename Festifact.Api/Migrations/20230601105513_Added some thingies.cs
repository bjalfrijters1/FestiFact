using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Festifact.Api.Migrations
{
    /// <inheritdoc />
    public partial class Addedsomethingies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "FestivalPerformances",
                columns: new[] { "Id", "FestivalId", "ShowId" },
                values: new object[] { 2, 1, 2 });

            migrationBuilder.UpdateData(
                table: "Shows",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDateTime", "StartDateTime" },
                values: new object[] { new DateTime(2023, 6, 1, 14, 55, 13, 183, DateTimeKind.Local).AddTicks(4418), new DateTime(2023, 6, 1, 12, 55, 13, 183, DateTimeKind.Local).AddTicks(4369) });

            migrationBuilder.InsertData(
                table: "Shows",
                columns: new[] { "Id", "Description", "EndDateTime", "FilmId", "ImageFilePath", "LocationId", "Name", "PerformerId", "StartDateTime" },
                values: new object[] { 2, "Film", new DateTime(2023, 6, 1, 14, 55, 13, 183, DateTimeKind.Local).AddTicks(4433), 1, null, 1, "Film", null, new DateTime(2023, 6, 1, 12, 55, 13, 183, DateTimeKind.Local).AddTicks(4431) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateOfBirth",
                value: new DateTime(2003, 6, 1, 12, 55, 13, 183, DateTimeKind.Local).AddTicks(4465));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FestivalPerformances",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Shows",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Shows",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDateTime", "StartDateTime" },
                values: new object[] { new DateTime(2023, 6, 1, 14, 8, 0, 520, DateTimeKind.Local).AddTicks(2001), new DateTime(2023, 6, 1, 12, 8, 0, 520, DateTimeKind.Local).AddTicks(1960) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateOfBirth",
                value: new DateTime(2003, 6, 1, 12, 8, 0, 520, DateTimeKind.Local).AddTicks(2027));
        }
    }
}
