using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class ApInvoiceHdtbls : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApInvoiceHd",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    HdInvNo = table.Column<string>(maxLength: 30, nullable: false),
                    HdDate = table.Column<DateTime>(nullable: false),
                    CurrencyRate = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    PrepaidAmount = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    Comments = table.Column<string>(maxLength: 4000, nullable: true),
                    PrepaidPeriod = table.Column<int>(nullable: true),
                    StatusLkpId = table.Column<long>(nullable: false),
                    HdTypeLkpId = table.Column<long>(nullable: false),
                    VendorId = table.Column<long>(nullable: false),
                    CurrencyId = table.Column<int>(nullable: false),
                    FromAccountId = table.Column<long>(nullable: true),
                    ToAccountId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApInvoiceHd", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApInvoiceHd_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApInvoiceHd_GlCodeComDetails_FromAccountId",
                        column: x => x.FromAccountId,
                        principalTable: "GlCodeComDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApInvoiceHd_FndLookupValues_HdTypeLkpId",
                        column: x => x.HdTypeLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApInvoiceHd_FndLookupValues_StatusLkpId",
                        column: x => x.StatusLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ApInvoiceHd_GlCodeComDetails_ToAccountId",
                        column: x => x.ToAccountId,
                        principalTable: "GlCodeComDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApInvoiceHd_ApVendors_VendorId",
                        column: x => x.VendorId,
                        principalTable: "ApVendors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ApInvoiceTr",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    Desc = table.Column<string>(maxLength: 4000, nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    TaxAmount = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    ApInvoiceHdId = table.Column<long>(nullable: false),
                    AccountId = table.Column<long>(nullable: false),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApInvoiceTr", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApInvoiceTr_GlCodeComDetails_AccountId",
                        column: x => x.AccountId,
                        principalTable: "GlCodeComDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApInvoiceTr_ApInvoiceHd_ApInvoiceHdId",
                        column: x => x.ApInvoiceHdId,
                        principalTable: "ApInvoiceHd",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApInvoiceHd_CurrencyId",
                table: "ApInvoiceHd",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_ApInvoiceHd_FromAccountId",
                table: "ApInvoiceHd",
                column: "FromAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_ApInvoiceHd_HdTypeLkpId",
                table: "ApInvoiceHd",
                column: "HdTypeLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_ApInvoiceHd_StatusLkpId",
                table: "ApInvoiceHd",
                column: "StatusLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_ApInvoiceHd_ToAccountId",
                table: "ApInvoiceHd",
                column: "ToAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_ApInvoiceHd_VendorId",
                table: "ApInvoiceHd",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_ApInvoiceTr_AccountId",
                table: "ApInvoiceTr",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_ApInvoiceTr_ApInvoiceHdId",
                table: "ApInvoiceTr",
                column: "ApInvoiceHdId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApInvoiceTr");

            migrationBuilder.DropTable(
                name: "ApInvoiceHd");
        }
    }
}
