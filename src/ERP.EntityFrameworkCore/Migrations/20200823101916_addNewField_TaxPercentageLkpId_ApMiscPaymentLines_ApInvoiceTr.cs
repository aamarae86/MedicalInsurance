using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class addNewField_TaxPercentageLkpId_ApMiscPaymentLines_ApInvoiceTr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "TaxPercentageLkpId",
                table: "ApMiscPaymentLines",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TaxPercentageLkpId",
                table: "ApInvoiceTr",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApMiscPaymentLines_TaxPercentageLkpId",
                table: "ApMiscPaymentLines",
                column: "TaxPercentageLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_ApInvoiceTr_TaxPercentageLkpId",
                table: "ApInvoiceTr",
                column: "TaxPercentageLkpId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApInvoiceTr_FndLookupValues_TaxPercentageLkpId",
                table: "ApInvoiceTr",
                column: "TaxPercentageLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ApMiscPaymentLines_FndLookupValues_TaxPercentageLkpId",
                table: "ApMiscPaymentLines",
                column: "TaxPercentageLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApInvoiceTr_FndLookupValues_TaxPercentageLkpId",
                table: "ApInvoiceTr");

            migrationBuilder.DropForeignKey(
                name: "FK_ApMiscPaymentLines_FndLookupValues_TaxPercentageLkpId",
                table: "ApMiscPaymentLines");

            migrationBuilder.DropIndex(
                name: "IX_ApMiscPaymentLines_TaxPercentageLkpId",
                table: "ApMiscPaymentLines");

            migrationBuilder.DropIndex(
                name: "IX_ApInvoiceTr_TaxPercentageLkpId",
                table: "ApInvoiceTr");

            migrationBuilder.DropColumn(
                name: "TaxPercentageLkpId",
                table: "ApMiscPaymentLines");

            migrationBuilder.DropColumn(
                name: "TaxPercentageLkpId",
                table: "ApInvoiceTr");
        }
    }
}
