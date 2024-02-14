using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class ApMiscPaymentLinesFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<long>(
                name: "PortalUsersId",
                table: "ApMiscPaymentLines",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApMiscPaymentLines_PortalUsersId",
                table: "ApMiscPaymentLines",
                column: "PortalUsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApMiscPaymentLines_PortalUsers_PortalUsersId",
                table: "ApMiscPaymentLines",
                column: "PortalUsersId",
                principalTable: "PortalUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApMiscPaymentLines_PortalUsers_PortalUsersId",
                table: "ApMiscPaymentLines");

            migrationBuilder.DropIndex(
                name: "IX_ApMiscPaymentLines_PortalUsersId",
                table: "ApMiscPaymentLines");

            migrationBuilder.DropColumn(
                name: "PortalUsersId",
                table: "ApMiscPaymentLines");

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
    }
}
