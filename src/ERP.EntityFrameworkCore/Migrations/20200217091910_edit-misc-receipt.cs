using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class editmiscreceipt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "AdminAccountID",
                table: "ArMiscReceiptLines",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ArMiscReceiptLines_AdminAccountID",
                table: "ArMiscReceiptLines",
                column: "AdminAccountID");

            migrationBuilder.AddForeignKey(
                name: "FK_ArMiscReceiptLines_GlCodeComDetails_AdminAccountID",
                table: "ArMiscReceiptLines",
                column: "AdminAccountID",
                principalTable: "GlCodeComDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArMiscReceiptLines_GlCodeComDetails_AdminAccountID",
                table: "ArMiscReceiptLines");

            migrationBuilder.DropIndex(
                name: "IX_ArMiscReceiptLines_AdminAccountID",
                table: "ArMiscReceiptLines");

            migrationBuilder.DropColumn(
                name: "AdminAccountID",
                table: "ArMiscReceiptLines");
        }
    }
}
