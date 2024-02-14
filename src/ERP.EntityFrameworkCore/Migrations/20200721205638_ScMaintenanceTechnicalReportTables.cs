using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class ScMaintenanceTechnicalReportTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ScMaintenanceTechnicalReport",
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
                    TechnicalReportNumber = table.Column<string>(maxLength: 30, nullable: false),
                    TechnicalReportDate = table.Column<DateTime>(nullable: false),
                    StatusLkpId = table.Column<long>(nullable: true),
                    PortalRequestId = table.Column<long>(nullable: true),
                    Notes = table.Column<string>(maxLength: 4000, nullable: true),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScMaintenanceTechnicalReport", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScMaintenanceTechnicalReport_ScPortalRequests_PortalRequestId",
                        column: x => x.PortalRequestId,
                        principalTable: "ScPortalRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ScMaintenanceTechnicalReport_FndLookupValues_StatusLkpId",
                        column: x => x.StatusLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ScMaintenanceTechnicalReportAttachments",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    FilePath = table.Column<string>(nullable: true),
                    TenantId = table.Column<int>(nullable: false),
                    ScMaintenanceTechnicalReportId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScMaintenanceTechnicalReportAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScMaintenanceTechnicalReportAttachments_ScMaintenanceTechnicalReport_ScMaintenanceTechnicalReportId",
                        column: x => x.ScMaintenanceTechnicalReportId,
                        principalTable: "ScMaintenanceTechnicalReport",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScMaintenanceTechnicalReportDetail",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    ScMaintenanceTechnicalReportId = table.Column<long>(nullable: false),
                    ItemDescription = table.Column<string>(maxLength: 4000, nullable: true),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScMaintenanceTechnicalReportDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScMaintenanceTechnicalReportDetail_ScMaintenanceTechnicalReport_ScMaintenanceTechnicalReportId",
                        column: x => x.ScMaintenanceTechnicalReportId,
                        principalTable: "ScMaintenanceTechnicalReport",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ScMaintenanceTechnicalReport_PortalRequestId",
                table: "ScMaintenanceTechnicalReport",
                column: "PortalRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_ScMaintenanceTechnicalReport_StatusLkpId",
                table: "ScMaintenanceTechnicalReport",
                column: "StatusLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_ScMaintenanceTechnicalReportAttachments_ScMaintenanceTechnicalReportId",
                table: "ScMaintenanceTechnicalReportAttachments",
                column: "ScMaintenanceTechnicalReportId");

            migrationBuilder.CreateIndex(
                name: "IX_ScMaintenanceTechnicalReportDetail_ScMaintenanceTechnicalReportId",
                table: "ScMaintenanceTechnicalReportDetail",
                column: "ScMaintenanceTechnicalReportId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScMaintenanceTechnicalReportAttachments");

            migrationBuilder.DropTable(
                name: "ScMaintenanceTechnicalReportDetail");

            migrationBuilder.DropTable(
                name: "ScMaintenanceTechnicalReport");
        }
    }
}
