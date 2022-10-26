using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataCon.Migrations
{
    public partial class Userseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "UserId", "CreatedDate", "Email", "Name", "Password" },
                values: new object[] { 1, new DateTime(2022, 10, 24, 10, 22, 33, 359, DateTimeKind.Local).AddTicks(2740), "rowan", "rowan", "123" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "UserId",
                keyValue: 1);
        }
    }
}
