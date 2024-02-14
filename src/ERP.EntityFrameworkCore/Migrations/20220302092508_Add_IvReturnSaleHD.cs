using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class Add_IvReturnSaleHD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IvReturnSaleHd",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    PostUserId = table.Column<long>(nullable: true),
                    PostTime = table.Column<DateTime>(nullable: true),
                    UnPostUserId = table.Column<long>(nullable: true),
                    UnPostTime = table.Column<DateTime>(nullable: true),
                    IvSaleHdId = table.Column<long>(nullable: false),
                    IvReturnSaleNumber = table.Column<string>(maxLength: 30, nullable: false),
                    StatusLkpId = table.Column<long>(nullable: false),
                    IvReturnSaleDate = table.Column<DateTime>(nullable: false),
                    Comments = table.Column<string>(maxLength: 4000, nullable: true),
                    CurrencyId = table.Column<int>(nullable: false),
                    CurrencyRate = table.Column<decimal>(type: "decimal(18, 6)", nullable: false),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IvReturnSaleHd", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IvReturnSaleHd_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IvReturnSaleHd_IvSaleHd_IvSaleHdId",
                        column: x => x.IvSaleHdId,
                        principalTable: "IvSaleHd",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_IvReturnSaleHd_FndLookupValues_StatusLkpId",
                        column: x => x.StatusLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IvReturnSaleTr",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IvReturnSaleHdId = table.Column<long>(nullable: false),
                    RQty = table.Column<decimal>(type: "decimal(18, 6)", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18, 6)", nullable: false),
                    TrCost = table.Column<decimal>(type: "decimal(18, 6)", nullable: false),
                    TaxAmount = table.Column<decimal>(type: "decimal(18, 6)", nullable: true),
                    TaxPercentageLkpId = table.Column<long>(nullable: false),
                    IvSaleTrId = table.Column<long>(nullable: false),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IvReturnSaleTr", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IvReturnSaleTr_IvReturnSaleHd_IvReturnSaleHdId",
                        column: x => x.IvReturnSaleHdId,
                        principalTable: "IvReturnSaleHd",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IvReturnSaleTr_IvSaleTr_IvSaleTrId",
                        column: x => x.IvSaleTrId,
                        principalTable: "IvSaleTr",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_IvReturnSaleTr_FndLookupValues_TaxPercentageLkpId",
                        column: x => x.TaxPercentageLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IvReturnSaleHd_CurrencyId",
                table: "IvReturnSaleHd",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_IvReturnSaleHd_IvSaleHdId",
                table: "IvReturnSaleHd",
                column: "IvSaleHdId");

            migrationBuilder.CreateIndex(
                name: "IX_IvReturnSaleHd_StatusLkpId",
                table: "IvReturnSaleHd",
                column: "StatusLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_IvReturnSaleTr_IvReturnSaleHdId",
                table: "IvReturnSaleTr",
                column: "IvReturnSaleHdId");

            migrationBuilder.CreateIndex(
                name: "IX_IvReturnSaleTr_IvSaleTrId",
                table: "IvReturnSaleTr",
                column: "IvSaleTrId");

            migrationBuilder.CreateIndex(
                name: "IX_IvReturnSaleTr_TaxPercentageLkpId",
                table: "IvReturnSaleTr",
                column: "TaxPercentageLkpId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IvReturnSaleTr");

            migrationBuilder.DropTable(
                name: "IvReturnSaleHd");
        }
    }
}
