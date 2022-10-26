using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManageEmployeesVacations.Migrations
{
    public partial class MappingTableNamesToMySqlConventions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeVacation_Employee_EmployeeID",
                table: "EmployeeVacation");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeVacation_Vacation_VacationID",
                table: "EmployeeVacation");

            migrationBuilder.DropForeignKey(
                name: "FK_VacationRequest_Employee_EmployeeID",
                table: "VacationRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_VacationRequest_Vacation_VacationID",
                table: "VacationRequest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VacationRequest",
                table: "VacationRequest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeVacation",
                table: "EmployeeVacation");

            migrationBuilder.RenameTable(
                name: "VacationRequest",
                newName: "vacation_request");

            migrationBuilder.RenameTable(
                name: "EmployeeVacation",
                newName: "employee_vacation");

            migrationBuilder.RenameIndex(
                name: "IX_VacationRequest_VacationID",
                table: "vacation_request",
                newName: "IX_vacation_request_VacationID");

            migrationBuilder.RenameIndex(
                name: "IX_VacationRequest_EmployeeID",
                table: "vacation_request",
                newName: "IX_vacation_request_EmployeeID");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeVacation_VacationID",
                table: "employee_vacation",
                newName: "IX_employee_vacation_VacationID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_vacation_request",
                table: "vacation_request",
                column: "VacationRequestId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_employee_vacation",
                table: "employee_vacation",
                columns: new[] { "EmployeeID", "VacationID" });

            migrationBuilder.AddForeignKey(
                name: "FK_employee_vacation_Employee_EmployeeID",
                table: "employee_vacation",
                column: "EmployeeID",
                principalTable: "Employee",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_employee_vacation_Vacation_VacationID",
                table: "employee_vacation",
                column: "VacationID",
                principalTable: "Vacation",
                principalColumn: "VacationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_vacation_request_Employee_EmployeeID",
                table: "vacation_request",
                column: "EmployeeID",
                principalTable: "Employee",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_vacation_request_Vacation_VacationID",
                table: "vacation_request",
                column: "VacationID",
                principalTable: "Vacation",
                principalColumn: "VacationId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_employee_vacation_Employee_EmployeeID",
                table: "employee_vacation");

            migrationBuilder.DropForeignKey(
                name: "FK_employee_vacation_Vacation_VacationID",
                table: "employee_vacation");

            migrationBuilder.DropForeignKey(
                name: "FK_vacation_request_Employee_EmployeeID",
                table: "vacation_request");

            migrationBuilder.DropForeignKey(
                name: "FK_vacation_request_Vacation_VacationID",
                table: "vacation_request");

            migrationBuilder.DropPrimaryKey(
                name: "PK_vacation_request",
                table: "vacation_request");

            migrationBuilder.DropPrimaryKey(
                name: "PK_employee_vacation",
                table: "employee_vacation");

            migrationBuilder.RenameTable(
                name: "vacation_request",
                newName: "VacationRequest");

            migrationBuilder.RenameTable(
                name: "employee_vacation",
                newName: "EmployeeVacation");

            migrationBuilder.RenameIndex(
                name: "IX_vacation_request_VacationID",
                table: "VacationRequest",
                newName: "IX_VacationRequest_VacationID");

            migrationBuilder.RenameIndex(
                name: "IX_vacation_request_EmployeeID",
                table: "VacationRequest",
                newName: "IX_VacationRequest_EmployeeID");

            migrationBuilder.RenameIndex(
                name: "IX_employee_vacation_VacationID",
                table: "EmployeeVacation",
                newName: "IX_EmployeeVacation_VacationID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VacationRequest",
                table: "VacationRequest",
                column: "VacationRequestId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeVacation",
                table: "EmployeeVacation",
                columns: new[] { "EmployeeID", "VacationID" });

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeVacation_Employee_EmployeeID",
                table: "EmployeeVacation",
                column: "EmployeeID",
                principalTable: "Employee",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeVacation_Vacation_VacationID",
                table: "EmployeeVacation",
                column: "VacationID",
                principalTable: "Vacation",
                principalColumn: "VacationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VacationRequest_Employee_EmployeeID",
                table: "VacationRequest",
                column: "EmployeeID",
                principalTable: "Employee",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VacationRequest_Vacation_VacationID",
                table: "VacationRequest",
                column: "VacationID",
                principalTable: "Vacation",
                principalColumn: "VacationId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
