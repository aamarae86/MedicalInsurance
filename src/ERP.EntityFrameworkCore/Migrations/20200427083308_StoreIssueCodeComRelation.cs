using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class StoreIssueCodeComRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_IvStoreIssueHd_AccountId",
                table: "IvStoreIssueHd",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_IvStoreIssueHd_GlCodeComDetails_AccountId",
                table: "IvStoreIssueHd",
                column: "AccountId",
                principalTable: "GlCodeComDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IvStoreIssueHd_GlCodeComDetails_AccountId",
                table: "IvStoreIssueHd");

            migrationBuilder.DropIndex(
                name: "IX_IvStoreIssueHd_AccountId",
                table: "IvStoreIssueHd");
        }
    }
}
