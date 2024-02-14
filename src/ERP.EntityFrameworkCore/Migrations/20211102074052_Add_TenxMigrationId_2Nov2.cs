using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class Add_TenxMigrationId_2Nov2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "TenxMigrationId",
                table: "ArReceiptsOnAccount",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TenxMigrationId",
                table: "ArReceipts",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TenxMigrationId",
                table: "ArReceiptDetails",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TenxMigrationId",
                table: "ArPdcInterface",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TenxMigrationId",
                table: "ArMiscReceiptLines",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TenxMigrationId",
                table: "ArMiscReceiptHeaders",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TenxMigrationId",
                table: "ArMiscReceiptDetails",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TenxMigrationId",
                table: "ApPdcInterface",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TenxMigrationId",
                table: "ApPaymentsTransactions",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TenxMigrationId",
                table: "ApMiscPaymentLines",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TenxMigrationId",
                table: "ApMiscPaymentHeaders",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TenxMigrationId",
                table: "ApMiscPaymentDetails",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TenxMigrationId",
                table: "ApInvoiceTr",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TenxMigrationId",
                table: "ApInvoiceHd",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TenxMigrationId",
                table: "ArReceiptsOnAccount");

            migrationBuilder.DropColumn(
                name: "TenxMigrationId",
                table: "ArReceipts");

            migrationBuilder.DropColumn(
                name: "TenxMigrationId",
                table: "ArReceiptDetails");

            migrationBuilder.DropColumn(
                name: "TenxMigrationId",
                table: "ArPdcInterface");

            migrationBuilder.DropColumn(
                name: "TenxMigrationId",
                table: "ArMiscReceiptLines");

            migrationBuilder.DropColumn(
                name: "TenxMigrationId",
                table: "ArMiscReceiptHeaders");

            migrationBuilder.DropColumn(
                name: "TenxMigrationId",
                table: "ArMiscReceiptDetails");

            migrationBuilder.DropColumn(
                name: "TenxMigrationId",
                table: "ApPdcInterface");

            migrationBuilder.DropColumn(
                name: "TenxMigrationId",
                table: "ApPaymentsTransactions");

            migrationBuilder.DropColumn(
                name: "TenxMigrationId",
                table: "ApMiscPaymentLines");

            migrationBuilder.DropColumn(
                name: "TenxMigrationId",
                table: "ApMiscPaymentHeaders");

            migrationBuilder.DropColumn(
                name: "TenxMigrationId",
                table: "ApMiscPaymentDetails");

            migrationBuilder.DropColumn(
                name: "TenxMigrationId",
                table: "ApInvoiceTr");

            migrationBuilder.DropColumn(
                name: "TenxMigrationId",
                table: "ApInvoiceHd");
        }
    }
}
