using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class Add_ArInvoiceSettlementHd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArInvoiceSettlementHd",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    SettlementDate = table.Column<DateTime>(nullable: false),
                    StatusLkpId = table.Column<long>(nullable: false),
                    SettlementAmount = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    SettlementNumber = table.Column<string>(nullable: false),
                    ArCustomerId = table.Column<long>(nullable: false),
                    Description = table.Column<string>(maxLength: 4000, nullable: true),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArInvoiceSettlementHd", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArInvoiceSettlementHd_ArCustomers_ArCustomerId",
                        column: x => x.ArCustomerId,
                        principalTable: "ArCustomers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArInvoiceSettlementHd_FndLookupValues_StatusLkpId",
                        column: x => x.StatusLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArInvoiceSettlementCr",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    ArInvoiceSettlementHdId = table.Column<long>(nullable: false),
                    SourceLkpId = table.Column<long>(nullable: false),
                    SourceId = table.Column<long>(nullable: false),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArInvoiceSettlementCr", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArInvoiceSettlementCr_ArInvoiceSettlementHd_ArInvoiceSettlementHdId",
                        column: x => x.ArInvoiceSettlementHdId,
                        principalTable: "ArInvoiceSettlementHd",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArInvoiceSettlementDr",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    ArInvoiceSettlementHdId = table.Column<long>(nullable: false),
                    SourceLkpId = table.Column<long>(nullable: false),
                    SourceId = table.Column<long>(nullable: false),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArInvoiceSettlementDr", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArInvoiceSettlementDr_ArInvoiceSettlementHd_ArInvoiceSettlementHdId",
                        column: x => x.ArInvoiceSettlementHdId,
                        principalTable: "ArInvoiceSettlementHd",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArInvoiceSettlementCr_ArInvoiceSettlementHdId",
                table: "ArInvoiceSettlementCr",
                column: "ArInvoiceSettlementHdId");

            migrationBuilder.CreateIndex(
                name: "IX_ArInvoiceSettlementDr_ArInvoiceSettlementHdId",
                table: "ArInvoiceSettlementDr",
                column: "ArInvoiceSettlementHdId");

            migrationBuilder.CreateIndex(
                name: "IX_ArInvoiceSettlementHd_ArCustomerId",
                table: "ArInvoiceSettlementHd",
                column: "ArCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ArInvoiceSettlementHd_StatusLkpId",
                table: "ArInvoiceSettlementHd",
                column: "StatusLkpId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArInvoiceSettlementCr");

            migrationBuilder.DropTable(
                name: "ArInvoiceSettlementDr");

            migrationBuilder.DropTable(
                name: "ArInvoiceSettlementHd");
        }
    }
}
