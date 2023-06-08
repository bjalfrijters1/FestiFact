using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Festifact.Api.Migrations
{
    /// <inheritdoc />
    public partial class testing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "FavouritePerformers",
                columns: new[] { "Id", "UserId", "PerformerId" },
                values: new object[] { 2, 2, 1 });

            migrationBuilder.UpdateData(
                table: "Shows",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDateTime", "StartDateTime" },
                values: new object[] { new DateTime(2023, 6, 8, 13, 45, 57, 424, DateTimeKind.Local).AddTicks(942), new DateTime(2023, 6, 8, 11, 45, 57, 424, DateTimeKind.Local).AddTicks(905) });

            migrationBuilder.UpdateData(
                table: "Shows",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDateTime", "StartDateTime" },
                values: new object[] { new DateTime(2023, 6, 8, 13, 45, 57, 424, DateTimeKind.Local).AddTicks(961), new DateTime(2023, 6, 8, 11, 45, 57, 424, DateTimeKind.Local).AddTicks(959) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateOfBirth",
                value: new DateTime(2003, 6, 8, 11, 45, 57, 424, DateTimeKind.Local).AddTicks(991));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FavouritePerformers");

            migrationBuilder.DropTable(
                name: "FavouriteShows");

            migrationBuilder.UpdateData(
                table: "Shows",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDateTime", "StartDateTime" },
                values: new object[] { new DateTime(2023, 6, 8, 13, 6, 44, 519, DateTimeKind.Local).AddTicks(403), new DateTime(2023, 6, 8, 11, 6, 44, 519, DateTimeKind.Local).AddTicks(363) });

            migrationBuilder.UpdateData(
                table: "Shows",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDateTime", "StartDateTime" },
                values: new object[] { new DateTime(2023, 6, 8, 13, 6, 44, 519, DateTimeKind.Local).AddTicks(419), new DateTime(2023, 6, 8, 11, 6, 44, 519, DateTimeKind.Local).AddTicks(417) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateOfBirth",
                value: new DateTime(2003, 6, 8, 11, 6, 44, 519, DateTimeKind.Local).AddTicks(450));
        }
    }
}
