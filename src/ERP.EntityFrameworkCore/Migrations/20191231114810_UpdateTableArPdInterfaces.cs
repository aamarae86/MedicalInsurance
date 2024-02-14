using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class UpdateTableArPdInterfaces : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArPdcInterface_ApBankAccounts_StatusLkpId",
                table: "ArPdcInterface");

            migrationBuilder.AddColumn<long>(
                name: "BankLkpId",
                table: "ArPdcInterface",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CustomerId",
                table: "ArPdcInterface",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SourceNumber",
                table: "ArPdcInterface",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ArPdcInterface_BankAccountId",
                table: "ArPdcInterface",
                column: "BankAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_ArPdcInterface_BankLkpId",
                table: "ArPdcInterface",
                column: "BankLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_ArPdcInterface_CustomerId",
                table: "ArPdcInterface",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArPdcInterface_ApBankAccounts_BankAccountId",
                table: "ArPdcInterface",
                column: "BankAccountId",
                principalTable: "ApBankAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ArPdcInterface_FndLookupValues_BankLkpId",
                table: "ArPdcInterface",
                column: "BankLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ArPdcInterface_ArCustomers_CustomerId",
                table: "ArPdcInterface",
                column: "CustomerId",
                principalTable: "ArCustomers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArPdcInterface_ApBankAccounts_BankAccountId",
                table: "ArPdcInterface");

            migrationBuilder.DropForeignKey(
                name: "FK_ArPdcInterface_FndLookupValues_BankLkpId",
                table: "ArPdcInterface");

            migrationBuilder.DropForeignKey(
                name: "FK_ArPdcInterface_ArCustomers_CustomerId",
                table: "ArPdcInterface");

            migrationBuilder.DropIndex(
                name: "IX_ArPdcInterface_BankAccountId",
                table: "ArPdcInterface");

            migrationBuilder.DropIndex(
                name: "IX_ArPdcInterface_BankLkpId",
                table: "ArPdcInterface");

            migrationBuilder.DropIndex(
                name: "IX_ArPdcInterface_CustomerId",
                table: "ArPdcInterface");

            migrationBuilder.DropColumn(
                name: "BankLkpId",
                table: "ArPdcInterface");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "ArPdcInterface");

            migrationBuilder.DropColumn(
                name: "SourceNumber",
                table: "ArPdcInterface");

            migrationBuilder.AddForeignKey(
                name: "FK_ArPdcInterface_ApBankAccounts_StatusLkpId",
                table: "ArPdcInterface",
                column: "StatusLkpId",
                principalTable: "ApBankAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
