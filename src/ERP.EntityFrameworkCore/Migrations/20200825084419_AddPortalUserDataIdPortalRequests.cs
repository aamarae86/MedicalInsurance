using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class AddPortalUserDataIdPortalRequests : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScPortalRequests_PortalUserData_PortalUserDataId",
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
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScPortalRequests_PortalUserData_PortalUserDataId",
                table: "ScPortalRequests");

            migrationBuilder.AlterColumn<long>(
                name: "PortalUserDataId",
                table: "ScPortalRequests",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddForeignKey(
                name: "FK_ScPortalRequests_PortalUserData_PortalUserDataId",
                table: "ScPortalRequests",
                column: "PortalUserDataId",
                principalTable: "PortalUserData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
