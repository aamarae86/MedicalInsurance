using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class add_DepositBankAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "DepositBankAccountId",
                table: "ArPdcInterface",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ArPdcInterface_DepositBankAccountId",
                table: "ArPdcInterface",
                column: "DepositBankAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArPdcInterface_ApBankAccounts_DepositBankAccountId",
                table: "ArPdcInterface",
                column: "DepositBankAccountId",
                principalTable: "ApBankAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArPdcInterface_ApBankAccounts_DepositBankAccountId",
                table: "ArPdcInterface");

            migrationBuilder.DropIndex(
                name: "IX_ArPdcInterface_DepositBankAccountId",
                table: "ArPdcInterface");

            migrationBuilder.DropColumn(
                name: "DepositBankAccountId",
                table: "ArPdcInterface");
        }
    }
}
