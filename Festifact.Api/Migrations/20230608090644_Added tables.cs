using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Festifact.Api.Migrations
{
    /// <inheritdoc />
    public partial class Addedtables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FavouriteShows",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ShowId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavouriteShows", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FavouriteShows_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavouriteShows_Shows_ShowId",
                        column: x => x.ShowId,
                        principalTable: "Shows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FavouritePerformers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    PerformerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavouritePerformances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FavouritePerformers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavouritePerformers_Performers_PerformerId",
                        column: x => x.PerformerId,
                        principalTable: "Performers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "FavouriteShows",
                columns: new[] { "Id", "UserId", "ShowId" },
                values: new object[] { 1, 2, 1 });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Shows",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDateTime", "StartDateTime" },
                values: new object[] { new DateTime(2023, 6, 8, 12, 57, 40, 38, DateTimeKind.Local).AddTicks(4973), new DateTime(2023, 6, 8, 10, 57, 40, 38, DateTimeKind.Local).AddTicks(4932) });

            migrationBuilder.UpdateData(
                table: "Shows",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDateTime", "StartDateTime" },
                values: new object[] { new DateTime(2023, 6, 8, 12, 57, 40, 38, DateTimeKind.Local).AddTicks(4993), new DateTime(2023, 6, 8, 10, 57, 40, 38, DateTimeKind.Local).AddTicks(4991) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateOfBirth",
                value: new DateTime(2003, 6, 8, 10, 57, 40, 38, DateTimeKind.Local).AddTicks(5026));
        }
    }
}
