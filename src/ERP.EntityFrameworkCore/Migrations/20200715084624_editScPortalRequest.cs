using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class editScPortalRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScPortalRequests_PortalUserData_PortalUserDataId",
                table: "ScPortalRequests");

            migrationBuilder.AlterColumn<long>(
                name: "PortalUserDataId",
                table: "ScPortalRequests",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddColumn<long>(
                name: "PortalUserId",
                table: "ScPortalRequests",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_ScPortalRequests_PortalUserId",
                table: "ScPortalRequests",
                column: "PortalUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ScPortalRequests_PortalUserData_PortalUserDataId",
                table: "ScPortalRequests",
                column: "PortalUserDataId",
                principalTable: "PortalUserData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ScPortalRequests_PortalUsers_PortalUserId",
                table: "ScPortalRequests",
                column: "PortalUserId",
                principalTable: "PortalUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScPortalRequests_PortalUserData_PortalUserDataId",
                table: "ScPortalRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_ScPortalRequests_PortalUsers_PortalUserId",
                table: "ScPortalRequests");

            migrationBuilder.DropIndex(
                name: "IX_ScPortalRequests_PortalUserId",
                table: "ScPortalRequests");

            migrationBuilder.DropColumn(
                name: "PortalUserId",
                table: "ScPortalRequests");

            migrationBuilder.AlterColumn<long>(
                name: "PortalUserDataId",
                table: "ScPortalRequests",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ScPortalRequests_PortalUserData_PortalUserDataId",
                table: "ScPortalRequests",
                column: "PortalUserDataId",
                principalTable: "PortalUserData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
