using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class Add_TablesIvInventorySetting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IvInventorySetting",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    SettingNumber = table.Column<string>(maxLength: 20, nullable: false),
                    UserId = table.Column<long>(nullable: false),
                    ShowItemCost = table.Column<bool>(nullable: false, defaultValue: false),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IvInventorySetting", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IvInventorySetting_AbpUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                }); ;

            migrationBuilder.CreateTable(
                name: "IvInventorySettingPriceList",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IvInventorySettingId = table.Column<long>(nullable: false),
                    IvPriceListHdId = table.Column<long>(nullable: false),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IvInventorySettingPriceList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IvInventorySettingPriceList_IvInventorySetting_IvInventorySettingId",
                        column: x => x.IvInventorySettingId,
                        principalTable: "IvInventorySetting",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IvInventorySettingPriceList_IvPriceListHd_IvPriceListHdId",
                        column: x => x.IvPriceListHdId,
                        principalTable: "IvPriceListHd",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IvInventorySetting_UserId",
                table: "IvInventorySetting",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_IvInventorySettingPriceList_IvInventorySettingId",
                table: "IvInventorySettingPriceList",
                column: "IvInventorySettingId");

            migrationBuilder.CreateIndex(
                name: "IX_IvInventorySettingPriceList_IvPriceListHdId",
                table: "IvInventorySettingPriceList",
                column: "IvPriceListHdId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IvInventorySettingPriceList");

            migrationBuilder.DropTable(
                name: "IvInventorySetting");
        }
    }
}
