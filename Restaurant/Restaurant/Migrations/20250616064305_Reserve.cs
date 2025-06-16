using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant.Migrations
{
    /// <inheritdoc />
    public partial class Reserve : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReserveTables_Tables_TableId",
                table: "ReserveTables");

            migrationBuilder.DropIndex(
                name: "IX_ReserveTables_TableId",
                table: "ReserveTables");

            migrationBuilder.DropColumn(
                name: "ReservationEnd",
                table: "ReserveTables");

            migrationBuilder.RenameColumn(
                name: "TableId",
                table: "ReserveTables",
                newName: "GuestCount");

            migrationBuilder.RenameColumn(
                name: "ReservationStart",
                table: "ReserveTables",
                newName: "ReservationDate");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "ReserveTables",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "ReservationTime",
                table: "ReserveTables",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<string>(
                name: "SpecialRequests",
                table: "ReserveTables",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "MenuItems",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "ReserveTables");

            migrationBuilder.DropColumn(
                name: "ReservationTime",
                table: "ReserveTables");

            migrationBuilder.DropColumn(
                name: "SpecialRequests",
                table: "ReserveTables");

            migrationBuilder.RenameColumn(
                name: "ReservationDate",
                table: "ReserveTables",
                newName: "ReservationStart");

            migrationBuilder.RenameColumn(
                name: "GuestCount",
                table: "ReserveTables",
                newName: "TableId");

            migrationBuilder.AddColumn<DateTime>(
                name: "ReservationEnd",
                table: "ReserveTables",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "MenuItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReserveTables_TableId",
                table: "ReserveTables",
                column: "TableId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReserveTables_Tables_TableId",
                table: "ReserveTables",
                column: "TableId",
                principalTable: "Tables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
