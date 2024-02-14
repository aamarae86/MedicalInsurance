using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class PmOwners_BankAndCashIds_NotCodeComs_ItIsBankAccount_WithRequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PmOwners_ApBankAccounts_BankAccountId",
                table: "PmOwners");

            migrationBuilder.DropForeignKey(
                name: "FK_PmOwners_ApBankAccounts_CashAccountId",
                table: "PmOwners");

            migrationBuilder.AlterColumn<long>(
                name: "CashAccountId",
                table: "PmOwners",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "BankAccountId",
                table: "PmOwners",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PmOwners_ApBankAccounts_BankAccountId",
                table: "PmOwners",
                column: "BankAccountId",
                principalTable: "ApBankAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PmOwners_ApBankAccounts_CashAccountId",
                table: "PmOwners",
                column: "CashAccountId",
                principalTable: "ApBankAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PmOwners_ApBankAccounts_BankAccountId",
                table: "PmOwners");

            migrationBuilder.DropForeignKey(
                name: "FK_PmOwners_ApBankAccounts_CashAccountId",
                table: "PmOwners");

            migrationBuilder.AlterColumn<long>(
                name: "CashAccountId",
                table: "PmOwners",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "BankAccountId",
                table: "PmOwners",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddForeignKey(
                name: "FK_PmOwners_ApBankAccounts_BankAccountId",
                table: "PmOwners",
                column: "BankAccountId",
                principalTable: "ApBankAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PmOwners_ApBankAccounts_CashAccountId",
                table: "PmOwners",
                column: "CashAccountId",
                principalTable: "ApBankAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
