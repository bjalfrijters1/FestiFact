using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Festifact.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddedMaxTicketstoFestival : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FestivalPerformances_Festivals_FestivalId",
                table: "FestivalPerformances");

            migrationBuilder.DropForeignKey(
                name: "FK_FestivalPerformances_Shows_ShowId",
                table: "FestivalPerformances");

            migrationBuilder.DropForeignKey(
                name: "FK_Festivals_Organisers_OrganiserId",
                table: "Festivals");

            migrationBuilder.DropForeignKey(
                name: "FK_Shows_Films_FilmId",
                table: "Shows");

            migrationBuilder.DropForeignKey(
                name: "FK_Shows_Locations_LocationId",
                table: "Shows");

            migrationBuilder.DropForeignKey(
                name: "FK_Shows_Performers_PerformerId",
                table: "Shows");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Festivals_FestivalId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_FestivalId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Shows_FilmId",
                table: "Shows");

            migrationBuilder.DropIndex(
                name: "IX_Shows_LocationId",
                table: "Shows");

            migrationBuilder.DropIndex(
                name: "IX_Shows_PerformerId",
                table: "Shows");

            migrationBuilder.DropIndex(
                name: "IX_Festivals_OrganiserId",
                table: "Festivals");

            migrationBuilder.DropIndex(
                name: "IX_FestivalPerformances_FestivalId",
                table: "FestivalPerformances");

            migrationBuilder.DropIndex(
                name: "IX_FestivalPerformances_ShowId",
                table: "FestivalPerformances");

            migrationBuilder.RenameColumn(
                name: "startDate",
                table: "Festivals",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "endDate",
                table: "Festivals",
                newName: "EndDate");

            migrationBuilder.AlterColumn<int>(
                name: "PerformerId",
                table: "Shows",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "FilmId",
                table: "Shows",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "MaxTickets",
                table: "Festivals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Festivals",
                keyColumn: "Id",
                keyValue: 1,
                column: "MaxTickets",
                value: 0);

            /*migrationBuilder.InsertData(
                table: "Films",
                columns: new[] { "Id", "Actors", "CountryOfOrigin", "Description", "Director", "Name", "Year" },
                values: new object[] { 1, "Fairies", "LaLaLand", "Empty", "Not available", "Placeholder", 0 });*/

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "MaxTickets",
                table: "Festivals");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Festivals",
                newName: "startDate");

            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "Festivals",
                newName: "endDate");

            migrationBuilder.AlterColumn<int>(
                name: "PerformerId",
                table: "Shows",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FilmId",
                table: "Shows",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Shows",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDateTime", "FilmId", "StartDateTime" },
                values: new object[] { new DateTime(2023, 5, 11, 13, 18, 18, 777, DateTimeKind.Local).AddTicks(2055), 0, new DateTime(2023, 5, 11, 11, 18, 18, 777, DateTimeKind.Local).AddTicks(2016) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateOfBirth",
                value: new DateTime(2003, 5, 11, 11, 18, 18, 777, DateTimeKind.Local).AddTicks(2085));

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_FestivalId",
                table: "Tickets",
                column: "FestivalId");

            migrationBuilder.CreateIndex(
                name: "IX_Shows_FilmId",
                table: "Shows",
                column: "FilmId");

            migrationBuilder.CreateIndex(
                name: "IX_Shows_LocationId",
                table: "Shows",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Shows_PerformerId",
                table: "Shows",
                column: "PerformerId");

            migrationBuilder.CreateIndex(
                name: "IX_Festivals_OrganiserId",
                table: "Festivals",
                column: "OrganiserId");

            migrationBuilder.CreateIndex(
                name: "IX_FestivalPerformances_FestivalId",
                table: "FestivalPerformances",
                column: "FestivalId");

            migrationBuilder.CreateIndex(
                name: "IX_FestivalPerformances_ShowId",
                table: "FestivalPerformances",
                column: "ShowId");

            migrationBuilder.AddForeignKey(
                name: "FK_FestivalPerformances_Festivals_FestivalId",
                table: "FestivalPerformances",
                column: "FestivalId",
                principalTable: "Festivals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FestivalPerformances_Shows_ShowId",
                table: "FestivalPerformances",
                column: "ShowId",
                principalTable: "Shows",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Festivals_Organisers_OrganiserId",
                table: "Festivals",
                column: "OrganiserId",
                principalTable: "Organisers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Shows_Films_FilmId",
                table: "Shows",
                column: "FilmId",
                principalTable: "Films",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Shows_Locations_LocationId",
                table: "Shows",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Shows_Performers_PerformerId",
                table: "Shows",
                column: "PerformerId",
                principalTable: "Performers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Festivals_FestivalId",
                table: "Tickets",
                column: "FestivalId",
                principalTable: "Festivals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
