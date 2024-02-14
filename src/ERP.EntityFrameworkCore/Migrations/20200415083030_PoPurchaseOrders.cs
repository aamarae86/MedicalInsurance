using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class PoPurchaseOrders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PoPurchaseOrderHd",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: false),
                    PurchaseOrderNumber = table.Column<string>(maxLength: 20, nullable: true),
                    PurchaseOrderDate = table.Column<DateTime>(nullable: false),
                    StatusLkpId = table.Column<long>(nullable: false),
                    VendorId = table.Column<long>(nullable: false),
                    IvWarehouseId = table.Column<long>(nullable: false),
                    ConditionsForOrdering = table.Column<string>(maxLength: 4000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoPurchaseOrderHd", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PoPurchaseOrderTr",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: false),
                    IvItemId = table.Column<long>(nullable: false),
                    QtyOrdered = table.Column<decimal>(type: "decimal(18, 6)", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18, 6)", nullable: false),
                    ReceivedQty = table.Column<decimal>(type: "decimal(18, 6)", nullable: true),
                    ReceivedDate = table.Column<DateTime>(nullable: true),
                    PoPurchaseOrderHdId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoPurchaseOrderTr", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PoPurchaseOrderTr_PoPurchaseOrderHd_PoPurchaseOrderHdId",
                        column: x => x.PoPurchaseOrderHdId,
                        principalTable: "PoPurchaseOrderHd",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PoPurchaseOrderTr_PoPurchaseOrderHdId",
                table: "PoPurchaseOrderTr",
                column: "PoPurchaseOrderHdId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PoPurchaseOrderTr");

            migrationBuilder.DropTable(
                name: "PoPurchaseOrderHd");
        }
    }
}
