using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class PoPurchaseOrders_relations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_PoPurchaseOrderTr_IvItemId",
                table: "PoPurchaseOrderTr",
                column: "IvItemId");

            migrationBuilder.CreateIndex(
                name: "IX_PoPurchaseOrderHd_IvWarehouseId",
                table: "PoPurchaseOrderHd",
                column: "IvWarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_PoPurchaseOrderHd_StatusLkpId",
                table: "PoPurchaseOrderHd",
                column: "StatusLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_PoPurchaseOrderHd_VendorId",
                table: "PoPurchaseOrderHd",
                column: "VendorId");

            migrationBuilder.AddForeignKey(
                name: "FK_PoPurchaseOrderHd_IvWarehouses_IvWarehouseId",
                table: "PoPurchaseOrderHd",
                column: "IvWarehouseId",
                principalTable: "IvWarehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PoPurchaseOrderHd_FndLookupValues_StatusLkpId",
                table: "PoPurchaseOrderHd",
                column: "StatusLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PoPurchaseOrderHd_ApVendors_VendorId",
                table: "PoPurchaseOrderHd",
                column: "VendorId",
                principalTable: "ApVendors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PoPurchaseOrderTr_IvItems_IvItemId",
                table: "PoPurchaseOrderTr",
                column: "IvItemId",
                principalTable: "IvItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PoPurchaseOrderHd_IvWarehouses_IvWarehouseId",
                table: "PoPurchaseOrderHd");

            migrationBuilder.DropForeignKey(
                name: "FK_PoPurchaseOrderHd_FndLookupValues_StatusLkpId",
                table: "PoPurchaseOrderHd");

            migrationBuilder.DropForeignKey(
                name: "FK_PoPurchaseOrderHd_ApVendors_VendorId",
                table: "PoPurchaseOrderHd");

            migrationBuilder.DropForeignKey(
                name: "FK_PoPurchaseOrderTr_IvItems_IvItemId",
                table: "PoPurchaseOrderTr");

            migrationBuilder.DropIndex(
                name: "IX_PoPurchaseOrderTr_IvItemId",
                table: "PoPurchaseOrderTr");

            migrationBuilder.DropIndex(
                name: "IX_PoPurchaseOrderHd_IvWarehouseId",
                table: "PoPurchaseOrderHd");

            migrationBuilder.DropIndex(
                name: "IX_PoPurchaseOrderHd_StatusLkpId",
                table: "PoPurchaseOrderHd");

            migrationBuilder.DropIndex(
                name: "IX_PoPurchaseOrderHd_VendorId",
                table: "PoPurchaseOrderHd");
        }
    }
}
