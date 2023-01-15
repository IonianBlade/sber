using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sber.Migrations
{
    public partial class deleteAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Addresses_AddressId",
                table: "Tickets");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_AddressId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "AdressId",
                table: "Tickets");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Tickets",
                type: "NVARCHAR(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Tickets");

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "Tickets",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AdressId",
                table: "Tickets",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_AddressId",
                table: "Tickets",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Addresses_AddressId",
                table: "Tickets",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id");
        }
    }
}
