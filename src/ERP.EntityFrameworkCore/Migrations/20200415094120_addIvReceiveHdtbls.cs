using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class addIvReceiveHdtbls : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IvReceiveHd",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    HdReceiveNumber = table.Column<string>(maxLength: 30, nullable: false),
                    HdReceiveDate = table.Column<DateTime>(nullable: false),
                    CurrencyRate = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    Comment = table.Column<string>(maxLength: 4000, nullable: true),
                    IvWarehouseId = table.Column<long>(nullable: false),
                    StatusLkpId = table.Column<long>(nullable: false),
                    CurrencyId = table.Column<int>(nullable: false),
                    VendorId = table.Column<long>(nullable: false),
                    ReceiveTypeLkpId = table.Column<long>(nullable: false),
                    PoPurchaseOrderHdId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IvReceiveHd", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IvReceiveHd_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IvReceiveHd_IvWarehouses_IvWarehouseId",
                        column: x => x.IvWarehouseId,
                        principalTable: "IvWarehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IvReceiveHd_PoPurchaseOrderHd_PoPurchaseOrderHdId",
                        column: x => x.PoPurchaseOrderHdId,
                        principalTable: "PoPurchaseOrderHd",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IvReceiveHd_FndLookupValues_ReceiveTypeLkpId",
                        column: x => x.ReceiveTypeLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_IvReceiveHd_FndLookupValues_StatusLkpId",
                        column: x => x.StatusLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_IvReceiveHd_ApVendors_VendorId",
                        column: x => x.VendorId,
                        principalTable: "ApVendors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "IvReceiveTr",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IvReceiveHdId = table.Column<long>(nullable: false),
                    IvItemId = table.Column<long>(nullable: false),
                    IvUnitId = table.Column<long>(nullable: false),
                    PoPurchaseOrderTrId = table.Column<long>(nullable: true),
                    Qty = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    TaxAmount = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IvReceiveTr", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IvReceiveTr_IvItems_IvItemId",
                        column: x => x.IvItemId,
                        principalTable: "IvItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IvReceiveTr_IvReceiveHd_IvReceiveHdId",
                        column: x => x.IvReceiveHdId,
                        principalTable: "IvReceiveHd",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IvReceiveTr_IvUnits_IvUnitId",
                        column: x => x.IvUnitId,
                        principalTable: "IvUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IvReceiveTr_PoPurchaseOrderTr_IvUnitId",
                        column: x => x.IvUnitId,
                        principalTable: "PoPurchaseOrderTr",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IvReceiveHd_CurrencyId",
                table: "IvReceiveHd",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_IvReceiveHd_IvWarehouseId",
                table: "IvReceiveHd",
                column: "IvWarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_IvReceiveHd_PoPurchaseOrderHdId",
                table: "IvReceiveHd",
                column: "PoPurchaseOrderHdId");

            migrationBuilder.CreateIndex(
                name: "IX_IvReceiveHd_ReceiveTypeLkpId",
                table: "IvReceiveHd",
                column: "ReceiveTypeLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_IvReceiveHd_StatusLkpId",
                table: "IvReceiveHd",
                column: "StatusLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_IvReceiveHd_VendorId",
                table: "IvReceiveHd",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_IvReceiveTr_IvItemId",
                table: "IvReceiveTr",
                column: "IvItemId");

            migrationBuilder.CreateIndex(
                name: "IX_IvReceiveTr_IvReceiveHdId",
                table: "IvReceiveTr",
                column: "IvReceiveHdId");

            migrationBuilder.CreateIndex(
                name: "IX_IvReceiveTr_IvUnitId",
                table: "IvReceiveTr",
                column: "IvUnitId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IvReceiveTr");

            migrationBuilder.DropTable(
                name: "IvReceiveHd");
        }
    }
}
