using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class addingTableScPortalMgrDecision : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ScPortalRequestMgrDecision",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    DecisionDate = table.Column<DateTime>(nullable: true),
                    StatusLkpId = table.Column<long>(nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18, 6)", nullable: true),
                    CashingTo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    RefuseLkpId = table.Column<long>(nullable: true),
                    RefuseDescription = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    PortalRequestStudyId = table.Column<long>(nullable: true),
                    DecisionNumer = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScPortalRequestMgrDecision", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScPortalRequestMgrDecision_ScPortalRequestStudy_PortalRequestStudyId",
                        column: x => x.PortalRequestStudyId,
                        principalTable: "ScPortalRequestStudy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ScPortalRequestMgrDecision_FndLookupValues_RefuseLkpId",
                        column: x => x.RefuseLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ScPortalRequestMgrDecision_FndLookupValues_StatusLkpId",
                        column: x => x.StatusLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ScPortalRequestMgrDecision_PortalRequestStudyId",
                table: "ScPortalRequestMgrDecision",
                column: "PortalRequestStudyId");

            migrationBuilder.CreateIndex(
                name: "IX_ScPortalRequestMgrDecision_RefuseLkpId",
                table: "ScPortalRequestMgrDecision",
                column: "RefuseLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_ScPortalRequestMgrDecision_StatusLkpId",
                table: "ScPortalRequestMgrDecision",
                column: "StatusLkpId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScPortalRequestMgrDecision");
        }
    }
}
