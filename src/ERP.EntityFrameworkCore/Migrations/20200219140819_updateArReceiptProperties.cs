using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class updateArReceiptProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArReceiptDetails_ArReceipts_ReceiptId",
                table: "ArReceiptDetails");

            migrationBuilder.DropColumn(
                name: "ArCustomerId",
                table: "ArReceiptsOnAccount");

            migrationBuilder.AlterColumn<long>(
                name: "ReceiptTypeLkpId",
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

            migrationBuilder.AlterColumn<long>(
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

            migrationBuilder.AddColumn<long>(
                name: "BankLkpId",
                table: "ArReceiptDetails",
                nullable: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_PmTenants_MaritalStatusLkpId",
            //    table: "PmTenants",
            //    column: "MaritalStatusLkpId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_PmTenants_PassportCountryLkpId",
            //    table: "PmTenants",
            //    column: "PassportCountryLkpId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_PmTenants_SpecialGenderLkpId",
            //    table: "PmTenants",
            //    column: "SpecialGenderLkpId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArReceiptDetails_ArReceipts_ReceiptId",
                table: "ArReceiptDetails",
                column: "ReceiptId",
                principalTable: "ArReceipts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_PmTenants_FndLookupValues_MaritalStatusLkpId",
            //    table: "PmTenants",
            //    column: "MaritalStatusLkpId",
            //    principalTable: "FndLookupValues",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Restrict);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_PmTenants_FndLookupValues_PassportCountryLkpId",
            //    table: "PmTenants",
            //    column: "PassportCountryLkpId",
            //    principalTable: "FndLookupValues",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Restrict);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_PmTenants_FndLookupValues_SpecialGenderLkpId",
            //    table: "PmTenants",
            //    column: "SpecialGenderLkpId",
            //    principalTable: "FndLookupValues",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArReceiptDetails_ArReceipts_ReceiptId",
                table: "ArReceiptDetails");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_PmTenants_FndLookupValues_MaritalStatusLkpId",
            //    table: "PmTenants");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_PmTenants_FndLookupValues_PassportCountryLkpId",
            //    table: "PmTenants");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_PmTenants_FndLookupValues_SpecialGenderLkpId",
            //    table: "PmTenants");

            //migrationBuilder.DropIndex(
            //    name: "IX_PmTenants_MaritalStatusLkpId",
            //    table: "PmTenants");

            //migrationBuilder.DropIndex(
            //    name: "IX_PmTenants_PassportCountryLkpId",
            //    table: "PmTenants");

            //migrationBuilder.DropIndex(
            //    name: "IX_PmTenants_SpecialGenderLkpId",
            //    table: "PmTenants");

            migrationBuilder.DropColumn(
                name: "BankLkpId",
                table: "ArReceiptDetails");

            migrationBuilder.AlterColumn<long>(
                name: "ReceiptTypeLkpId",
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

            migrationBuilder.AddColumn<long>(
                name: "ArCustomerId",
                table: "ArReceiptsOnAccount",
                nullable: true);

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
                oldClrType: typeof(long));

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
        }
    }
}
