using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class pmcontractedit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PmContract_FndLookupValues_PmPaymentNoLkpId",
                table: "PmContract");

            migrationBuilder.DropIndex(
                name: "IX_PmContract_PmPaymentNoLkpId",
                table: "PmContract");

            migrationBuilder.DropColumn(
                name: "PaymentNo",
                table: "PmContractPayments");

            migrationBuilder.DropColumn(
                name: "PmPaymentNoLkpId",
                table: "PmContract");

            migrationBuilder.AddColumn<decimal>(
                name: "AnnualRentAmount",
                table: "PmContract",
                type: "decimal(18, 6)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnnualRentAmount",
                table: "PmContract");

            migrationBuilder.AddColumn<int>(
                name: "PaymentNo",
                table: "PmContractPayments",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PmPaymentNoLkpId",
                table: "PmContract",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_PmContract_PmPaymentNoLkpId",
                table: "PmContract",
                column: "PmPaymentNoLkpId");

            migrationBuilder.AddForeignKey(
                name: "FK_PmContract_FndLookupValues_PmPaymentNoLkpId",
                table: "PmContract",
                column: "PmPaymentNoLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
