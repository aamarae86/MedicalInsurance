using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class editArMiscReceiptLines : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "SpContractDetailsId",
                table: "ArMiscReceiptLines",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ArMiscReceiptLines_SpContractDetailsId",
                table: "ArMiscReceiptLines",
                column: "SpContractDetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArMiscReceiptLines_SpContractDetails_SpContractDetailsId",
                table: "ArMiscReceiptLines",
                column: "SpContractDetailsId",
                principalTable: "SpContractDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArMiscReceiptLines_SpContractDetails_SpContractDetailsId",
                table: "ArMiscReceiptLines");

            migrationBuilder.DropIndex(
                name: "IX_ArMiscReceiptLines_SpContractDetailsId",
                table: "ArMiscReceiptLines");

            migrationBuilder.DropColumn(
                name: "SpContractDetailsId",
                table: "ArMiscReceiptLines");
        }
    }
}
