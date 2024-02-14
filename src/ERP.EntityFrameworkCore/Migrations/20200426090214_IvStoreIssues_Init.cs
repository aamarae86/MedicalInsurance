using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class IvStoreIssues_Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IvStoreIssueHds",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: false),
                    StoreIssueNumber = table.Column<string>(maxLength: 20, nullable: true),
                    StoreIssueDate = table.Column<DateTime>(nullable: false),
                    StatusLkpId = table.Column<long>(nullable: false),
                    IvWarehouseId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IvStoreIssueHds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IvStoreIssueHds_IvWarehouses_IvWarehouseId",
                        column: x => x.IvWarehouseId,
                        principalTable: "IvWarehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IvStoreIssueHds_FndLookupValues_StatusLkpId",
                        column: x => x.StatusLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IvStoreIssueTrs",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: false),
                    IvStoreIssueId = table.Column<long>(nullable: false),
                    IvItemId = table.Column<long>(nullable: false),
                    QtyOrdered = table.Column<decimal>(type: "decimal(18, 6)", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18, 6)", nullable: false),
                    ReceivedQty = table.Column<decimal>(type: "decimal(18, 6)", nullable: true),
                    ReceivedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IvStoreIssueTrs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IvStoreIssueTrs_IvItems_IvItemId",
                        column: x => x.IvItemId,
                        principalTable: "IvItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IvStoreIssueTrs_IvStoreIssueHds_IvStoreIssueId",
                        column: x => x.IvStoreIssueId,
                        principalTable: "IvStoreIssueHds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IvStoreIssueHds_IvWarehouseId",
                table: "IvStoreIssueHds",
                column: "IvWarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_IvStoreIssueHds_StatusLkpId",
                table: "IvStoreIssueHds",
                column: "StatusLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_IvStoreIssueTrs_IvItemId",
                table: "IvStoreIssueTrs",
                column: "IvItemId");

            migrationBuilder.CreateIndex(
                name: "IX_IvStoreIssueTrs_IvStoreIssueId",
                table: "IvStoreIssueTrs",
                column: "IvStoreIssueId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IvStoreIssueTrs");

            migrationBuilder.DropTable(
                name: "IvStoreIssueHds");
        }
    }
}
