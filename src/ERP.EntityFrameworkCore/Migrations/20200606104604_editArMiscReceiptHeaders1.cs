using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class editArMiscReceiptHeaders1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArMiscReceiptHeaders_FndLookupValues_ReceiptTypeLkpId",
                table: "ArMiscReceiptHeaders");

            migrationBuilder.AlterColumn<long>(
                name: "ReceiptTypeLkpId",
                table: "ArMiscReceiptHeaders",
                nullable: true,
                oldClrType: typeof(long));

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

            migrationBuilder.AlterColumn<long>(
                name: "ReceiptTypeLkpId",
                table: "ArMiscReceiptHeaders",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ArMiscReceiptHeaders_FndLookupValues_ReceiptTypeLkpId",
                table: "ArMiscReceiptHeaders",
                column: "ReceiptTypeLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
