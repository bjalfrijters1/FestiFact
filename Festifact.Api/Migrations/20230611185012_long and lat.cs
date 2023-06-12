using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Festifact.Api.Migrations
{
    /// <inheritdoc />
    public partial class longandlat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImageUri");

            migrationBuilder.DropColumn(
                name: "gps",
                table: "Locations");

            migrationBuilder.AddColumn<double>(
                name: "latitude",
                table: "Festivals",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "longitude",
                table: "Festivals",
                type: "float",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Festivals",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "latitude", "longitude" },
                values: new object[] { null, null });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "latitude",
                table: "Festivals");

            migrationBuilder.DropColumn(
                name: "longitude",
                table: "Festivals");

            migrationBuilder.AddColumn<string>(
                name: "gps",
                table: "Locations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ImageUri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FestivalId = table.Column<int>(type: "int", nullable: true),
                    Uri = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageUri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageUri_Festivals_FestivalId",
                        column: x => x.FestivalId,
                        principalTable: "Festivals",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 1,
                column: "gps",
                value: null);

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

            migrationBuilder.CreateIndex(
                name: "IX_ImageUri_FestivalId",
                table: "ImageUri",
                column: "FestivalId");
        }
    }
}
