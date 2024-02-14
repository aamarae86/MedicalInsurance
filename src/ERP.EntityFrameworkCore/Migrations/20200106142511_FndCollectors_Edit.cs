using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class FndCollectors_Edit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ArMiscReceiptHeaders_CollectorId",
                table: "ArMiscReceiptHeaders",
                column: "CollectorId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArMiscReceiptHeaders_FndCollectors_CollectorId",
                table: "ArMiscReceiptHeaders",
                column: "CollectorId",
                principalTable: "FndCollectors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArMiscReceiptHeaders_FndCollectors_CollectorId",
                table: "ArMiscReceiptHeaders");

            migrationBuilder.DropIndex(
                name: "IX_ArMiscReceiptHeaders_CollectorId",
                table: "ArMiscReceiptHeaders");
        }
    }
}
