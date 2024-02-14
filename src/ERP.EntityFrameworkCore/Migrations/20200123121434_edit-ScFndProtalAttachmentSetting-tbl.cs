using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class editScFndProtalAttachmentSettingtbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScFndProtalAttachmentSetting_ScFndPortalIntervalSetting_RequestTypeId",
                table: "ScFndProtalAttachmentSetting");

            migrationBuilder.AddForeignKey(
                name: "FK_ScFndProtalAttachmentSetting_ScFndAidRequestType_RequestTypeId",
                table: "ScFndProtalAttachmentSetting",
                column: "RequestTypeId",
                principalTable: "ScFndAidRequestType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScFndProtalAttachmentSetting_ScFndAidRequestType_RequestTypeId",
                table: "ScFndProtalAttachmentSetting");

            migrationBuilder.AddForeignKey(
                name: "FK_ScFndProtalAttachmentSetting_ScFndPortalIntervalSetting_RequestTypeId",
                table: "ScFndProtalAttachmentSetting",
                column: "RequestTypeId",
                principalTable: "ScFndPortalIntervalSetting",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
