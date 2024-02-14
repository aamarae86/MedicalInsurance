using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class ScPortalRequestaddNewColumnResearcher : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ResearcherId",
                table: "ScPortalRequests",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ScPortalRequests_ResearcherId",
                table: "ScPortalRequests",
                column: "ResearcherId");

            migrationBuilder.AddForeignKey(
                name: "FK_ScPortalRequests_AbpUsers_ResearcherId",
                table: "ScPortalRequests",
                column: "ResearcherId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScPortalRequests_AbpUsers_ResearcherId",
                table: "ScPortalRequests");

            migrationBuilder.DropIndex(
                name: "IX_ScPortalRequests_ResearcherId",
                table: "ScPortalRequests");

            migrationBuilder.DropColumn(
                name: "ResearcherId",
                table: "ScPortalRequests");
        }
    }
}
