using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class editPmContractPayments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PmContractPayments_FndLookupValues_PaymentSourceLkpId",
                table: "PmContractPayments");

            migrationBuilder.DropIndex(
                name: "IX_PmContractPayments_PaymentSourceLkpId",
                table: "PmContractPayments");

            migrationBuilder.DropColumn(
                name: "PaymentSourceLkpId",
                table: "PmContractPayments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "PaymentSourceLkpId",
                table: "PmContractPayments",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_PmContractPayments_PaymentSourceLkpId",
                table: "PmContractPayments",
                column: "PaymentSourceLkpId");

            migrationBuilder.AddForeignKey(
                name: "FK_PmContractPayments_FndLookupValues_PaymentSourceLkpId",
                table: "PmContractPayments",
                column: "PaymentSourceLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
