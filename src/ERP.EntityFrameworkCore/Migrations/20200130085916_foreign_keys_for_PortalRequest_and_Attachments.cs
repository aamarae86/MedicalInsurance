using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class foreign_keys_for_PortalRequest_and_Attachments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PortalRequestAttachments_ScFndProtalAttachmentSetting_GetScFndProtalAttachmentSettingId",
                table: "PortalRequestAttachments");

            migrationBuilder.DropForeignKey(
                name: "FK_PortalRequestAttachments_ScPortalRequests_ScPortalRequestId",
                table: "PortalRequestAttachments");

            migrationBuilder.DropIndex(
                name: "IX_PortalRequestAttachments_GetScFndProtalAttachmentSettingId",
                table: "PortalRequestAttachments");

            migrationBuilder.DropIndex(
                name: "IX_PortalRequestAttachments_ScPortalRequestId",
                table: "PortalRequestAttachments");

            migrationBuilder.DropColumn(
                name: "GetScFndProtalAttachmentSettingId",
                table: "PortalRequestAttachments");

            migrationBuilder.DropColumn(
                name: "ScPortalRequestId",
                table: "PortalRequestAttachments");

            migrationBuilder.CreateIndex(
                name: "IX_PortalRequestAttachments_PortalRequestId",
                table: "PortalRequestAttachments",
                column: "PortalRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_PortalRequestAttachments_ProtalAttachmentSettingId",
                table: "PortalRequestAttachments",
                column: "ProtalAttachmentSettingId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PortalRequestAttachments_ScPortalRequests_PortalRequestId",
                table: "PortalRequestAttachments");

            migrationBuilder.DropForeignKey(
                name: "FK_PortalRequestAttachments_ScFndProtalAttachmentSetting_ProtalAttachmentSettingId",
                table: "PortalRequestAttachments");

            migrationBuilder.DropIndex(
                name: "IX_PortalRequestAttachments_PortalRequestId",
                table: "PortalRequestAttachments");

            migrationBuilder.DropIndex(
                name: "IX_PortalRequestAttachments_ProtalAttachmentSettingId",
                table: "PortalRequestAttachments");

            migrationBuilder.AddColumn<long>(
                name: "GetScFndProtalAttachmentSettingId",
                table: "PortalRequestAttachments",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ScPortalRequestId",
                table: "PortalRequestAttachments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PortalRequestAttachments_GetScFndProtalAttachmentSettingId",
                table: "PortalRequestAttachments",
                column: "GetScFndProtalAttachmentSettingId");

            migrationBuilder.CreateIndex(
                name: "IX_PortalRequestAttachments_ScPortalRequestId",
                table: "PortalRequestAttachments",
                column: "ScPortalRequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_PortalRequestAttachments_ScFndProtalAttachmentSetting_GetScFndProtalAttachmentSettingId",
                table: "PortalRequestAttachments",
                column: "GetScFndProtalAttachmentSettingId",
                principalTable: "ScFndProtalAttachmentSetting",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PortalRequestAttachments_ScPortalRequests_ScPortalRequestId",
                table: "PortalRequestAttachments",
                column: "ScPortalRequestId",
                principalTable: "ScPortalRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
