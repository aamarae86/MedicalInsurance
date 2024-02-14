using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class pmcontractedit2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "PaymentNo",
                table: "PmContractPayments",
                type: "decimal(18, 6)",
                nullable: false,
                defaultValue: 0m);

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
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
