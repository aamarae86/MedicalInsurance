using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class Add_TenxMigrationId_ArCustomers_ApVendors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "TenxMigrationId",
                table: "ArCustomers",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TenxMigrationId",
                table: "ApVendors",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TenxMigrationId",
                table: "ArCustomers");

            migrationBuilder.DropColumn(
                name: "TenxMigrationId",
                table: "ApVendors");
        }
    }
}
