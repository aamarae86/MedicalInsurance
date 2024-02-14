using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class NullableCodeComsInOwnersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PmOwners_GlCodeComDetails_AccountId",
                table: "PmOwners");

            migrationBuilder.DropForeignKey(
                name: "FK_PmOwners_GlCodeComDetails_BankAccountId",
                table: "PmOwners");

            migrationBuilder.DropForeignKey(
                name: "FK_PmOwners_GlCodeComDetails_CashAccountId",
                table: "PmOwners");

            migrationBuilder.DropForeignKey(
                name: "FK_PmOwners_GlCodeComDetails_CurrentAccountId",
                table: "PmOwners");

            migrationBuilder.AlterColumn<long>(
                name: "CurrentAccountId",
                table: "PmOwners",
                nullable: true,
                oldClrType: typeof(long));

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

            migrationBuilder.AlterColumn<long>(
                name: "AccountId",
                table: "PmOwners",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddForeignKey(
                name: "FK_PmOwners_GlCodeComDetails_AccountId",
                table: "PmOwners",
                column: "AccountId",
                principalTable: "GlCodeComDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PmOwners_GlCodeComDetails_BankAccountId",
                table: "PmOwners",
                column: "BankAccountId",
                principalTable: "GlCodeComDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PmOwners_GlCodeComDetails_CashAccountId",
                table: "PmOwners",
                column: "CashAccountId",
                principalTable: "GlCodeComDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PmOwners_GlCodeComDetails_CurrentAccountId",
                table: "PmOwners",
                column: "CurrentAccountId",
                principalTable: "GlCodeComDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PmOwners_GlCodeComDetails_AccountId",
                table: "PmOwners");

            migrationBuilder.DropForeignKey(
                name: "FK_PmOwners_GlCodeComDetails_BankAccountId",
                table: "PmOwners");

            migrationBuilder.DropForeignKey(
                name: "FK_PmOwners_GlCodeComDetails_CashAccountId",
                table: "PmOwners");

            migrationBuilder.DropForeignKey(
                name: "FK_PmOwners_GlCodeComDetails_CurrentAccountId",
                table: "PmOwners");

            migrationBuilder.AlterColumn<long>(
                name: "CurrentAccountId",
                table: "PmOwners",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

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

            migrationBuilder.AlterColumn<long>(
                name: "AccountId",
                table: "PmOwners",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PmOwners_GlCodeComDetails_AccountId",
                table: "PmOwners",
                column: "AccountId",
                principalTable: "GlCodeComDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PmOwners_GlCodeComDetails_BankAccountId",
                table: "PmOwners",
                column: "BankAccountId",
                principalTable: "GlCodeComDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PmOwners_GlCodeComDetails_CashAccountId",
                table: "PmOwners",
                column: "CashAccountId",
                principalTable: "GlCodeComDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PmOwners_GlCodeComDetails_CurrentAccountId",
                table: "PmOwners",
                column: "CurrentAccountId",
                principalTable: "GlCodeComDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
