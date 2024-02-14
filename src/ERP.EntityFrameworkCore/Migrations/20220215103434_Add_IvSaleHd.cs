using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class Add_IvSaleHd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IvSaleHd",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IvSaleNumber = table.Column<string>(maxLength: 30, nullable: false),
                    StatusLkpId = table.Column<long>(nullable: false),
                    IvSaleDate = table.Column<DateTime>(nullable: false),
                    LpoNo = table.Column<string>(maxLength: 30, nullable: true),
                    IvPriceListHdId = table.Column<long>(nullable: false),
                    Comments = table.Column<string>(maxLength: 4000, nullable: true),
                    IvWarehouseId = table.Column<long>(nullable: false),
                    CurrencyId = table.Column<int>(nullable: false),
                    CurrencyRate = table.Column<decimal>(type: "decimal(18, 6)", nullable: false),
                    FndSalesMenId = table.Column<long>(nullable: true),
                    IsCash = table.Column<bool>(nullable: false),
                    ArCustomerId = table.Column<long>(nullable: false),
                    DiscAmount = table.Column<decimal>(type: "decimal(18, 6)", nullable: true),
                    DiscPercentage = table.Column<decimal>(type: "decimal(18, 6)", nullable: true),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IvSaleHd", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IvSaleHd_ArCustomers_ArCustomerId",
                        column: x => x.ArCustomerId,
                        principalTable: "ArCustomers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IvSaleHd_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IvSaleHd_FndSalesMen_FndSalesMenId",
                        column: x => x.FndSalesMenId,
                        principalTable: "FndSalesMen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IvSaleHd_IvPriceListHd_IvPriceListHdId",
                        column: x => x.IvPriceListHdId,
                        principalTable: "IvPriceListHd",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IvSaleHd_IvWarehouses_IvWarehouseId",
                        column: x => x.IvWarehouseId,
                        principalTable: "IvWarehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IvSaleHd_FndLookupValues_StatusLkpId",
                        column: x => x.StatusLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "IvSaleTr",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IvSaleHdId = table.Column<long>(nullable: false),
                    IvItemId = table.Column<long>(nullable: false),
                    Qty = table.Column<decimal>(type: "decimal(18, 6)", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18, 6)", nullable: false),
                    TrCost = table.Column<decimal>(type: "decimal(18, 6)", nullable: false),
                    TaxAmount = table.Column<decimal>(type: "decimal(18, 6)", nullable: true),
                    TaxPercentageLkpId = table.Column<long>(nullable: true),
                    DiscAmount = table.Column<decimal>(type: "decimal(18, 6)", nullable: true),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IvSaleTr", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IvSaleTr_IvItems_IvItemId",
                        column: x => x.IvItemId,
                        principalTable: "IvItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IvSaleTr_IvSaleHd_IvSaleHdId",
                        column: x => x.IvSaleHdId,
                        principalTable: "IvSaleHd",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IvSaleTr_FndLookupValues_TaxPercentageLkpId",
                        column: x => x.TaxPercentageLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IvSaleHd_ArCustomerId",
                table: "IvSaleHd",
                column: "ArCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_IvSaleHd_CurrencyId",
                table: "IvSaleHd",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_IvSaleHd_FndSalesMenId",
                table: "IvSaleHd",
                column: "FndSalesMenId");

            migrationBuilder.CreateIndex(
                name: "IX_IvSaleHd_IvPriceListHdId",
                table: "IvSaleHd",
                column: "IvPriceListHdId");

            migrationBuilder.CreateIndex(
                name: "IX_IvSaleHd_IvWarehouseId",
                table: "IvSaleHd",
                column: "IvWarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_IvSaleHd_StatusLkpId",
                table: "IvSaleHd",
                column: "StatusLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_IvSaleTr_IvItemId",
                table: "IvSaleTr",
                column: "IvItemId");

            migrationBuilder.CreateIndex(
                name: "IX_IvSaleTr_IvSaleHdId",
                table: "IvSaleTr",
                column: "IvSaleHdId");

            migrationBuilder.CreateIndex(
                name: "IX_IvSaleTr_TaxPercentageLkpId",
                table: "IvSaleTr",
                column: "TaxPercentageLkpId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IvSaleTr");

            migrationBuilder.DropTable(
                name: "IvSaleHd");
        }
    }
}
