using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class editScCommitteeDetail2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScCommitteeDetails_FndLookupValues_OtherCommittee",
                table: "ScCommitteeDetails");

            migrationBuilder.RenameColumn(
                name: "OtherCommitteeMonthNo",
                table: "ScCommitteeDetails",
                newName: "OtherMonthNo");

            migrationBuilder.RenameColumn(
                name: "OtherCommittee",
                table: "ScCommitteeDetails",
                newName: "OtherAidLkpId");

            migrationBuilder.RenameIndex(
                name: "IX_ScCommitteeDetails_OtherCommittee",
                table: "ScCommitteeDetails",
                newName: "IX_ScCommitteeDetails_OtherAidLkpId");

            migrationBuilder.AddColumn<bool>(
                name: "IsMedicine",
                table: "ScPortalRequestMgrDecision",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "OtherAidLkpId",
                table: "ScPortalRequestMgrDecision",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OtherMonthNo",
                table: "ScPortalRequestMgrDecision",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsMedicine",
                table: "ScCommitteeDetails",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_ScPortalRequestMgrDecision_OtherAidLkpId",
                table: "ScPortalRequestMgrDecision",
                column: "OtherAidLkpId");

            migrationBuilder.AddForeignKey(
                name: "FK_ScCommitteeDetails_FndLookupValues_OtherAidLkpId",
                table: "ScCommitteeDetails",
                column: "OtherAidLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ScPortalRequestMgrDecision_FndLookupValues_OtherAidLkpId",
                table: "ScPortalRequestMgrDecision",
                column: "OtherAidLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScCommitteeDetails_FndLookupValues_OtherAidLkpId",
                table: "ScCommitteeDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ScPortalRequestMgrDecision_FndLookupValues_OtherAidLkpId",
                table: "ScPortalRequestMgrDecision");

            migrationBuilder.DropIndex(
                name: "IX_ScPortalRequestMgrDecision_OtherAidLkpId",
                table: "ScPortalRequestMgrDecision");

            migrationBuilder.DropColumn(
                name: "IsMedicine",
                table: "ScPortalRequestMgrDecision");

            migrationBuilder.DropColumn(
                name: "OtherAidLkpId",
                table: "ScPortalRequestMgrDecision");

            migrationBuilder.DropColumn(
                name: "OtherMonthNo",
                table: "ScPortalRequestMgrDecision");

            migrationBuilder.DropColumn(
                name: "IsMedicine",
                table: "ScCommitteeDetails");

            migrationBuilder.RenameColumn(
                name: "OtherMonthNo",
                table: "ScCommitteeDetails",
                newName: "OtherCommitteeMonthNo");

            migrationBuilder.RenameColumn(
                name: "OtherAidLkpId",
                table: "ScCommitteeDetails",
                newName: "OtherCommittee");

            migrationBuilder.RenameIndex(
                name: "IX_ScCommitteeDetails_OtherAidLkpId",
                table: "ScCommitteeDetails",
                newName: "IX_ScCommitteeDetails_OtherCommittee");

            migrationBuilder.AddForeignKey(
                name: "FK_ScCommitteeDetails_FndLookupValues_OtherCommittee",
                table: "ScCommitteeDetails",
                column: "OtherCommittee",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
