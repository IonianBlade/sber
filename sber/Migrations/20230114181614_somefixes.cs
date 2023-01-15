using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sber.Migrations
{
    public partial class somefixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Addresses_AdressId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_AspNetUsers_EmployeeId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_AdressId",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "Tickets",
                newName: "employee_id");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_EmployeeId",
                table: "Tickets",
                newName: "IX_Tickets_employee_id");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Tickets",
                type: "NVARCHAR(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Tickets",
                type: "NVARCHAR(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "Tickets",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "performer_id",
                table: "Tickets",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_AddressId",
                table: "Tickets",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_performer_id",
                table: "Tickets",
                column: "performer_id");

            migrationBuilder.AddForeignKey(
                name: "FK_ticket_employee",
                table: "Tickets",
                column: "employee_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ticket_performer",
                table: "Tickets",
                column: "performer_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Addresses_AddressId",
                table: "Tickets",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ticket_employee",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_ticket_performer",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Addresses_AddressId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_AddressId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_performer_id",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "performer_id",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "employee_id",
                table: "Tickets",
                newName: "EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_employee_id",
                table: "Tickets",
                newName: "IX_Tickets_EmployeeId");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(200)",
                oldMaxLength: 200);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_AdressId",
                table: "Tickets",
                column: "AdressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Addresses_AdressId",
                table: "Tickets",
                column: "AdressId",
                principalTable: "Addresses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_AspNetUsers_EmployeeId",
                table: "Tickets",
                column: "EmployeeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
