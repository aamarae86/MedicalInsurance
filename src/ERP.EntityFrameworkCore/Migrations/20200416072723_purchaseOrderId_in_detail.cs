using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class purchaseOrderId_in_detail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PoPurchaseOrderTr_PoPurchaseOrderHd_PoPurchaseOrderHdId",
                table: "PoPurchaseOrderTr");

            migrationBuilder.DropIndex(
                name: "IX_PoPurchaseOrderTr_PoPurchaseOrderHdId",
                table: "PoPurchaseOrderTr");

            migrationBuilder.DropColumn(
                name: "PoPurchaseOrderHdId",
                table: "PoPurchaseOrderTr");

            migrationBuilder.AddColumn<long>(
                name: "PoPurchaseOrderId",
                table: "PoPurchaseOrderTr",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_PoPurchaseOrderTr_PoPurchaseOrderId",
                table: "PoPurchaseOrderTr",
                column: "PoPurchaseOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_PoPurchaseOrderTr_PoPurchaseOrderHd_PoPurchaseOrderId",
                table: "PoPurchaseOrderTr",
                column: "PoPurchaseOrderId",
                principalTable: "PoPurchaseOrderHd",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PoPurchaseOrderTr_PoPurchaseOrderHd_PoPurchaseOrderId",
                table: "PoPurchaseOrderTr");

            migrationBuilder.DropIndex(
                name: "IX_PoPurchaseOrderTr_PoPurchaseOrderId",
                table: "PoPurchaseOrderTr");

            migrationBuilder.DropColumn(
                name: "PoPurchaseOrderId",
                table: "PoPurchaseOrderTr");

            migrationBuilder.AddColumn<long>(
                name: "PoPurchaseOrderHdId",
                table: "PoPurchaseOrderTr",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PoPurchaseOrderTr_PoPurchaseOrderHdId",
                table: "PoPurchaseOrderTr",
                column: "PoPurchaseOrderHdId");

            migrationBuilder.AddForeignKey(
                name: "FK_PoPurchaseOrderTr_PoPurchaseOrderHd_PoPurchaseOrderHdId",
                table: "PoPurchaseOrderTr",
                column: "PoPurchaseOrderHdId",
                principalTable: "PoPurchaseOrderHd",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
