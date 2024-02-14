using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class AddingTablesArDrCrHdAndItsDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArDrCrHd",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    HdDrCrNumber = table.Column<string>(maxLength: 30, nullable: true),
                    HdDate = table.Column<DateTime>(nullable: true),
                    HdTypeLkpId = table.Column<long>(nullable: true),
                    Comments = table.Column<string>(maxLength: 4000, nullable: true),
                    StatusLkpId = table.Column<long>(nullable: true),
                    CurrencyId = table.Column<int>(nullable: false),
                    CurrencyRate = table.Column<decimal>(type: "decimal(18, 6)", nullable: true),
                    ArCustomerId = table.Column<long>(nullable: true),
                    SourceLkpId = table.Column<long>(nullable: true),
                    SourceId = table.Column<long>(nullable: true),
                    SourceNo = table.Column<string>(maxLength: 30, nullable: true),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArDrCrHd", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArDrCrHd_ArCustomers_ArCustomerId",
                        column: x => x.ArCustomerId,
                        principalTable: "ArCustomers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ArDrCrHd_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArDrCrHd_FndLookupValues_HdTypeLkpId",
                        column: x => x.HdTypeLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ArDrCrHd_FndLookupValues_SourceLkpId",
                        column: x => x.SourceLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ArDrCrHd_FndLookupValues_StatusLkpId",
                        column: x => x.StatusLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ArDrCrTr",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    AccountId = table.Column<long>(nullable: true),
                    Description = table.Column<string>(maxLength: 4000, nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18, 6)", nullable: true),
                    ArDrCrHdId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArDrCrTr", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArDrCrTr_GlCodeComDetails_AccountId",
                        column: x => x.AccountId,
                        principalTable: "GlCodeComDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ArDrCrTr_ArDrCrHd_ArDrCrHdId",
                        column: x => x.ArDrCrHdId,
                        principalTable: "ArDrCrHd",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArDrCrHd_ArCustomerId",
                table: "ArDrCrHd",
                column: "ArCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ArDrCrHd_CurrencyId",
                table: "ArDrCrHd",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_ArDrCrHd_HdTypeLkpId",
                table: "ArDrCrHd",
                column: "HdTypeLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_ArDrCrHd_SourceLkpId",
                table: "ArDrCrHd",
                column: "SourceLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_ArDrCrHd_StatusLkpId",
                table: "ArDrCrHd",
                column: "StatusLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_ArDrCrTr_AccountId",
                table: "ArDrCrTr",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_ArDrCrTr_ArDrCrHdId",
                table: "ArDrCrTr",
                column: "ArDrCrHdId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArDrCrTr");

            migrationBuilder.DropTable(
                name: "ArDrCrHd");
        }
    }
}
