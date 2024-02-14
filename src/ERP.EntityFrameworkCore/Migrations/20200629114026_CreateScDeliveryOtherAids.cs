using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class CreateScDeliveryOtherAids : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ScDeliveryOtherAids",
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
                    OperationNumber = table.Column<string>(maxLength: 30, nullable: false),
                    OperationDate = table.Column<DateTime>(nullable: false),
                    MaturityDate = table.Column<DateTime>(nullable: true),
                    StatusLkpId = table.Column<long>(nullable: false),
                    CommitteeId = table.Column<long>(nullable: true),
                    Notes = table.Column<string>(maxLength: 4000, nullable: true),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScDeliveryOtherAids", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScDeliveryOtherAids_ScCommittees_CommitteeId",
                        column: x => x.CommitteeId,
                        principalTable: "ScCommittees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ScDeliveryOtherAids_FndLookupValues_StatusLkpId",
                        column: x => x.StatusLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScDeliveryOtherAidDetails",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    ScDeliveryOtherAidsId = table.Column<long>(nullable: false),
                    CommitteeDetailsId = table.Column<long>(nullable: true),
                    ScPortalRequestMgrDecisionId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScDeliveryOtherAidDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScDeliveryOtherAidDetails_ScCommitteeDetails_CommitteeDetailsId",
                        column: x => x.CommitteeDetailsId,
                        principalTable: "ScCommitteeDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ScDeliveryOtherAidDetails_ScDeliveryOtherAids_ScDeliveryOtherAidsId",
                        column: x => x.ScDeliveryOtherAidsId,
                        principalTable: "ScDeliveryOtherAids",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScDeliveryOtherAidDetails_ScPortalRequestMgrDecision_ScPortalRequestMgrDecisionId",
                        column: x => x.ScPortalRequestMgrDecisionId,
                        principalTable: "ScPortalRequestMgrDecision",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ScDeliveryOtherAidDetails_CommitteeDetailsId",
                table: "ScDeliveryOtherAidDetails",
                column: "CommitteeDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_ScDeliveryOtherAidDetails_ScDeliveryOtherAidsId",
                table: "ScDeliveryOtherAidDetails",
                column: "ScDeliveryOtherAidsId");

            migrationBuilder.CreateIndex(
                name: "IX_ScDeliveryOtherAidDetails_ScPortalRequestMgrDecisionId",
                table: "ScDeliveryOtherAidDetails",
                column: "ScPortalRequestMgrDecisionId");

            migrationBuilder.CreateIndex(
                name: "IX_ScDeliveryOtherAids_CommitteeId",
                table: "ScDeliveryOtherAids",
                column: "CommitteeId");

            migrationBuilder.CreateIndex(
                name: "IX_ScDeliveryOtherAids_StatusLkpId",
                table: "ScDeliveryOtherAids",
                column: "StatusLkpId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScDeliveryOtherAidDetails");

            migrationBuilder.DropTable(
                name: "ScDeliveryOtherAids");
        }
    }
}
