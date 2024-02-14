using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class addmusthavetenanttables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "GlPeriodsYears",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "GlPeriodsDetails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "GlJeHeaders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "GlCodeComDetails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "GlAccHeaders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "FndLookupValues",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "GlPeriodsYears");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "GlPeriodsDetails");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "GlJeHeaders");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "GlCodeComDetails");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "GlAccHeaders");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "FndLookupValues");
        }
    }
}
