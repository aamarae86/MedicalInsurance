using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class editScCommitteesCheckDetails1111 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberOfMonths",
                table: "ScPortalRequestMgrDecision",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ScPortalRequestMgrDecisionId",
                table: "ScCommitteesCheckDetails",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ScCommitteesCheckDetails_ScPortalRequestMgrDecisionId",
                table: "ScCommitteesCheckDetails",
                column: "ScPortalRequestMgrDecisionId");

            migrationBuilder.AddForeignKey(
                name: "FK_ScCommitteesCheckDetails_ScPortalRequestMgrDecision_ScPortalRequestMgrDecisionId",
                table: "ScCommitteesCheckDetails",
                column: "ScPortalRequestMgrDecisionId",
                principalTable: "ScPortalRequestMgrDecision",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScCommitteesCheckDetails_ScPortalRequestMgrDecision_ScPortalRequestMgrDecisionId",
                table: "ScCommitteesCheckDetails");

            migrationBuilder.DropIndex(
                name: "IX_ScCommitteesCheckDetails_ScPortalRequestMgrDecisionId",
                table: "ScCommitteesCheckDetails");

            migrationBuilder.DropColumn(
                name: "NumberOfMonths",
                table: "ScPortalRequestMgrDecision");

            migrationBuilder.DropColumn(
                name: "ScPortalRequestMgrDecisionId",
                table: "ScCommitteesCheckDetails");
        }
    }
}
