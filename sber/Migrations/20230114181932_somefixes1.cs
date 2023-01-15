using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sber.Migrations
{
    public partial class somefixes1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "performer_id",
                table: "Tickets",
                newName: "PerformerId");

            migrationBuilder.RenameColumn(
                name: "employee_id",
                table: "Tickets",
                newName: "EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_performer_id",
                table: "Tickets",
                newName: "IX_Tickets_PerformerId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_employee_id",
                table: "Tickets",
                newName: "IX_Tickets_EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PerformerId",
                table: "Tickets",
                newName: "performer_id");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "Tickets",
                newName: "employee_id");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_PerformerId",
                table: "Tickets",
                newName: "IX_Tickets_performer_id");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_EmployeeId",
                table: "Tickets",
                newName: "IX_Tickets_employee_id");
        }
    }
}
