using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class editPortalRequestStudy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScPortalRequestStudy_ScPortalRequests_PortalRequestId",
                table: "ScPortalRequestStudy");

            migrationBuilder.AlterColumn<long>(
                name: "PortalRequestId",
                table: "ScPortalRequestStudy",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ScPortalRequestStudy_ScPortalRequests_PortalRequestId",
                table: "ScPortalRequestStudy",
                column: "PortalRequestId",
                principalTable: "ScPortalRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScPortalRequestStudy_ScPortalRequests_PortalRequestId",
                table: "ScPortalRequestStudy");

            migrationBuilder.AlterColumn<long>(
                name: "PortalRequestId",
                table: "ScPortalRequestStudy",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddForeignKey(
                name: "FK_ScPortalRequestStudy_ScPortalRequests_PortalRequestId",
                table: "ScPortalRequestStudy",
                column: "PortalRequestId",
                principalTable: "ScPortalRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
