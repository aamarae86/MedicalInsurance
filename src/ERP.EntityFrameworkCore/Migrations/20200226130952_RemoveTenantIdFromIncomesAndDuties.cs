using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class RemoveTenantIdFromIncomesAndDuties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "PortalUserIncomes");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "PortalUserDuties");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "PortalUserIncomes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "PortalUserDuties",
                nullable: false,
                defaultValue: 0);
        }
    }
}
