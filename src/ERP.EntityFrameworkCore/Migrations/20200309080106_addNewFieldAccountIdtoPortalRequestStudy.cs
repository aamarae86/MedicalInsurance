using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class addNewFieldAccountIdtoPortalRequestStudy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "AccountId",
                table: "ScPortalRequestStudy",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ScPortalRequestStudy_AccountId",
                table: "ScPortalRequestStudy",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_ScPortalRequestStudy_GlCodeComDetails_AccountId",
                table: "ScPortalRequestStudy",
                column: "AccountId",
                principalTable: "GlCodeComDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScPortalRequestStudy_GlCodeComDetails_AccountId",
                table: "ScPortalRequestStudy");

            migrationBuilder.DropIndex(
                name: "IX_ScPortalRequestStudy_AccountId",
                table: "ScPortalRequestStudy");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "ScPortalRequestStudy");
        }
    }
}
