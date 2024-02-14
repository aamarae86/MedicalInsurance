using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class FixRelationWithAccIdWithCodeComIdInGlJeLines : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GlJeLines_GlAccounts_AccountId",
                table: "GlJeLines");

            migrationBuilder.AddForeignKey(
                name: "FK_GlJeLines_GlCodeComDetails_AccountId",
                table: "GlJeLines",
                column: "AccountId",
                principalTable: "GlCodeComDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GlJeLines_GlCodeComDetails_AccountId",
                table: "GlJeLines");

            migrationBuilder.AddForeignKey(
                name: "FK_GlJeLines_GlAccounts_AccountId",
                table: "GlJeLines",
                column: "AccountId",
                principalTable: "GlAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
