using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sber.Migrations
{
    public partial class banks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Tickets");

            migrationBuilder.AddColumn<int>(
                name: "BankId",
                table: "Tickets",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Banks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    House = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Index = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banks", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_BankId",
                table: "Tickets",
                column: "BankId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Banks_BankId",
                table: "Tickets",
                column: "BankId",
                principalTable: "Banks",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Banks_BankId",
                table: "Tickets");

            migrationBuilder.DropTable(
                name: "Banks");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_BankId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "BankId",
                table: "Tickets");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Tickets",
                type: "NVARCHAR(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }
    }
}
