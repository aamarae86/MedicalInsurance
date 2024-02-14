using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class Add_TenxMigrationId_2Nov3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "TenxMigrationId",
                table: "ApBanks",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TenxMigrationId",
                table: "ApBankAccounts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TenxMigrationId",
                table: "ApBanks");

            migrationBuilder.DropColumn(
                name: "TenxMigrationId",
                table: "ApBankAccounts");
        }
    }
}
