using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManageEmployeesVacations.Migrations
{
    public partial class SeedVacations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Vacation",
                columns: new[] { "VacationId", "Balance", "VacationName" },
                values: new object[] { 1, 14.0, "Schedule" });

            migrationBuilder.InsertData(
                table: "Vacation",
                columns: new[] { "VacationId", "Balance", "VacationName" },
                values: new object[] { 2, 7.0, "Casual" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Vacation",
                keyColumn: "VacationId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Vacation",
                keyColumn: "VacationId",
                keyValue: 2);
        }
    }
}
