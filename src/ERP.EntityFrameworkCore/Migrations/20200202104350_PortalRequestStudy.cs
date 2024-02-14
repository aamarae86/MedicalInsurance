using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class PortalRequestStudy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ScPortalRequestStudy",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    StudyDate = table.Column<DateTime>(nullable: true),
                    StudyNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    StatusLkpId = table.Column<long>(nullable: true),
                    CashingTo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    StudyDetails = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    ResearcherDecision = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    RefuseLkpId = table.Column<long>(nullable: true),
                    RefuseDescription = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    PortalRequestId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScPortalRequestStudy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScPortalRequestStudy_ScPortalRequests_PortalRequestId",
                        column: x => x.PortalRequestId,
                        principalTable: "ScPortalRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ScPortalRequestStudy_FndLookupValues_RefuseLkpId",
                        column: x => x.RefuseLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ScPortalRequestStudy_FndLookupValues_StatusLkpId",
                        column: x => x.StatusLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ScPortalRequestStudyAttachment",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    PortalRequestStudyId = table.Column<long>(nullable: true),
                    AttachmentName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    FilePath = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScPortalRequestStudyAttachment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScPortalRequestStudyAttachment_ScPortalRequestStudy_PortalRequestStudyId",
                        column: x => x.PortalRequestStudyId,
                        principalTable: "ScPortalRequestStudy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ScPortalRequestStudy_PortalRequestId",
                table: "ScPortalRequestStudy",
                column: "PortalRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_ScPortalRequestStudy_RefuseLkpId",
                table: "ScPortalRequestStudy",
                column: "RefuseLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_ScPortalRequestStudy_StatusLkpId",
                table: "ScPortalRequestStudy",
                column: "StatusLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_ScPortalRequestStudyAttachment_PortalRequestStudyId",
                table: "ScPortalRequestStudyAttachment",
                column: "PortalRequestStudyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScPortalRequestStudyAttachment");

            migrationBuilder.DropTable(
                name: "ScPortalRequestStudy");
        }
    }
}
