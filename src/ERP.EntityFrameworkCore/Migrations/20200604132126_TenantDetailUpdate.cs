using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class TenantDetailUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ManagerName",
                table: "TenantDetails",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RepManagerName",
                table: "TenantDetails",
                maxLength: 200,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ManagerName",
                table: "TenantDetails");

            migrationBuilder.DropColumn(
                name: "RepManagerName",
                table: "TenantDetails");
        }
    }
}
