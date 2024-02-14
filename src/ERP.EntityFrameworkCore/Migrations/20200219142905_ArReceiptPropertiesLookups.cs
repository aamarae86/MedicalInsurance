using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class ArReceiptPropertiesLookups : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArReceiptsOnAccount_ArReceipts_ReceiptId",
                table: "ArReceiptsOnAccount");

            migrationBuilder.AlterColumn<long>(
                name: "ReceiptId",
                table: "ArReceiptsOnAccount",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ArReceiptsOnAccount_ReceiptTypeLkpId",
                table: "ArReceiptsOnAccount",
                column: "ReceiptTypeLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_ArReceipts_ArCustomerId",
                table: "ArReceipts",
                column: "ArCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ArReceipts_BankAccountId",
                table: "ArReceipts",
                column: "BankAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_ArReceipts_CurrencyId",
                table: "ArReceipts",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_ArReceipts_RemitanceBankId",
                table: "ArReceipts",
                column: "RemitanceBankId");

            migrationBuilder.CreateIndex(
                name: "IX_ArReceipts_StatusLkpId",
                table: "ArReceipts",
                column: "StatusLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_ArReceiptDetails_BankLkpId",
                table: "ArReceiptDetails",
                column: "BankLkpId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArReceiptDetails_FndLookupValues_BankLkpId",
                table: "ArReceiptDetails",
                column: "BankLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ArReceipts_FndLookupValues_CurrencyId",
                table: "ArReceipts",
                column: "CurrencyId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ArReceipts_FndLookupValues_RemitanceBankId",
                table: "ArReceipts",
                column: "RemitanceBankId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ArReceipts_FndLookupValues_StatusLkpId",
                table: "ArReceipts",
                column: "StatusLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ArReceiptsOnAccount_ArReceipts_ReceiptId",
                table: "ArReceiptsOnAccount",
                column: "ReceiptId",
                principalTable: "ArReceipts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ArReceiptsOnAccount_FndLookupValues_ReceiptTypeLkpId",
                table: "ArReceiptsOnAccount",
                column: "ReceiptTypeLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropForeignKey(
                name: "FK_ArReceipts_FndLookupValues_StatusLkpId",
                table: "ArReceipts");

            migrationBuilder.DropForeignKey(
                name: "FK_ArReceiptsOnAccount_ArReceipts_ReceiptId",
                table: "ArReceiptsOnAccount");

            migrationBuilder.DropForeignKey(
                name: "FK_ArReceiptsOnAccount_FndLookupValues_ReceiptTypeLkpId",
                table: "ArReceiptsOnAccount");

            migrationBuilder.DropIndex(
                name: "IX_ArReceiptsOnAccount_ReceiptTypeLkpId",
                table: "ArReceiptsOnAccount");

            migrationBuilder.DropIndex(
                name: "IX_ArReceipts_ArCustomerId",
                table: "ArReceipts");

            migrationBuilder.DropIndex(
                name: "IX_ArReceipts_BankAccountId",
                table: "ArReceipts");

            migrationBuilder.DropIndex(
                name: "IX_ArReceipts_CurrencyId",
                table: "ArReceipts");

            migrationBuilder.DropIndex(
                name: "IX_ArReceipts_RemitanceBankId",
                table: "ArReceipts");

            migrationBuilder.DropIndex(
                name: "IX_ArReceipts_StatusLkpId",
                table: "ArReceipts");

            migrationBuilder.DropIndex(
                name: "IX_ArReceiptDetails_BankLkpId",
                table: "ArReceiptDetails");

            migrationBuilder.AlterColumn<long>(
                name: "ReceiptId",
                table: "ArReceiptsOnAccount",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddForeignKey(
                name: "FK_ArReceiptsOnAccount_ArReceipts_ReceiptId",
                table: "ArReceiptsOnAccount",
                column: "ReceiptId",
                principalTable: "ArReceipts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
