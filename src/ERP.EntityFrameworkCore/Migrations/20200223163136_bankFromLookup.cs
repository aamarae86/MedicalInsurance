using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class bankFromLookup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArReceiptDetails_ApBanks_BankLkpId",
                table: "ArReceiptDetails");

            migrationBuilder.AddForeignKey(
                name: "FK_ArReceiptDetails_FndLookupValues_BankLkpId",
                table: "ArReceiptDetails",
                column: "BankLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArReceiptDetails_FndLookupValues_BankLkpId",
                table: "ArReceiptDetails");

            migrationBuilder.AddForeignKey(
                name: "FK_ArReceiptDetails_ApBanks_BankLkpId",
                table: "ArReceiptDetails",
                column: "BankLkpId",
                principalTable: "ApBanks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
