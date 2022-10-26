using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManageEmployeesVacations.Migrations
{
    public partial class SeedGender : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Gender",
                columns: new[] { "GenderId", "GenderType" },
                values: new object[] { 1, "Female" });

            migrationBuilder.InsertData(
                table: "Gender",
                columns: new[] { "GenderId", "GenderType" },
                values: new object[] { 2, "Male" });

            migrationBuilder.InsertData(
                table: "Gender",
                columns: new[] { "GenderId", "GenderType" },
                values: new object[] { 3, "Other" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Gender",
                keyColumn: "GenderId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Gender",
                keyColumn: "GenderId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Gender",
                keyColumn: "GenderId",
                keyValue: 3);
        }
    }
}
