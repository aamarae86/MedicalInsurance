using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class tenantIdForOwnerTaxDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "PmOwnersTaxDetails",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "PmOwnersTaxDetails");
        }
    }
}
