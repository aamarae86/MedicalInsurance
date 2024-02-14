using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class add_relationMiscHeader_detail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ArMiscReceiptDetails_MiscReceiptId",
                table: "ArMiscReceiptDetails",
                column: "MiscReceiptId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArMiscReceiptDetails_ArMiscReceiptHeaders_MiscReceiptId",
                table: "ArMiscReceiptDetails",
                column: "MiscReceiptId",
                principalTable: "ArMiscReceiptHeaders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArMiscReceiptDetails_ArMiscReceiptHeaders_MiscReceiptId",
                table: "ArMiscReceiptDetails");

            migrationBuilder.DropIndex(
                name: "IX_ArMiscReceiptDetails_MiscReceiptId",
                table: "ArMiscReceiptDetails");
        }
    }
}
