using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class ScMaintenanceQuotationsTbls : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "ScMaintenanceQuotations",
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
                    QuotationNumber = table.Column<string>(maxLength: 30, nullable: false),
                    QuotationDate = table.Column<DateTime>(nullable: false),
                    StatusLkpId = table.Column<long>(nullable: false),
                    ScMaintenanceTechnicalReportId = table.Column<long>(nullable: false),
                    VendorId = table.Column<long>(nullable: false),
                    Notes = table.Column<string>(maxLength: 4000, nullable: true),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScMaintenanceQuotations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScMaintenanceQuotations_ScMaintenanceTechnicalReport_ScMaintenanceTechnicalReportId",
                        column: x => x.ScMaintenanceTechnicalReportId,
                        principalTable: "ScMaintenanceTechnicalReport",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScMaintenanceQuotations_FndLookupValues_StatusLkpId",
                        column: x => x.StatusLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScMaintenanceQuotations_ApVendors_VendorId",
                        column: x => x.VendorId,
                        principalTable: "ApVendors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ScMaintenanceQuotationAttachments",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    AttachmentName = table.Column<string>(maxLength: 200, nullable: true),
                    FilePath = table.Column<string>(maxLength: 4000, nullable: false),
                    ScMaintenanceQuotationId = table.Column<long>(nullable: false),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScMaintenanceQuotationAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScMaintenanceQuotationAttachments_ScMaintenanceQuotations_ScMaintenanceQuotationId",
                        column: x => x.ScMaintenanceQuotationId,
                        principalTable: "ScMaintenanceQuotations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScMaintenanceQuotationDetails",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    ScMaintenanceQuotationId = table.Column<long>(nullable: false),
                    ScMaintenanceTechnicalReportDetailId = table.Column<long>(nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScMaintenanceQuotationDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScMaintenanceQuotationDetails_ScMaintenanceQuotations_ScMaintenanceQuotationId",
                        column: x => x.ScMaintenanceQuotationId,
                        principalTable: "ScMaintenanceQuotations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScMaintenanceQuotationDetails_ScMaintenanceTechnicalReportDetail_ScMaintenanceTechnicalReportDetailId",
                        column: x => x.ScMaintenanceTechnicalReportDetailId,
                        principalTable: "ScMaintenanceTechnicalReportDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ScMaintenanceQuotationAttachments_ScMaintenanceQuotationId",
                table: "ScMaintenanceQuotationAttachments",
                column: "ScMaintenanceQuotationId");

            migrationBuilder.CreateIndex(
                name: "IX_ScMaintenanceQuotationDetails_ScMaintenanceQuotationId",
                table: "ScMaintenanceQuotationDetails",
                column: "ScMaintenanceQuotationId");

            migrationBuilder.CreateIndex(
                name: "IX_ScMaintenanceQuotationDetails_ScMaintenanceTechnicalReportDetailId",
                table: "ScMaintenanceQuotationDetails",
                column: "ScMaintenanceTechnicalReportDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_ScMaintenanceQuotations_ScMaintenanceTechnicalReportId",
                table: "ScMaintenanceQuotations",
                column: "ScMaintenanceTechnicalReportId");

            migrationBuilder.CreateIndex(
                name: "IX_ScMaintenanceQuotations_StatusLkpId",
                table: "ScMaintenanceQuotations",
                column: "StatusLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_ScMaintenanceQuotations_VendorId",
                table: "ScMaintenanceQuotations",
                column: "VendorId");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScMaintenanceQuotationAttachments");

            migrationBuilder.DropTable(
                name: "ScMaintenanceQuotationDetails");

            migrationBuilder.DropTable(
                name: "ScMaintenanceQuotations");

        }
    }
}
