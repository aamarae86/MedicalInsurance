using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class StoreIssuePropsExceptCodeCom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IvStoreIssueTrs_IvStoreIssueHds_IvStoreIssueId",
                table: "IvStoreIssueTrs");

            migrationBuilder.DropColumn(
                name: "ReceivedDate",
                table: "IvStoreIssueTrs");

            migrationBuilder.DropColumn(
                name: "ReceivedQty",
                table: "IvStoreIssueTrs");

            migrationBuilder.RenameColumn(
                name: "UnitPrice",
                table: "IvStoreIssueTrs",
                newName: "Qty");

            migrationBuilder.RenameColumn(
                name: "QtyOrdered",
                table: "IvStoreIssueTrs",
                newName: "AvgCost");

            migrationBuilder.RenameColumn(
                name: "IvStoreIssueId",
                table: "IvStoreIssueTrs",
                newName: "IvUnitId");

            migrationBuilder.RenameIndex(
                name: "IX_IvStoreIssueTrs_IvStoreIssueId",
                table: "IvStoreIssueTrs",
                newName: "IX_IvStoreIssueTrs_IvUnitId");

            migrationBuilder.AddColumn<long>(
                name: "IvStoreIssueHdId",
                table: "IvStoreIssueTrs",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "BeneficiaryName",
                table: "IvStoreIssueHds",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "BeneficiaryTypeLkpId",
                table: "IvStoreIssueHds",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "IvStoreIssueHds",
                maxLength: 4000,
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "IssueTypeLkpId",
                table: "IvStoreIssueHds",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "ManualNo",
                table: "IvStoreIssueHds",
                maxLength: 20,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_IvStoreIssueTrs_IvStoreIssueHdId",
                table: "IvStoreIssueTrs",
                column: "IvStoreIssueHdId");

            migrationBuilder.CreateIndex(
                name: "IX_IvStoreIssueHds_BeneficiaryTypeLkpId",
                table: "IvStoreIssueHds",
                column: "BeneficiaryTypeLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_IvStoreIssueHds_IssueTypeLkpId",
                table: "IvStoreIssueHds",
                column: "IssueTypeLkpId");

            migrationBuilder.AddForeignKey(
                name: "FK_IvStoreIssueHds_FndLookupValues_BeneficiaryTypeLkpId",
                table: "IvStoreIssueHds",
                column: "BeneficiaryTypeLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IvStoreIssueHds_FndLookupValues_IssueTypeLkpId",
                table: "IvStoreIssueHds",
                column: "IssueTypeLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IvStoreIssueTrs_IvStoreIssueHds_IvStoreIssueHdId",
                table: "IvStoreIssueTrs",
                column: "IvStoreIssueHdId",
                principalTable: "IvStoreIssueHds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IvStoreIssueTrs_IvUnits_IvUnitId",
                table: "IvStoreIssueTrs",
                column: "IvUnitId",
                principalTable: "IvUnits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IvStoreIssueHds_FndLookupValues_BeneficiaryTypeLkpId",
                table: "IvStoreIssueHds");

            migrationBuilder.DropForeignKey(
                name: "FK_IvStoreIssueHds_FndLookupValues_IssueTypeLkpId",
                table: "IvStoreIssueHds");

            migrationBuilder.DropForeignKey(
                name: "FK_IvStoreIssueTrs_IvStoreIssueHds_IvStoreIssueHdId",
                table: "IvStoreIssueTrs");

            migrationBuilder.DropForeignKey(
                name: "FK_IvStoreIssueTrs_IvUnits_IvUnitId",
                table: "IvStoreIssueTrs");

            migrationBuilder.DropIndex(
                name: "IX_IvStoreIssueTrs_IvStoreIssueHdId",
                table: "IvStoreIssueTrs");

            migrationBuilder.DropIndex(
                name: "IX_IvStoreIssueHds_BeneficiaryTypeLkpId",
                table: "IvStoreIssueHds");

            migrationBuilder.DropIndex(
                name: "IX_IvStoreIssueHds_IssueTypeLkpId",
                table: "IvStoreIssueHds");

            migrationBuilder.DropColumn(
                name: "IvStoreIssueHdId",
                table: "IvStoreIssueTrs");

            migrationBuilder.DropColumn(
                name: "BeneficiaryName",
                table: "IvStoreIssueHds");

            migrationBuilder.DropColumn(
                name: "BeneficiaryTypeLkpId",
                table: "IvStoreIssueHds");

            migrationBuilder.DropColumn(
                name: "Comment",
                table: "IvStoreIssueHds");

            migrationBuilder.DropColumn(
                name: "IssueTypeLkpId",
                table: "IvStoreIssueHds");

            migrationBuilder.DropColumn(
                name: "ManualNo",
                table: "IvStoreIssueHds");

            migrationBuilder.RenameColumn(
                name: "Qty",
                table: "IvStoreIssueTrs",
                newName: "UnitPrice");

            migrationBuilder.RenameColumn(
                name: "IvUnitId",
                table: "IvStoreIssueTrs",
                newName: "IvStoreIssueId");

            migrationBuilder.RenameColumn(
                name: "AvgCost",
                table: "IvStoreIssueTrs",
                newName: "QtyOrdered");

            migrationBuilder.RenameIndex(
                name: "IX_IvStoreIssueTrs_IvUnitId",
                table: "IvStoreIssueTrs",
                newName: "IX_IvStoreIssueTrs_IvStoreIssueId");

            migrationBuilder.AddColumn<DateTime>(
                name: "ReceivedDate",
                table: "IvStoreIssueTrs",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ReceivedQty",
                table: "IvStoreIssueTrs",
                type: "decimal(18, 6)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_IvStoreIssueTrs_IvStoreIssueHds_IvStoreIssueId",
                table: "IvStoreIssueTrs",
                column: "IvStoreIssueId",
                principalTable: "IvStoreIssueHds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
