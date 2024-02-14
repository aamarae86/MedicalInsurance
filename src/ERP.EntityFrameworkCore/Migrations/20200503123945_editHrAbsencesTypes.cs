using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class editHrAbsencesTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AbsencesTypeNumber",
                table: "HrAbsencesTypes",
                newName: "VacationsTypeNumber");

            migrationBuilder.RenameColumn(
                name: "AbsencesTypeName",
                table: "HrAbsencesTypes",
                newName: "VacationsTypeName");

            migrationBuilder.RenameColumn(
                name: "AbsencesTypeDesc",
                table: "HrAbsencesTypes",
                newName: "VacationsTypeDesc");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VacationsTypeNumber",
                table: "HrAbsencesTypes",
                newName: "AbsencesTypeNumber");

            migrationBuilder.RenameColumn(
                name: "VacationsTypeName",
                table: "HrAbsencesTypes",
                newName: "AbsencesTypeName");

            migrationBuilder.RenameColumn(
                name: "VacationsTypeDesc",
                table: "HrAbsencesTypes",
                newName: "AbsencesTypeDesc");
        }
    }
}
