using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class renameTablesOfStoreIssue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IvStoreIssueHds_FndLookupValues_BeneficiaryTypeLkpId",
                table: "IvStoreIssueHds");

            migrationBuilder.DropForeignKey(
                name: "FK_IvStoreIssueHds_FndLookupValues_IssueTypeLkpId",
                table: "IvStoreIssueHds");

            migrationBuilder.DropForeignKey(
                name: "FK_IvStoreIssueHds_IvWarehouses_IvWarehouseId",
                table: "IvStoreIssueHds");

            migrationBuilder.DropForeignKey(
                name: "FK_IvStoreIssueHds_FndLookupValues_StatusLkpId",
                table: "IvStoreIssueHds");

            migrationBuilder.DropForeignKey(
                name: "FK_IvStoreIssueTrs_IvItems_IvItemId",
                table: "IvStoreIssueTrs");

            migrationBuilder.DropForeignKey(
                name: "FK_IvStoreIssueTrs_IvStoreIssueHds_IvStoreIssueHdId",
                table: "IvStoreIssueTrs");

            migrationBuilder.DropForeignKey(
                name: "FK_IvStoreIssueTrs_IvUnits_IvUnitId",
                table: "IvStoreIssueTrs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IvStoreIssueTrs",
                table: "IvStoreIssueTrs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IvStoreIssueHds",
                table: "IvStoreIssueHds");

            migrationBuilder.RenameTable(
                name: "IvStoreIssueTrs",
                newName: "IvStoreIssueTr");

            migrationBuilder.RenameTable(
                name: "IvStoreIssueHds",
                newName: "IvStoreIssueHd");

            migrationBuilder.RenameIndex(
                name: "IX_IvStoreIssueTrs_IvUnitId",
                table: "IvStoreIssueTr",
                newName: "IX_IvStoreIssueTr_IvUnitId");

            migrationBuilder.RenameIndex(
                name: "IX_IvStoreIssueTrs_IvStoreIssueHdId",
                table: "IvStoreIssueTr",
                newName: "IX_IvStoreIssueTr_IvStoreIssueHdId");

            migrationBuilder.RenameIndex(
                name: "IX_IvStoreIssueTrs_IvItemId",
                table: "IvStoreIssueTr",
                newName: "IX_IvStoreIssueTr_IvItemId");

            migrationBuilder.RenameIndex(
                name: "IX_IvStoreIssueHds_StatusLkpId",
                table: "IvStoreIssueHd",
                newName: "IX_IvStoreIssueHd_StatusLkpId");

            migrationBuilder.RenameIndex(
                name: "IX_IvStoreIssueHds_IvWarehouseId",
                table: "IvStoreIssueHd",
                newName: "IX_IvStoreIssueHd_IvWarehouseId");

            migrationBuilder.RenameIndex(
                name: "IX_IvStoreIssueHds_IssueTypeLkpId",
                table: "IvStoreIssueHd",
                newName: "IX_IvStoreIssueHd_IssueTypeLkpId");

            migrationBuilder.RenameIndex(
                name: "IX_IvStoreIssueHds_BeneficiaryTypeLkpId",
                table: "IvStoreIssueHd",
                newName: "IX_IvStoreIssueHd_BeneficiaryTypeLkpId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IvStoreIssueTr",
                table: "IvStoreIssueTr",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IvStoreIssueHd",
                table: "IvStoreIssueHd",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_IvStoreIssueHd_FndLookupValues_BeneficiaryTypeLkpId",
                table: "IvStoreIssueHd",
                column: "BeneficiaryTypeLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IvStoreIssueHd_FndLookupValues_IssueTypeLkpId",
                table: "IvStoreIssueHd",
                column: "IssueTypeLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IvStoreIssueHd_IvWarehouses_IvWarehouseId",
                table: "IvStoreIssueHd",
                column: "IvWarehouseId",
                principalTable: "IvWarehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IvStoreIssueHd_FndLookupValues_StatusLkpId",
                table: "IvStoreIssueHd",
                column: "StatusLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IvStoreIssueTr_IvItems_IvItemId",
                table: "IvStoreIssueTr",
                column: "IvItemId",
                principalTable: "IvItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IvStoreIssueTr_IvStoreIssueHd_IvStoreIssueHdId",
                table: "IvStoreIssueTr",
                column: "IvStoreIssueHdId",
                principalTable: "IvStoreIssueHd",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IvStoreIssueTr_IvUnits_IvUnitId",
                table: "IvStoreIssueTr",
                column: "IvUnitId",
                principalTable: "IvUnits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IvStoreIssueHd_FndLookupValues_BeneficiaryTypeLkpId",
                table: "IvStoreIssueHd");

            migrationBuilder.DropForeignKey(
                name: "FK_IvStoreIssueHd_FndLookupValues_IssueTypeLkpId",
                table: "IvStoreIssueHd");

            migrationBuilder.DropForeignKey(
                name: "FK_IvStoreIssueHd_IvWarehouses_IvWarehouseId",
                table: "IvStoreIssueHd");

            migrationBuilder.DropForeignKey(
                name: "FK_IvStoreIssueHd_FndLookupValues_StatusLkpId",
                table: "IvStoreIssueHd");

            migrationBuilder.DropForeignKey(
                name: "FK_IvStoreIssueTr_IvItems_IvItemId",
                table: "IvStoreIssueTr");

            migrationBuilder.DropForeignKey(
                name: "FK_IvStoreIssueTr_IvStoreIssueHd_IvStoreIssueHdId",
                table: "IvStoreIssueTr");

            migrationBuilder.DropForeignKey(
                name: "FK_IvStoreIssueTr_IvUnits_IvUnitId",
                table: "IvStoreIssueTr");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IvStoreIssueTr",
                table: "IvStoreIssueTr");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IvStoreIssueHd",
                table: "IvStoreIssueHd");

            migrationBuilder.RenameTable(
                name: "IvStoreIssueTr",
                newName: "IvStoreIssueTrs");

            migrationBuilder.RenameTable(
                name: "IvStoreIssueHd",
                newName: "IvStoreIssueHds");

            migrationBuilder.RenameIndex(
                name: "IX_IvStoreIssueTr_IvUnitId",
                table: "IvStoreIssueTrs",
                newName: "IX_IvStoreIssueTrs_IvUnitId");

            migrationBuilder.RenameIndex(
                name: "IX_IvStoreIssueTr_IvStoreIssueHdId",
                table: "IvStoreIssueTrs",
                newName: "IX_IvStoreIssueTrs_IvStoreIssueHdId");

            migrationBuilder.RenameIndex(
                name: "IX_IvStoreIssueTr_IvItemId",
                table: "IvStoreIssueTrs",
                newName: "IX_IvStoreIssueTrs_IvItemId");

            migrationBuilder.RenameIndex(
                name: "IX_IvStoreIssueHd_StatusLkpId",
                table: "IvStoreIssueHds",
                newName: "IX_IvStoreIssueHds_StatusLkpId");

            migrationBuilder.RenameIndex(
                name: "IX_IvStoreIssueHd_IvWarehouseId",
                table: "IvStoreIssueHds",
                newName: "IX_IvStoreIssueHds_IvWarehouseId");

            migrationBuilder.RenameIndex(
                name: "IX_IvStoreIssueHd_IssueTypeLkpId",
                table: "IvStoreIssueHds",
                newName: "IX_IvStoreIssueHds_IssueTypeLkpId");

            migrationBuilder.RenameIndex(
                name: "IX_IvStoreIssueHd_BeneficiaryTypeLkpId",
                table: "IvStoreIssueHds",
                newName: "IX_IvStoreIssueHds_BeneficiaryTypeLkpId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IvStoreIssueTrs",
                table: "IvStoreIssueTrs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IvStoreIssueHds",
                table: "IvStoreIssueHds",
                column: "Id");

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
                name: "FK_IvStoreIssueHds_IvWarehouses_IvWarehouseId",
                table: "IvStoreIssueHds",
                column: "IvWarehouseId",
                principalTable: "IvWarehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IvStoreIssueHds_FndLookupValues_StatusLkpId",
                table: "IvStoreIssueHds",
                column: "StatusLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IvStoreIssueTrs_IvItems_IvItemId",
                table: "IvStoreIssueTrs",
                column: "IvItemId",
                principalTable: "IvItems",
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
    }
}
