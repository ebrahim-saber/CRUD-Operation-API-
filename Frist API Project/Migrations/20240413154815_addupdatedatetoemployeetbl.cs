using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Frist_API_Project.Migrations
{
    /// <inheritdoc />
    public partial class addupdatedatetoemployeetbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_employees_department_departmentId",
                table: "employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_employees",
                table: "employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_department",
                table: "department");

            migrationBuilder.RenameTable(
                name: "employees",
                newName: "Employees");

            migrationBuilder.RenameTable(
                name: "department",
                newName: "Department");

            migrationBuilder.RenameIndex(
                name: "IX_employees_departmentId",
                table: "Employees",
                newName: "IX_Employees_departmentId");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Employees",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Department",
                table: "Department",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Department_departmentId",
                table: "Employees",
                column: "departmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Department_departmentId",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Department",
                table: "Department");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Employees");

            migrationBuilder.RenameTable(
                name: "Employees",
                newName: "employees");

            migrationBuilder.RenameTable(
                name: "Department",
                newName: "department");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_departmentId",
                table: "employees",
                newName: "IX_employees_departmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_employees",
                table: "employees",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_department",
                table: "department",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_employees_department_departmentId",
                table: "employees",
                column: "departmentId",
                principalTable: "department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
