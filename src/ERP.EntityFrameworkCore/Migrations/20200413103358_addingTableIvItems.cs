using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class addingTableIvItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IvItems",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IvItemsTypesConfigureId = table.Column<long>(nullable: true),
                    ItemNumber = table.Column<string>(maxLength: 20, nullable: true),
                    ItemName = table.Column<string>(maxLength: 200, nullable: true),
                    ItemBarcode = table.Column<string>(maxLength: 50, nullable: true),
                    ItemRef1 = table.Column<string>(maxLength: 30, nullable: true),
                    ItemRef2 = table.Column<string>(maxLength: 30, nullable: true),
                    IvUnitId = table.Column<long>(nullable: true),
                    ItemOrdQty = table.Column<decimal>(type: "decimal(18, 6)", nullable: true),
                    ItemMaxStk = table.Column<decimal>(type: "decimal(18, 6)", nullable: true),
                    ItemMinStk = table.Column<decimal>(type: "decimal(18, 6)", nullable: true),
                    ItemQtys = table.Column<decimal>(type: "decimal(18, 6)", nullable: true),
                    AvgCost = table.Column<decimal>(type: "decimal(18, 6)", nullable: true),
                    LastCost = table.Column<decimal>(type: "decimal(18, 6)", nullable: true),
                    IsItemObsolete = table.Column<bool>(nullable: true),
                    ObsoleteDate = table.Column<DateTime>(nullable: true),
                    IsDonationItem = table.Column<bool>(nullable: true),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IvItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IvItems_IvItemsTypesConfigure_IvItemsTypesConfigureId",
                        column: x => x.IvItemsTypesConfigureId,
                        principalTable: "IvItemsTypesConfigure",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IvItems_IvUnits_IvUnitId",
                        column: x => x.IvUnitId,
                        principalTable: "IvUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IvItems_IvItemsTypesConfigureId",
                table: "IvItems",
                column: "IvItemsTypesConfigureId");

            migrationBuilder.CreateIndex(
                name: "IX_IvItems_IvUnitId",
                table: "IvItems",
                column: "IvUnitId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IvItems");
        }
    }
}
