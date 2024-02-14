using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class adding4RelationsToGeneralUnPost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ArMiscReceiptHeadersId",
                table: "GeneralUnPost",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PmContractId",
                table: "GeneralUnPost",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ScCommitteesId",
                table: "GeneralUnPost",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ScPortalRequestMgrDecisionId",
                table: "GeneralUnPost",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GeneralUnPost_ArMiscReceiptHeadersId",
                table: "GeneralUnPost",
                column: "ArMiscReceiptHeadersId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralUnPost_PmContractId",
                table: "GeneralUnPost",
                column: "PmContractId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralUnPost_ScCommitteesId",
                table: "GeneralUnPost",
                column: "ScCommitteesId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralUnPost_ScPortalRequestMgrDecisionId",
                table: "GeneralUnPost",
                column: "ScPortalRequestMgrDecisionId");

            migrationBuilder.AddForeignKey(
                name: "FK_GeneralUnPost_ArMiscReceiptHeaders_ArMiscReceiptHeadersId",
                table: "GeneralUnPost",
                column: "ArMiscReceiptHeadersId",
                principalTable: "ArMiscReceiptHeaders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GeneralUnPost_PmContract_PmContractId",
                table: "GeneralUnPost",
                column: "PmContractId",
                principalTable: "PmContract",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GeneralUnPost_ScCommittees_ScCommitteesId",
                table: "GeneralUnPost",
                column: "ScCommitteesId",
                principalTable: "ScCommittees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GeneralUnPost_ScPortalRequestMgrDecision_ScPortalRequestMgrDecisionId",
                table: "GeneralUnPost",
                column: "ScPortalRequestMgrDecisionId",
                principalTable: "ScPortalRequestMgrDecision",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GeneralUnPost_ArMiscReceiptHeaders_ArMiscReceiptHeadersId",
                table: "GeneralUnPost");

            migrationBuilder.DropForeignKey(
                name: "FK_GeneralUnPost_PmContract_PmContractId",
                table: "GeneralUnPost");

            migrationBuilder.DropForeignKey(
                name: "FK_GeneralUnPost_ScCommittees_ScCommitteesId",
                table: "GeneralUnPost");

            migrationBuilder.DropForeignKey(
                name: "FK_GeneralUnPost_ScPortalRequestMgrDecision_ScPortalRequestMgrDecisionId",
                table: "GeneralUnPost");

            migrationBuilder.DropIndex(
                name: "IX_GeneralUnPost_ArMiscReceiptHeadersId",
                table: "GeneralUnPost");

            migrationBuilder.DropIndex(
                name: "IX_GeneralUnPost_PmContractId",
                table: "GeneralUnPost");

            migrationBuilder.DropIndex(
                name: "IX_GeneralUnPost_ScCommitteesId",
                table: "GeneralUnPost");

            migrationBuilder.DropIndex(
                name: "IX_GeneralUnPost_ScPortalRequestMgrDecisionId",
                table: "GeneralUnPost");

            migrationBuilder.DropColumn(
                name: "ArMiscReceiptHeadersId",
                table: "GeneralUnPost");

            migrationBuilder.DropColumn(
                name: "PmContractId",
                table: "GeneralUnPost");

            migrationBuilder.DropColumn(
                name: "ScCommitteesId",
                table: "GeneralUnPost");

            migrationBuilder.DropColumn(
                name: "ScPortalRequestMgrDecisionId",
                table: "GeneralUnPost");
        }
    }
}
