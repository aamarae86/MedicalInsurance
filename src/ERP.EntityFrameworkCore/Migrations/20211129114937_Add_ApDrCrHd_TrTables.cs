using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class Add_ApDrCrHd_TrTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_ArJobCardHd_FndLookupValues_VehicleEmirateLkpId",
            //    table: "ArJobCardHd");

            //migrationBuilder.AlterColumn<long>(
            //    name: "VehicleEmirateLkpId",
            //    table: "ArJobCardHd",
            //    nullable: false,
            //    oldClrType: typeof(long),
            //    oldNullable: true);

            //migrationBuilder.CreateTable(
            //    name: "AbpKpiRole",
            //    columns: table => new
            //    {
            //        Id = table.Column<long>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        CreationTime = table.Column<DateTime>(nullable: false),
            //        CreatorUserId = table.Column<long>(nullable: true),
            //        LastModificationTime = table.Column<DateTime>(nullable: true),
            //        LastModifierUserId = table.Column<long>(nullable: true),
            //        KpiLkpId = table.Column<long>(nullable: false),
            //        RoleId = table.Column<long>(nullable: false),
            //        TenantId = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AbpKpiRole", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_AbpKpiRole_FndLookupValues_KpiLkpId",
            //            column: x => x.KpiLkpId,
            //            principalTable: "FndLookupValues",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            migrationBuilder.CreateTable(
                name: "ApDrCrHd",
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
                    TenantId = table.Column<int>(nullable: false),
                    HdDrCrNumber = table.Column<string>(maxLength: 30, nullable: true),
                    HdDate = table.Column<DateTime>(nullable: true),
                    Comments = table.Column<string>(maxLength: 4000, nullable: true),
                    CurrencyRate = table.Column<decimal>(type: "decimal(18, 6)", nullable: true),
                    SourceId = table.Column<long>(nullable: true),
                    SourceNo = table.Column<string>(maxLength: 30, nullable: true),
                    HdTypeLkpId = table.Column<long>(nullable: true),
                    StatusLkpId = table.Column<long>(nullable: true),
                    CurrencyId = table.Column<int>(nullable: false),
                    VendorId = table.Column<long>(nullable: true),
                    SourceLkpId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApDrCrHd", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApDrCrHd_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ApDrCrHd_FndLookupValues_HdTypeLkpId",
                        column: x => x.HdTypeLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ApDrCrHd_FndLookupValues_SourceLkpId",
                        column: x => x.SourceLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ApDrCrHd_FndLookupValues_StatusLkpId",
                        column: x => x.StatusLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ApDrCrHd_ApVendors_VendorId",
                        column: x => x.VendorId,
                        principalTable: "ApVendors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ApDrCrTr",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18, 6)", nullable: true),
                    Description = table.Column<string>(maxLength: 4000, nullable: true),
                    Tax = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
                    AccountId = table.Column<long>(nullable: true),
                    ApDrCrHdId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApDrCrTr", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApDrCrTr_GlCodeComDetails_AccountId",
                        column: x => x.AccountId,
                        principalTable: "GlCodeComDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ApDrCrTr_ApDrCrHd_ApDrCrHdId",
                        column: x => x.ApDrCrHdId,
                        principalTable: "ApDrCrHd",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            //migrationBuilder.CreateIndex(
            //    name: "IX_AbpKpiRole_KpiLkpId",
            //    table: "AbpKpiRole",
            //    column: "KpiLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_ApDrCrHd_CurrencyId",
                table: "ApDrCrHd",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_ApDrCrHd_HdTypeLkpId",
                table: "ApDrCrHd",
                column: "HdTypeLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_ApDrCrHd_SourceLkpId",
                table: "ApDrCrHd",
                column: "SourceLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_ApDrCrHd_StatusLkpId",
                table: "ApDrCrHd",
                column: "StatusLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_ApDrCrHd_VendorId",
                table: "ApDrCrHd",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_ApDrCrTr_AccountId",
                table: "ApDrCrTr",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_ApDrCrTr_ApDrCrHdId",
                table: "ApDrCrTr",
                column: "ApDrCrHdId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_ArJobCardHd_FndLookupValues_VehicleEmirateLkpId",
            //    table: "ArJobCardHd",
            //    column: "VehicleEmirateLkpId",
            //    principalTable: "FndLookupValues",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_ArJobCardHd_FndLookupValues_VehicleEmirateLkpId",
            //    table: "ArJobCardHd");

            //migrationBuilder.DropTable(
            //    name: "AbpKpiRole");

            migrationBuilder.DropTable(
                name: "ApDrCrTr");

            migrationBuilder.DropTable(
                name: "ApDrCrHd");

            //migrationBuilder.AlterColumn<long>(
            //    name: "VehicleEmirateLkpId",
            //    table: "ArJobCardHd",
            //    nullable: true,
            //    oldClrType: typeof(long));

            //migrationBuilder.AddForeignKey(
            //    name: "FK_ArJobCardHd_FndLookupValues_VehicleEmirateLkpId",
            //    table: "ArJobCardHd",
            //    column: "VehicleEmirateLkpId",
            //    principalTable: "FndLookupValues",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Restrict);
        }
    }
}
