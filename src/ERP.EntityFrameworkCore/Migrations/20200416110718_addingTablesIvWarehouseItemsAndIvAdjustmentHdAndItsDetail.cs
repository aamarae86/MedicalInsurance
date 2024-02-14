using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class addingTablesIvWarehouseItemsAndIvAdjustmentHdAndItsDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IvAdjustmentHd",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    AdjustmentNumber = table.Column<string>(maxLength: 30, nullable: true),
                    AdjustmentDate = table.Column<DateTime>(nullable: true),
                    StatusLkpId = table.Column<long>(nullable: true),
                    AdjustmentTypeLkpId = table.Column<long>(nullable: true),
                    IvWarehouseId = table.Column<long>(nullable: true),
                    Notes = table.Column<string>(maxLength: 4000, nullable: true),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IvAdjustmentHd", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IvAdjustmentHd_FndLookupValues_AdjustmentTypeLkpId",
                        column: x => x.AdjustmentTypeLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IvAdjustmentHd_IvWarehouses_IvWarehouseId",
                        column: x => x.IvWarehouseId,
                        principalTable: "IvWarehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IvAdjustmentHd_FndLookupValues_StatusLkpId",
                        column: x => x.StatusLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IvWarehouseItems",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IvItemId = table.Column<long>(nullable: true),
                    IvWarehouseId = table.Column<long>(nullable: true),
                    CurrentOnHand = table.Column<decimal>(type: "decimal(18, 6)", nullable: true),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IvWarehouseItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IvWarehouseItems_IvItems_IvItemId",
                        column: x => x.IvItemId,
                        principalTable: "IvItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IvWarehouseItems_IvWarehouses_IvWarehouseId",
                        column: x => x.IvWarehouseId,
                        principalTable: "IvWarehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IvAdjustmentTr",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IvAdjustmentHdId = table.Column<long>(nullable: true),
                    IvItemId = table.Column<long>(nullable: true),
                    CurrentQty = table.Column<decimal>(type: "decimal(18, 6)", nullable: true),
                    Qty = table.Column<decimal>(type: "decimal(18, 6)", nullable: true),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IvAdjustmentTr", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IvAdjustmentTr_IvAdjustmentHd_IvAdjustmentHdId",
                        column: x => x.IvAdjustmentHdId,
                        principalTable: "IvAdjustmentHd",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IvAdjustmentTr_IvItems_IvItemId",
                        column: x => x.IvItemId,
                        principalTable: "IvItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IvAdjustmentHd_AdjustmentTypeLkpId",
                table: "IvAdjustmentHd",
                column: "AdjustmentTypeLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_IvAdjustmentHd_IvWarehouseId",
                table: "IvAdjustmentHd",
                column: "IvWarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_IvAdjustmentHd_StatusLkpId",
                table: "IvAdjustmentHd",
                column: "StatusLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_IvAdjustmentTr_IvAdjustmentHdId",
                table: "IvAdjustmentTr",
                column: "IvAdjustmentHdId");

            migrationBuilder.CreateIndex(
                name: "IX_IvAdjustmentTr_IvItemId",
                table: "IvAdjustmentTr",
                column: "IvItemId");

            migrationBuilder.CreateIndex(
                name: "IX_IvWarehouseItems_IvItemId",
                table: "IvWarehouseItems",
                column: "IvItemId");

            migrationBuilder.CreateIndex(
                name: "IX_IvWarehouseItems_IvWarehouseId",
                table: "IvWarehouseItems",
                column: "IvWarehouseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IvAdjustmentTr");

            migrationBuilder.DropTable(
                name: "IvWarehouseItems");

            migrationBuilder.DropTable(
                name: "IvAdjustmentHd");
        }
    }
}
