using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class editArSecurityDepositInterfacetbl2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArSecurityDepositInterface_GlCodeComDetails_FineAccountId",
                table: "ArSecurityDepositInterface");

            migrationBuilder.AlterColumn<long>(
                name: "FineAccountId",
                table: "ArSecurityDepositInterface",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddColumn<string>(
                name: "SourceNo",
                table: "ArSecurityDepositInterface",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ArSecurityDepositInterface_GlCodeComDetails_FineAccountId",
                table: "ArSecurityDepositInterface",
                column: "FineAccountId",
                principalTable: "GlCodeComDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArSecurityDepositInterface_GlCodeComDetails_FineAccountId",
                table: "ArSecurityDepositInterface");

            migrationBuilder.DropColumn(
                name: "SourceNo",
                table: "ArSecurityDepositInterface");

            migrationBuilder.AlterColumn<long>(
                name: "FineAccountId",
                table: "ArSecurityDepositInterface",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ArSecurityDepositInterface_GlCodeComDetails_FineAccountId",
                table: "ArSecurityDepositInterface",
                column: "FineAccountId",
                principalTable: "GlCodeComDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
