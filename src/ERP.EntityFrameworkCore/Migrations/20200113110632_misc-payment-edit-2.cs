using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class miscpaymentedit2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ApMiscPaymentHeaders_BankAccountId",
                table: "ApMiscPaymentHeaders",
                column: "BankAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApMiscPaymentHeaders_ApBankAccounts_BankAccountId",
                table: "ApMiscPaymentHeaders",
                column: "BankAccountId",
                principalTable: "ApBankAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApMiscPaymentHeaders_ApBankAccounts_BankAccountId",
                table: "ApMiscPaymentHeaders");

            migrationBuilder.DropIndex(
                name: "IX_ApMiscPaymentHeaders_BankAccountId",
                table: "ApMiscPaymentHeaders");
        }
    }
}
