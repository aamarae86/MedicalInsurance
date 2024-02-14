using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class Add_TenxMigrationId_2Nov : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "TenxMigrationId",
                table: "ArJobCardHd",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TenxMigrationId",
                table: "ArJobCardAttachments",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TenxMigrationId",
                table: "ArInvoiceTr",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TenxMigrationId",
                table: "ArInvoiceHd",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TenxMigrationId",
                table: "ArDrCrTr",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TenxMigrationId",
                table: "ArDrCrHd",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TenxMigrationId",
                table: "ArJobCardHd");

            migrationBuilder.DropColumn(
                name: "TenxMigrationId",
                table: "ArJobCardAttachments");

            migrationBuilder.DropColumn(
                name: "TenxMigrationId",
                table: "ArInvoiceTr");

            migrationBuilder.DropColumn(
                name: "TenxMigrationId",
                table: "ArInvoiceHd");

            migrationBuilder.DropColumn(
                name: "TenxMigrationId",
                table: "ArDrCrTr");

            migrationBuilder.DropColumn(
                name: "TenxMigrationId",
                table: "ArDrCrHd");
        }
    }
}
