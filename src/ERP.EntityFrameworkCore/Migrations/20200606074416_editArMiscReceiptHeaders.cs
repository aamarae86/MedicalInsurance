using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class editArMiscReceiptHeaders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ReceiptTypeLkpId",
                table: "ArMiscReceiptHeaders",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ArMiscReceiptHeaders_ReceiptTypeLkpId",
                table: "ArMiscReceiptHeaders",
                column: "ReceiptTypeLkpId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArMiscReceiptHeaders_FndLookupValues_ReceiptTypeLkpId",
                table: "ArMiscReceiptHeaders",
                column: "ReceiptTypeLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArMiscReceiptHeaders_FndLookupValues_ReceiptTypeLkpId",
                table: "ArMiscReceiptHeaders");

            migrationBuilder.DropIndex(
                name: "IX_ArMiscReceiptHeaders_ReceiptTypeLkpId",
                table: "ArMiscReceiptHeaders");

            migrationBuilder.DropColumn(
                name: "ReceiptTypeLkpId",
                table: "ArMiscReceiptHeaders");
        }
    }
}
