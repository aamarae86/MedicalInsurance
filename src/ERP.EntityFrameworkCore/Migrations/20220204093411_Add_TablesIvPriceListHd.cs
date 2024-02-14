using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class Add_TablesIvPriceListHd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IvPriceListHd",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    PriceListNumber = table.Column<string>(maxLength: 20, nullable: false),
                    PriceListName = table.Column<string>(maxLength: 200, nullable: false),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IvPriceListHd", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IvPriceListTr",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IvPriceListHdId = table.Column<long>(nullable: false),
                    IvItemId = table.Column<long>(nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IvPriceListTr", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IvPriceListTr_IvItems_IvItemId",
                        column: x => x.IvItemId,
                        principalTable: "IvItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IvPriceListTr_IvPriceListHd_IvPriceListHdId",
                        column: x => x.IvPriceListHdId,
                        principalTable: "IvPriceListHd",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IvPriceListTr_IvItemId",
                table: "IvPriceListTr",
                column: "IvItemId");

            migrationBuilder.CreateIndex(
                name: "IX_IvPriceListTr_IvPriceListHdId",
                table: "IvPriceListTr",
                column: "IvPriceListHdId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IvPriceListTr");

            migrationBuilder.DropTable(
                name: "IvPriceListHd");
        }
    }
}
