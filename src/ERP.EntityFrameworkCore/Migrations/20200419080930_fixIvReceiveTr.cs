using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class fixIvReceiveTr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IvReceiveTr_PoPurchaseOrderTr_IvUnitId",
                table: "IvReceiveTr");

            migrationBuilder.CreateIndex(
                name: "IX_IvReceiveTr_PoPurchaseOrderTrId",
                table: "IvReceiveTr",
                column: "PoPurchaseOrderTrId");

            migrationBuilder.AddForeignKey(
                name: "FK_IvReceiveTr_PoPurchaseOrderTr_PoPurchaseOrderTrId",
                table: "IvReceiveTr",
                column: "PoPurchaseOrderTrId",
                principalTable: "PoPurchaseOrderTr",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IvReceiveTr_PoPurchaseOrderTr_PoPurchaseOrderTrId",
                table: "IvReceiveTr");

            migrationBuilder.DropIndex(
                name: "IX_IvReceiveTr_PoPurchaseOrderTrId",
                table: "IvReceiveTr");

            migrationBuilder.AddForeignKey(
                name: "FK_IvReceiveTr_PoPurchaseOrderTr_IvUnitId",
                table: "IvReceiveTr",
                column: "IvUnitId",
                principalTable: "PoPurchaseOrderTr",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
