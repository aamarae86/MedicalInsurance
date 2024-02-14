using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class editArSecurityDepositInterface : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArSecurityDepositInterface_GlCodeComDetails_FineAccountId",
                table: "ArSecurityDepositInterface");

            migrationBuilder.DropColumn(
                name: "FineAmount",
                table: "ArSecurityDepositInterface");

            migrationBuilder.RenameColumn(
                name: "FineAccountId",
                table: "ArSecurityDepositInterface",
                newName: "GlCodeComDetailsId");

            migrationBuilder.RenameIndex(
                name: "IX_ArSecurityDepositInterface_FineAccountId",
                table: "ArSecurityDepositInterface",
                newName: "IX_ArSecurityDepositInterface_GlCodeComDetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArSecurityDepositInterface_GlCodeComDetails_GlCodeComDetailsId",
                table: "ArSecurityDepositInterface",
                column: "GlCodeComDetailsId",
                principalTable: "GlCodeComDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArSecurityDepositInterface_GlCodeComDetails_GlCodeComDetailsId",
                table: "ArSecurityDepositInterface");

            migrationBuilder.RenameColumn(
                name: "GlCodeComDetailsId",
                table: "ArSecurityDepositInterface",
                newName: "FineAccountId");

            migrationBuilder.RenameIndex(
                name: "IX_ArSecurityDepositInterface_GlCodeComDetailsId",
                table: "ArSecurityDepositInterface",
                newName: "IX_ArSecurityDepositInterface_FineAccountId");

            migrationBuilder.AddColumn<decimal>(
                name: "FineAmount",
                table: "ArSecurityDepositInterface",
                type: "decimal(18, 6)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ArSecurityDepositInterface_GlCodeComDetails_FineAccountId",
                table: "ArSecurityDepositInterface",
                column: "FineAccountId",
                principalTable: "GlCodeComDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
