using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class FaAssetDeprnTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FaAssetDeprnHd",
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
                    AssetDeprnNumber = table.Column<string>(maxLength: 30, nullable: true),
                    AssetDeprnDate = table.Column<DateTime>(nullable: true),
                    AssetDeprnName = table.Column<string>(maxLength: 200, nullable: true),
                    StatusLkpId = table.Column<long>(nullable: true),
                    PeriodId = table.Column<long>(nullable: true),
                    AssetId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FaAssetDeprnHd", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FaAssetDeprnHd_FaAssets_AssetId",
                        column: x => x.AssetId,
                        principalTable: "FaAssets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FaAssetDeprnHd_GlPeriodsYears_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "GlPeriodsYears",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FaAssetDeprnHd_FndLookupValues_StatusLkpId",
                        column: x => x.StatusLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FaAssetDeprnTr",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FaAssetDeprnHdId = table.Column<long>(nullable: true),
                    AssetId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FaAssetDeprnTr", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FaAssetDeprnTr_FaAssets_AssetId",
                        column: x => x.AssetId,
                        principalTable: "FaAssets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FaAssetDeprnTr_FaAssetDeprnHd_FaAssetDeprnHdId",
                        column: x => x.FaAssetDeprnHdId,
                        principalTable: "FaAssetDeprnHd",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FaAssetDeprnTrDtl",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FaAssetDeprnTrId = table.Column<long>(nullable: true),
                    DebitAmount = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    CreditAmount = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    AccountId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FaAssetDeprnTrDtl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FaAssetDeprnTrDtl_FaAssetDeprnTr_FaAssetDeprnTrId",
                        column: x => x.FaAssetDeprnTrId,
                        principalTable: "FaAssetDeprnTr",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FaAssetDeprnHd_AssetId",
                table: "FaAssetDeprnHd",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_FaAssetDeprnHd_PeriodId",
                table: "FaAssetDeprnHd",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_FaAssetDeprnHd_StatusLkpId",
                table: "FaAssetDeprnHd",
                column: "StatusLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_FaAssetDeprnTr_AssetId",
                table: "FaAssetDeprnTr",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_FaAssetDeprnTr_FaAssetDeprnHdId",
                table: "FaAssetDeprnTr",
                column: "FaAssetDeprnHdId");

            migrationBuilder.CreateIndex(
                name: "IX_FaAssetDeprnTrDtl_FaAssetDeprnTrId",
                table: "FaAssetDeprnTrDtl",
                column: "FaAssetDeprnTrId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FaAssetDeprnTrDtl");

            migrationBuilder.DropTable(
                name: "FaAssetDeprnTr");

            migrationBuilder.DropTable(
                name: "FaAssetDeprnHd");
        }
    }
}
