using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class addingTablefaassetcategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FaAssetCategory",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    AssetCategoryNumber = table.Column<string>(maxLength: 30, nullable: true),
                    AssetCategoryNameAr = table.Column<string>(maxLength: 200, nullable: true),
                    AssetCategoryNameEn = table.Column<string>(maxLength: 200, nullable: true),
                    Description = table.Column<string>(nullable: true),
                    NoMonthsDepreciation = table.Column<long>(nullable: true),
                    AssetCostAccountId = table.Column<long>(nullable: true),
                    AssetClearingAccountId = table.Column<long>(nullable: true),
                    AccDeprenAccountId = table.Column<long>(nullable: true),
                    DeprenAccountId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FaAssetCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FaAssetCategory_GlCodeComDetails_AccDeprenAccountId",
                        column: x => x.AccDeprenAccountId,
                        principalTable: "GlCodeComDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FaAssetCategory_GlCodeComDetails_AssetClearingAccountId",
                        column: x => x.AssetClearingAccountId,
                        principalTable: "GlCodeComDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FaAssetCategory_GlCodeComDetails_AssetCostAccountId",
                        column: x => x.AssetCostAccountId,
                        principalTable: "GlCodeComDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FaAssetCategory_GlCodeComDetails_DeprenAccountId",
                        column: x => x.DeprenAccountId,
                        principalTable: "GlCodeComDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FaAssetCategory_AccDeprenAccountId",
                table: "FaAssetCategory",
                column: "AccDeprenAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_FaAssetCategory_AssetClearingAccountId",
                table: "FaAssetCategory",
                column: "AssetClearingAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_FaAssetCategory_AssetCostAccountId",
                table: "FaAssetCategory",
                column: "AssetCostAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_FaAssetCategory_DeprenAccountId",
                table: "FaAssetCategory",
                column: "DeprenAccountId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FaAssetCategory");
        }
    }
}
