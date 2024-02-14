using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class ArReceiptsRelationsReviewed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ArReceipts_CurrencyId",
                table: "ArReceipts");

            migrationBuilder.DropForeignKey(
                name: "FK_ArReceiptDetails_FndLookupValues_BankLkpId",
                table: "ArReceiptDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ArReceipts_FndLookupValues_ArCustomerId",
                table: "ArReceipts");

            migrationBuilder.DropForeignKey(
                name: "FK_ArReceipts_FndLookupValues_BankAccountId",
                table: "ArReceipts");

            migrationBuilder.DropForeignKey(
                name: "FK_ArReceipts_FndLookupValues_CurrencyId",
                table: "ArReceipts");

            migrationBuilder.DropForeignKey(
                name: "FK_ArReceipts_FndLookupValues_RemitanceBankId",
                table: "ArReceipts");

            migrationBuilder.AlterColumn<int>(
                name: "CurrencyId",
                table: "ArReceipts",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AddForeignKey(
                name: "FK_ArReceiptDetails_ApBanks_BankLkpId",
                table: "ArReceiptDetails",
                column: "BankLkpId",
                principalTable: "ApBanks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ArReceipts_ArCustomers_ArCustomerId",
                table: "ArReceipts",
                column: "ArCustomerId",
                principalTable: "ArCustomers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ArReceipts_ApBankAccounts_BankAccountId",
                table: "ArReceipts",
                column: "BankAccountId",
                principalTable: "ApBankAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ArReceipts_Currencies_CurrencyId",
                table: "ArReceipts",
                column: "CurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ArReceipts_ApBankAccounts_RemitanceBankId",
                table: "ArReceipts",
                column: "RemitanceBankId",
                principalTable: "ApBankAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.CreateIndex(
                name: "IX_ArReceipts_CurrencyId",
                table: "ArReceipts",
                column: "CurrencyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ArReceipts_CurrencyId",
                table: "ArReceipts");

            migrationBuilder.DropForeignKey(
                name: "FK_ArReceiptDetails_ApBanks_BankLkpId",
                table: "ArReceiptDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ArReceipts_ArCustomers_ArCustomerId",
                table: "ArReceipts");

            migrationBuilder.DropForeignKey(
                name: "FK_ArReceipts_ApBankAccounts_BankAccountId",
                table: "ArReceipts");

            migrationBuilder.DropForeignKey(
                name: "FK_ArReceipts_Currencies_CurrencyId",
                table: "ArReceipts");

            migrationBuilder.DropForeignKey(
                name: "FK_ArReceipts_ApBankAccounts_RemitanceBankId",
                table: "ArReceipts");

            migrationBuilder.AlterColumn<long>(
                name: "CurrencyId",
                table: "ArReceipts",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_ArReceiptDetails_FndLookupValues_BankLkpId",
                table: "ArReceiptDetails",
                column: "BankLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArReceipts_FndLookupValues_ArCustomerId",
                table: "ArReceipts",
                column: "ArCustomerId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ArReceipts_FndLookupValues_BankAccountId",
                table: "ArReceipts",
                column: "BankAccountId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArReceipts_FndLookupValues_CurrencyId",
                table: "ArReceipts",
                column: "CurrencyId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArReceipts_FndLookupValues_RemitanceBankId",
                table: "ArReceipts",
                column: "RemitanceBankId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.CreateIndex(
                name: "IX_ArReceipts_CurrencyId",
                table: "ArReceipts",
                column: "CurrencyId");
        }
    }
}
