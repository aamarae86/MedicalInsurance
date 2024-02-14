using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class Add_TenxMigrationId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "TenxMigrationId",
                table: "GlJeLines",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TenxMigrationId",
                table: "GlJeIntegrationLines",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TenxMigrationId",
                table: "GlJeIntegrationHeaders",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TenxMigrationId",
                table: "GlJeHeaders",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TenxMigrationId",
                table: "GlCodeComDetails",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TenxMigrationId",
                table: "GlAccounts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TenxMigrationId",
                table: "GlJeLines");

            migrationBuilder.DropColumn(
                name: "TenxMigrationId",
                table: "GlJeIntegrationLines");

            migrationBuilder.DropColumn(
                name: "TenxMigrationId",
                table: "GlJeIntegrationHeaders");

            migrationBuilder.DropColumn(
                name: "TenxMigrationId",
                table: "GlJeHeaders");

            migrationBuilder.DropColumn(
                name: "TenxMigrationId",
                table: "GlCodeComDetails");

            migrationBuilder.DropColumn(
                name: "TenxMigrationId",
                table: "GlAccounts");
        }
    }
}
