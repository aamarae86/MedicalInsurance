using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class faAsset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FaAssets",
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
                    AssetNumber = table.Column<string>(maxLength: 30, nullable: true),
                    Description = table.Column<string>(maxLength: 4000, nullable: true),
                    TagNumber = table.Column<string>(maxLength: 100, nullable: true),
                    SerialNumber = table.Column<string>(maxLength: 100, nullable: true),
                    AssetTypeLkpId = table.Column<long>(nullable: true),
                    AssetKey = table.Column<string>(maxLength: 100, nullable: true),
                    FaAssetCategoryId = table.Column<long>(nullable: false),
                    Units = table.Column<long>(nullable: false),
                    ParentAssetId = table.Column<long>(nullable: true),
                    Manufacturer = table.Column<string>(maxLength: 200, nullable: true),
                    Model = table.Column<string>(maxLength: 200, nullable: true),
                    WarrantyNumber = table.Column<string>(maxLength: 200, nullable: true),
                    InUse = table.Column<bool>(nullable: true),
                    InPhysicalInventory = table.Column<bool>(nullable: true),
                    OwnershipLkpId = table.Column<long>(nullable: true),
                    BoughtLkpId = table.Column<long>(nullable: true),
                    DatePlacedInService = table.Column<DateTime>(nullable: true),
                    BookingTypeLkpId = table.Column<long>(nullable: false),
                    CurrentCost = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    OriginalCost = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    SalvageValueTypeLkpId = table.Column<long>(nullable: true),
                    SalvageValue = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    RecoverableCost = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    YtdProceeds = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    RevaluationCeiling = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    RevaluationReserve = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    DeprenMethodLkpId = table.Column<long>(nullable: true),
                    LifeInMonths = table.Column<int>(nullable: true),
                    IsDepreciate = table.Column<bool>(nullable: true),
                    ProrateConversionCode = table.Column<string>(maxLength: 30, nullable: true),
                    ProrateDate = table.Column<DateTime>(nullable: true),
                    AmortizationStartDate = table.Column<DateTime>(nullable: true),
                    IsAmortizeAdjustment = table.Column<long>(nullable: true),
                    StatusLkpId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FaAssets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FaAssets_FndLookupValues_AssetTypeLkpId",
                        column: x => x.AssetTypeLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FaAssets_FndLookupValues_BookingTypeLkpId",
                        column: x => x.BookingTypeLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FaAssets_FndLookupValues_BoughtLkpId",
                        column: x => x.BoughtLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FaAssets_FndLookupValues_DeprenMethodLkpId",
                        column: x => x.DeprenMethodLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FaAssets_FaAssetCategory_FaAssetCategoryId",
                        column: x => x.FaAssetCategoryId,
                        principalTable: "FaAssetCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FaAssets_FndLookupValues_OwnershipLkpId",
                        column: x => x.OwnershipLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FaAssets_FaAssets_ParentAssetId",
                        column: x => x.ParentAssetId,
                        principalTable: "FaAssets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FaAssets_FndLookupValues_SalvageValueTypeLkpId",
                        column: x => x.SalvageValueTypeLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FaAssets_FndLookupValues_StatusLkpId",
                        column: x => x.StatusLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FaAssets_AssetTypeLkpId",
                table: "FaAssets",
                column: "AssetTypeLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_FaAssets_BookingTypeLkpId",
                table: "FaAssets",
                column: "BookingTypeLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_FaAssets_BoughtLkpId",
                table: "FaAssets",
                column: "BoughtLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_FaAssets_DeprenMethodLkpId",
                table: "FaAssets",
                column: "DeprenMethodLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_FaAssets_FaAssetCategoryId",
                table: "FaAssets",
                column: "FaAssetCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_FaAssets_OwnershipLkpId",
                table: "FaAssets",
                column: "OwnershipLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_FaAssets_ParentAssetId",
                table: "FaAssets",
                column: "ParentAssetId");

            migrationBuilder.CreateIndex(
                name: "IX_FaAssets_SalvageValueTypeLkpId",
                table: "FaAssets",
                column: "SalvageValueTypeLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_FaAssets_StatusLkpId",
                table: "FaAssets",
                column: "StatusLkpId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FaAssets");
        }
    }
}
