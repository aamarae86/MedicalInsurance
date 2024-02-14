using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class Update_tbl_GlMainAccounts_NullableAccountId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GlMainAccounts_GlCodeComDetails_AccountId",
                table: "GlMainAccounts");

            migrationBuilder.AlterColumn<long>(
                name: "AccountId",
                table: "GlMainAccounts",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddForeignKey(
                name: "FK_GlMainAccounts_GlCodeComDetails_AccountId",
                table: "GlMainAccounts",
                column: "AccountId",
                principalTable: "GlCodeComDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GlMainAccounts_GlCodeComDetails_AccountId",
                table: "GlMainAccounts");

            migrationBuilder.AlterColumn<long>(
                name: "AccountId",
                table: "GlMainAccounts",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_GlMainAccounts_GlCodeComDetails_AccountId",
                table: "GlMainAccounts",
                column: "AccountId",
                principalTable: "GlCodeComDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
