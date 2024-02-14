using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class ArReceiptDetailBankIdRequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArReceiptDetails_FndLookupValues_BankLkpId",
                table: "ArReceiptDetails");

            migrationBuilder.AlterColumn<long>(
                name: "BankLkpId",
                table: "ArReceiptDetails",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ArReceiptDetails_FndLookupValues_BankLkpId",
                table: "ArReceiptDetails",
                column: "BankLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArReceiptDetails_FndLookupValues_BankLkpId",
                table: "ArReceiptDetails");

            migrationBuilder.AlterColumn<long>(
                name: "BankLkpId",
                table: "ArReceiptDetails",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddForeignKey(
                name: "FK_ArReceiptDetails_FndLookupValues_BankLkpId",
                table: "ArReceiptDetails",
                column: "BankLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
