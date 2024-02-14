using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class editportaluseraddnewfieldtenantcreator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArReceiptDetails_ArReceipts_ReceiptId",
                table: "ArReceiptDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ArReceiptsOnAccount_ArReceipts_ReceiptId",
                table: "ArReceiptsOnAccount");

            //migrationBuilder.DropColumn(
            //    name: "ArCustomerId",
            //    table: "ArReceiptsOnAccount");

            //migrationBuilder.AddColumn<long>(
            //    name: "StudyLkpId",
            //    table: "ScPortalRequestStudy",
            //    nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TenantCreatorId",
                table: "PortalUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<long>(
                name: "ReceiptTypeLkpId",
                table: "ArReceiptsOnAccount",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ReceiptId",
                table: "ArReceiptsOnAccount",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApplyDate",
                table: "ArReceiptsOnAccount",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "ArReceiptsOnAccount",
                type: "decimal(18, 6)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "StatusLkpId",
                table: "ArReceipts",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReceiptDate",
                table: "ArReceipts",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "CurrencyRate",
                table: "ArReceipts",
                type: "decimal(18, 6)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CurrencyId",
                table: "ArReceipts",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "BankAccountId",
                table: "ArReceipts",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ReceiptId",
                table: "ArReceiptDetails",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "MaturityDate",
                table: "ArReceiptDetails",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CheckNumber",
                table: "ArReceiptDetails",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "ArReceiptDetails",
                type: "decimal(18, 6)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldNullable: true);

            //migrationBuilder.AddColumn<long>(
            //    name: "BankLkpId",
            //    table: "ArReceiptDetails",
            //    nullable: false,
            //    defaultValue: 0L);

            //migrationBuilder.CreateIndex(
            //    name: "IX_ScPortalRequestStudy_StudyLkpId",
            //    table: "ScPortalRequestStudy",
            //    column: "StudyLkpId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ArReceiptsOnAccount_ReceiptTypeLkpId",
            //    table: "ArReceiptsOnAccount",
            //    column: "ReceiptTypeLkpId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ArReceipts_ArCustomerId",
            //    table: "ArReceipts",
            //    column: "ArCustomerId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ArReceipts_BankAccountId",
            //    table: "ArReceipts",
            //    column: "BankAccountId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ArReceipts_CurrencyId",
            //    table: "ArReceipts",
            //    column: "CurrencyId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ArReceipts_RemitanceBankId",
            //    table: "ArReceipts",
            //    column: "RemitanceBankId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ArReceipts_StatusLkpId",
            //    table: "ArReceipts",
            //    column: "StatusLkpId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ArReceiptDetails_BankLkpId",
            //    table: "ArReceiptDetails",
            //    column: "BankLkpId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_ArReceiptDetails_FndLookupValues_BankLkpId",
            //    table: "ArReceiptDetails",
            //    column: "BankLkpId",
            //    principalTable: "FndLookupValues",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.NoAction);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_ArReceiptDetails_ArReceipts_ReceiptId",
            //    table: "ArReceiptDetails",
            //    column: "ReceiptId",
            //    principalTable: "ArReceipts",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.NoAction);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_ArReceipts_ArCustomers_ArCustomerId",
            //    table: "ArReceipts",
            //    column: "ArCustomerId",
            //    principalTable: "ArCustomers",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Restrict);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_ArReceipts_ApBankAccounts_BankAccountId",
            //    table: "ArReceipts",
            //    column: "BankAccountId",
            //    principalTable: "ApBankAccounts",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.NoAction);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_ArReceipts_Currencies_CurrencyId",
            //    table: "ArReceipts",
            //    column: "CurrencyId",
            //    principalTable: "Currencies",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.NoAction);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_ArReceipts_ApBankAccounts_RemitanceBankId",
            //    table: "ArReceipts",
            //    column: "RemitanceBankId",
            //    principalTable: "ApBankAccounts",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Restrict);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_ArReceipts_FndLookupValues_StatusLkpId",
            //    table: "ArReceipts",
            //    column: "StatusLkpId",
            //    principalTable: "FndLookupValues",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.NoAction);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_ArReceiptsOnAccount_ArReceipts_ReceiptId",
            //    table: "ArReceiptsOnAccount",
            //    column: "ReceiptId",
            //    principalTable: "ArReceipts",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.NoAction);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_ArReceiptsOnAccount_FndLookupValues_ReceiptTypeLkpId",
            //    table: "ArReceiptsOnAccount",
            //    column: "ReceiptTypeLkpId",
            //    principalTable: "FndLookupValues",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.NoAction);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_ScPortalRequestStudy_FndLookupValues_StudyLkpId",
            //    table: "ScPortalRequestStudy",
            //    column: "StudyLkpId",
            //    principalTable: "FndLookupValues",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_ArReceiptDetails_FndLookupValues_BankLkpId",
            //    table: "ArReceiptDetails");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_ArReceiptDetails_ArReceipts_ReceiptId",
            //    table: "ArReceiptDetails");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_ArReceipts_ArCustomers_ArCustomerId",
            //    table: "ArReceipts");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_ArReceipts_ApBankAccounts_BankAccountId",
            //    table: "ArReceipts");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_ArReceipts_Currencies_CurrencyId",
            //    table: "ArReceipts");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_ArReceipts_ApBankAccounts_RemitanceBankId",
            //    table: "ArReceipts");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_ArReceipts_FndLookupValues_StatusLkpId",
            //    table: "ArReceipts");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_ArReceiptsOnAccount_ArReceipts_ReceiptId",
            //    table: "ArReceiptsOnAccount");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_ArReceiptsOnAccount_FndLookupValues_ReceiptTypeLkpId",
            //    table: "ArReceiptsOnAccount");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_ScPortalRequestStudy_FndLookupValues_StudyLkpId",
            //    table: "ScPortalRequestStudy");

            //migrationBuilder.DropIndex(
            //    name: "IX_ScPortalRequestStudy_StudyLkpId",
            //    table: "ScPortalRequestStudy");

            //migrationBuilder.DropIndex(
            //    name: "IX_ArReceiptsOnAccount_ReceiptTypeLkpId",
            //    table: "ArReceiptsOnAccount");

            //migrationBuilder.DropIndex(
            //    name: "IX_ArReceipts_ArCustomerId",
            //    table: "ArReceipts");

            //migrationBuilder.DropIndex(
            //    name: "IX_ArReceipts_BankAccountId",
            //    table: "ArReceipts");

            //migrationBuilder.DropIndex(
            //    name: "IX_ArReceipts_CurrencyId",
            //    table: "ArReceipts");

            //migrationBuilder.DropIndex(
            //    name: "IX_ArReceipts_RemitanceBankId",
            //    table: "ArReceipts");

            //migrationBuilder.DropIndex(
            //    name: "IX_ArReceipts_StatusLkpId",
            //    table: "ArReceipts");

            //migrationBuilder.DropIndex(
            //    name: "IX_ArReceiptDetails_BankLkpId",
            //    table: "ArReceiptDetails");

            //migrationBuilder.DropColumn(
            //    name: "StudyLkpId",
            //    table: "ScPortalRequestStudy");

            migrationBuilder.DropColumn(
                name: "TenantCreatorId",
                table: "PortalUsers");

            //migrationBuilder.DropColumn(
            //    name: "BankLkpId",
            //    table: "ArReceiptDetails");

            migrationBuilder.AlterColumn<long>(
                name: "ReceiptTypeLkpId",
                table: "ArReceiptsOnAccount",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "ReceiptId",
                table: "ArReceiptsOnAccount",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApplyDate",
                table: "ArReceiptsOnAccount",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "ArReceiptsOnAccount",
                type: "decimal(18, 6)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 6)");

            //migrationBuilder.AddColumn<long>(
            //    name: "ArCustomerId",
            //    table: "ArReceiptsOnAccount",
            //    nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "StatusLkpId",
                table: "ArReceipts",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReceiptDate",
                table: "ArReceipts",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<decimal>(
                name: "CurrencyRate",
                table: "ArReceipts",
                type: "decimal(18, 6)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 6)");

            migrationBuilder.AlterColumn<long>(
                name: "CurrencyId",
                table: "ArReceipts",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<long>(
                name: "BankAccountId",
                table: "ArReceipts",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "ReceiptId",
                table: "ArReceiptDetails",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<DateTime>(
                name: "MaturityDate",
                table: "ArReceiptDetails",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<string>(
                name: "CheckNumber",
                table: "ArReceiptDetails",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "ArReceiptDetails",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 6)");

            migrationBuilder.AddForeignKey(
                name: "FK_ArReceiptDetails_ArReceipts_ReceiptId",
                table: "ArReceiptDetails",
                column: "ReceiptId",
                principalTable: "ArReceipts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
