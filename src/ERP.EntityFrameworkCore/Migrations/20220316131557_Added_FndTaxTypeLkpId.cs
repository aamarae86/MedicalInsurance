using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class Added_FndTaxTypeLkpId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "FndTaxTypeLkpId",
                table: "ApMiscPaymentLines",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApMiscPaymentLines_FndTaxTypeLkpId",
                table: "ApMiscPaymentLines",
                column: "FndTaxTypeLkpId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApMiscPaymentLines_FndTaxType_FndTaxTypeLkpId",
                table: "ApMiscPaymentLines",
                column: "FndTaxTypeLkpId",
                principalTable: "FndTaxType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApMiscPaymentLines_FndTaxType_FndTaxTypeLkpId",
                table: "ApMiscPaymentLines");

            migrationBuilder.DropIndex(
                name: "IX_ApMiscPaymentLines_FndTaxTypeLkpId",
                table: "ApMiscPaymentLines");

            migrationBuilder.DropColumn(
                name: "FndTaxTypeLkpId",
                table: "ApMiscPaymentLines");
        }
    }
}
