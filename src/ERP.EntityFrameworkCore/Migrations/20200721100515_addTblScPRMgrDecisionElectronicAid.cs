using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class addTblScPRMgrDecisionElectronicAid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ScPRMgrDecisionElectronicAid",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    ElectronicTypeLkpId = table.Column<long>(nullable: false),
                    ScPortalRequestMgrDecisionId = table.Column<long>(nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScPRMgrDecisionElectronicAid", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScPRMgrDecisionElectronicAid_FndLookupValues_ElectronicTypeLkpId",
                        column: x => x.ElectronicTypeLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScPRMgrDecisionElectronicAid_ScPortalRequestMgrDecision_ScPortalRequestMgrDecisionId",
                        column: x => x.ScPortalRequestMgrDecisionId,
                        principalTable: "ScPortalRequestMgrDecision",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ScPRMgrDecisionElectronicAid_ElectronicTypeLkpId",
                table: "ScPRMgrDecisionElectronicAid",
                column: "ElectronicTypeLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_ScPRMgrDecisionElectronicAid_ScPortalRequestMgrDecisionId",
                table: "ScPRMgrDecisionElectronicAid",
                column: "ScPortalRequestMgrDecisionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScPRMgrDecisionElectronicAid");
        }
    }
}
