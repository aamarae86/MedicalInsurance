using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class editScPortalRequest0000 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScPortalRequests_PortalUsers_PortalUserId",
                table: "ScPortalRequests");

            migrationBuilder.RenameColumn(
                name: "PortalUserId",
                table: "ScPortalRequests",
                newName: "PortalUsersId");

            migrationBuilder.RenameIndex(
                name: "IX_ScPortalRequests_PortalUserId",
                table: "ScPortalRequests",
                newName: "IX_ScPortalRequests_PortalUsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_ScPortalRequests_PortalUsers_PortalUsersId",
                table: "ScPortalRequests",
                column: "PortalUsersId",
                principalTable: "PortalUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScPortalRequests_PortalUsers_PortalUsersId",
                table: "ScPortalRequests");

            migrationBuilder.RenameColumn(
                name: "PortalUsersId",
                table: "ScPortalRequests",
                newName: "PortalUserId");

            migrationBuilder.RenameIndex(
                name: "IX_ScPortalRequests_PortalUsersId",
                table: "ScPortalRequests",
                newName: "IX_ScPortalRequests_PortalUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ScPortalRequests_PortalUsers_PortalUserId",
                table: "ScPortalRequests",
                column: "PortalUserId",
                principalTable: "PortalUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
