using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class addNewColumnArMiscReceiptLines : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "PortalUsersId",
                table: "ArMiscReceiptLines",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ArMiscReceiptLines_PortalUsersId",
                table: "ArMiscReceiptLines",
                column: "PortalUsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArMiscReceiptLines_PortalUsers_PortalUsersId",
                table: "ArMiscReceiptLines",
                column: "PortalUsersId",
                principalTable: "PortalUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArMiscReceiptLines_PortalUsers_PortalUsersId",
                table: "ArMiscReceiptLines");

            migrationBuilder.DropIndex(
                name: "IX_ArMiscReceiptLines_PortalUsersId",
                table: "ArMiscReceiptLines");

            migrationBuilder.DropColumn(
                name: "PortalUsersId",
                table: "ArMiscReceiptLines");
        }
    }
}
