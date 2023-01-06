using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sber.Migrations
{
    public partial class fixedTickets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "House",
                table: "Addresses");

            migrationBuilder.RenameColumn(
                name: "Street",
                table: "Addresses",
                newName: "Name");

            migrationBuilder.AddColumn<string>(
                name: "ExecutorId",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PlannedDate",
                table: "Tickets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "SolvedDate",
                table: "Tickets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExecutorId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "PlannedDate",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "SolvedDate",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Addresses",
                newName: "Street");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "House",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
