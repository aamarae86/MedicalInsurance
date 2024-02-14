using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class renameRequestAttachmentsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PortalRequestAttachments_ScPortalRequests_PortalRequestId",
                table: "PortalRequestAttachments");

            migrationBuilder.DropForeignKey(
                name: "FK_PortalRequestAttachments_ScFndProtalAttachmentSetting_ProtalAttachmentSettingId",
                table: "PortalRequestAttachments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PortalRequestAttachments",
                table: "PortalRequestAttachments");

            migrationBuilder.RenameTable(
                name: "PortalRequestAttachments",
                newName: "ScPortalRequestAttachments");

            migrationBuilder.RenameIndex(
                name: "IX_PortalRequestAttachments_ProtalAttachmentSettingId",
                table: "ScPortalRequestAttachments",
                newName: "IX_ScPortalRequestAttachments_ProtalAttachmentSettingId");

            migrationBuilder.RenameIndex(
                name: "IX_PortalRequestAttachments_PortalRequestId",
                table: "ScPortalRequestAttachments",
                newName: "IX_ScPortalRequestAttachments_PortalRequestId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ScPortalRequestAttachments",
                table: "ScPortalRequestAttachments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ScPortalRequestAttachments_ScPortalRequests_PortalRequestId",
                table: "ScPortalRequestAttachments",
                column: "PortalRequestId",
                principalTable: "ScPortalRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ScPortalRequestAttachments_ScFndProtalAttachmentSetting_ProtalAttachmentSettingId",
                table: "ScPortalRequestAttachments",
                column: "ProtalAttachmentSettingId",
                principalTable: "ScFndProtalAttachmentSetting",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScPortalRequestAttachments_ScPortalRequests_PortalRequestId",
                table: "ScPortalRequestAttachments");

            migrationBuilder.DropForeignKey(
                name: "FK_ScPortalRequestAttachments_ScFndProtalAttachmentSetting_ProtalAttachmentSettingId",
                table: "ScPortalRequestAttachments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ScPortalRequestAttachments",
                table: "ScPortalRequestAttachments");

            migrationBuilder.RenameTable(
                name: "ScPortalRequestAttachments",
                newName: "PortalRequestAttachments");

            migrationBuilder.RenameIndex(
                name: "IX_ScPortalRequestAttachments_ProtalAttachmentSettingId",
                table: "PortalRequestAttachments",
                newName: "IX_PortalRequestAttachments_ProtalAttachmentSettingId");

            migrationBuilder.RenameIndex(
                name: "IX_ScPortalRequestAttachments_PortalRequestId",
                table: "PortalRequestAttachments",
                newName: "IX_PortalRequestAttachments_PortalRequestId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PortalRequestAttachments",
                table: "PortalRequestAttachments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PortalRequestAttachments_ScPortalRequests_PortalRequestId",
                table: "PortalRequestAttachments",
                column: "PortalRequestId",
                principalTable: "ScPortalRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PortalRequestAttachments_ScFndProtalAttachmentSetting_ProtalAttachmentSettingId",
                table: "PortalRequestAttachments",
                column: "ProtalAttachmentSettingId",
                principalTable: "ScFndProtalAttachmentSetting",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
