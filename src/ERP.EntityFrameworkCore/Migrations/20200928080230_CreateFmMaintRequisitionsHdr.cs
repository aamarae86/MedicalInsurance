using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class CreateFmMaintRequisitionsHdr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FmMaintRequisitionsHdr",
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
                    RequisitionNumber = table.Column<string>(maxLength: 30, nullable: false),
                    RequisitionStatusLkpId = table.Column<long>(nullable: false),
                    PmPropertiesId = table.Column<long>(nullable: false),
                    ComplaintTypeLkpId = table.Column<long>(nullable: false),
                    UnitTypeLkpId = table.Column<long>(nullable: true),
                    UnitId = table.Column<long>(nullable: true),
                    RequisitionDate = table.Column<DateTime>(nullable: true),
                    RequisitionTime = table.Column<DateTime>(nullable: true),
                    CallerName = table.Column<string>(maxLength: 150, nullable: true),
                    PhoneNumber = table.Column<string>(maxLength: 30, nullable: true),
                    Mobile = table.Column<string>(maxLength: 30, nullable: true),
                    ComplaintDetails = table.Column<string>(maxLength: 4000, nullable: true),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FmMaintRequisitionsHdr", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FmMaintRequisitionsHdr_FndLookupValues_ComplaintTypeLkpId",
                        column: x => x.ComplaintTypeLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FmMaintRequisitionsHdr_PmProperties_PmPropertiesId",
                        column: x => x.PmPropertiesId,
                        principalTable: "PmProperties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FmMaintRequisitionsHdr_FndLookupValues_RequisitionStatusLkpId",
                        column: x => x.RequisitionStatusLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_FmMaintRequisitionsHdr_PmPropertiesUnits_UnitId",
                        column: x => x.UnitId,
                        principalTable: "PmPropertiesUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FmMaintRequisitionsHdr_FndLookupValues_UnitTypeLkpId",
                        column: x => x.UnitTypeLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FmMaintRequisitionsHdr_ComplaintTypeLkpId",
                table: "FmMaintRequisitionsHdr",
                column: "ComplaintTypeLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_FmMaintRequisitionsHdr_PmPropertiesId",
                table: "FmMaintRequisitionsHdr",
                column: "PmPropertiesId");

            migrationBuilder.CreateIndex(
                name: "IX_FmMaintRequisitionsHdr_RequisitionStatusLkpId",
                table: "FmMaintRequisitionsHdr",
                column: "RequisitionStatusLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_FmMaintRequisitionsHdr_UnitId",
                table: "FmMaintRequisitionsHdr",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_FmMaintRequisitionsHdr_UnitTypeLkpId",
                table: "FmMaintRequisitionsHdr",
                column: "UnitTypeLkpId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FmMaintRequisitionsHdr");
        }
    }
}
