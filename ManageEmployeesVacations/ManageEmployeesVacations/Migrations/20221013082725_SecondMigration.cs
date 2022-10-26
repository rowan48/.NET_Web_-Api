using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManageEmployeesVacations.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "StartVacationDate",
                table: "VacationRequest",
                type: "Date",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndVacationDate",
                table: "VacationRequest",
                type: "Date",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "BirthDate",
                table: "Employee",
                type: "Date",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "StartVacationDate",
                table: "VacationRequest",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "Date")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "EndVacationDate",
                table: "VacationRequest",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "Date")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "BirthDate",
                table: "Employee",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "Date")
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
