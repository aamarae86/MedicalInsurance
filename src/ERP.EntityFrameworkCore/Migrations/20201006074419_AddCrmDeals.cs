using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class AddCrmDeals : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CrmDeals",
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
                    DealDate = table.Column<DateTime>(nullable: false),
                    DealName = table.Column<string>(nullable: true),
                    DealTypeLkpId = table.Column<long>(nullable: false),
                    NextStep = table.Column<string>(maxLength: 150, nullable: true),
                    LeadSourceLkpId = table.Column<long>(nullable: false),
                    CrmLeadsPersonsId = table.Column<long>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    ClosingDate = table.Column<DateTime>(nullable: true),
                    StageLkpID = table.Column<long>(nullable: false),
                    Probability = table.Column<string>(nullable: true),
                    Description = table.Column<string>(maxLength: 4000, nullable: true),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrmDeals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CrmDeals_CrmLeadsPersons_CrmLeadsPersonsId",
                        column: x => x.CrmLeadsPersonsId,
                        principalTable: "CrmLeadsPersons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CrmDeals_FndLookupValues_DealTypeLkpId",
                        column: x => x.DealTypeLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CrmDeals_FndLookupValues_LeadSourceLkpId",
                        column: x => x.LeadSourceLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CrmDeals_FndLookupValues_StageLkpID",
                        column: x => x.StageLkpID,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CrmDeals_CrmLeadsPersonsId",
                table: "CrmDeals",
                column: "CrmLeadsPersonsId");

            migrationBuilder.CreateIndex(
                name: "IX_CrmDeals_DealTypeLkpId",
                table: "CrmDeals",
                column: "DealTypeLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_CrmDeals_LeadSourceLkpId",
                table: "CrmDeals",
                column: "LeadSourceLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_CrmDeals_StageLkpID",
                table: "CrmDeals",
                column: "StageLkpID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CrmDeals");
        }
    }
}
