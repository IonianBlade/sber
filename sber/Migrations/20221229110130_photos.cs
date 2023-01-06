using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sber.Migrations
{
    public partial class photos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Addresses_AdressId",
                table: "Tickets");

            migrationBuilder.AlterColumn<int>(
                name: "AdressId",
                table: "Tickets",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Addresses_AdressId",
                table: "Tickets",
                column: "AdressId",
                principalTable: "Addresses",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Addresses_AdressId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Tickets");

            migrationBuilder.AlterColumn<int>(
                name: "AdressId",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Addresses_AdressId",
                table: "Tickets",
                column: "AdressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
