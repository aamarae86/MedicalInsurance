using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class EditIvSaleHd_AddBankAccountId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "BankAccountId",
                table: "IvSaleHd",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_IvSaleHd_BankAccountId",
                table: "IvSaleHd",
                column: "BankAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_IvSaleHd_ApBankAccounts_BankAccountId",
                table: "IvSaleHd",
                column: "BankAccountId",
                principalTable: "ApBankAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IvSaleHd_ApBankAccounts_BankAccountId",
                table: "IvSaleHd");

            migrationBuilder.DropIndex(
                name: "IX_IvSaleHd_BankAccountId",
                table: "IvSaleHd");

            migrationBuilder.DropColumn(
                name: "BankAccountId",
                table: "IvSaleHd");
        }
    }
}
