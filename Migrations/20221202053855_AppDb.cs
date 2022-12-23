using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyEmployeeApplication.Migrations
{
    public partial class AppDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    DepartmentName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeAge = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Department_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_Department_Id",
                        column: x => x.Department_Id,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentId", "DepartmentName" },
                values: new object[] { 1, "HR" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentId", "DepartmentName" },
                values: new object[] { 2, "Sales" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentId", "DepartmentName" },
                values: new object[] { 3, "Production" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "DateOfBirth", "Department_Id", "Email", "EmployeeAge", "FirstName", "Gender", "LastName" },
                values: new object[,]
                {
                    { 101, new DateTime(1995, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "NickJones@gmail.com", 27, "Nick", 0, "Jones" },
                    { 104, new DateTime(1994, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "RoselineEsther@gmail.com", 28, "Roseline ", 1, "Esther" },
                    { 102, new DateTime(1986, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "DanielThompson@gmail.com", 36, "Daniel", 0, "Thomphson" },
                    { 103, new DateTime(1991, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "SusanBradford@gmail.com", 31, "Susan", 1, "Bradford" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Department_Id",
                table: "Employees",
                column: "Department_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
