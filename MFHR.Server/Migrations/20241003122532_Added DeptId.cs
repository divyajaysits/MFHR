using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MF.HR.Migrations
{
    /// <inheritdoc />
    public partial class AddedDeptId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "MFHR_Employees",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "MFHR_Employees");
        }
    }
}
