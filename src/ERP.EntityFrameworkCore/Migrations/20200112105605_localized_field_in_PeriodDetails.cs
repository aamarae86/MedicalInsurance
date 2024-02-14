using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class localized_field_in_PeriodDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PeriodName",
                table: "GlPeriodsDetails",
                newName: "PeriodNameEn");

            migrationBuilder.AddColumn<string>(
                name: "PeriodNameAr",
                table: "GlPeriodsDetails",
                maxLength: 200,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PeriodNameAr",
                table: "GlPeriodsDetails");

            migrationBuilder.RenameColumn(
                name: "PeriodNameEn",
                table: "GlPeriodsDetails",
                newName: "PeriodName");
        }
    }
}
