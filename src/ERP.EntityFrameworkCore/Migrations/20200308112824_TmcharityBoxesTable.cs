using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class TmcharityBoxesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TmCharityBoxes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: false),
                    CharityBoxNumber = table.Column<string>(maxLength: 30, nullable: false),
                    CharityBoxName = table.Column<string>(maxLength: 200, nullable: false),
                    CharityBoxBarcode = table.Column<string>(maxLength: 30, nullable: false),
                    StatusLkpId = table.Column<long>(nullable: false),
                    CharityTypeId = table.Column<long>(nullable: false),
                    TmSupervisorId = table.Column<long>(nullable: true),
                    TmSubLocationId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TmCharityBoxes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TmCharityBoxes_TmCharityBoxesType_CharityTypeId",
                        column: x => x.CharityTypeId,
                        principalTable: "TmCharityBoxesType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TmCharityBoxes_FndLookupValues_StatusLkpId",
                        column: x => x.StatusLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TmCharityBoxes_TmLocationSub_TmSubLocationId",
                        column: x => x.TmSubLocationId,
                        principalTable: "TmLocationSub",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TmCharityBoxes_TmSupervisors_TmSupervisorId",
                        column: x => x.TmSupervisorId,
                        principalTable: "TmSupervisors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TmCharityBoxes_CharityTypeId",
                table: "TmCharityBoxes",
                column: "CharityTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TmCharityBoxes_StatusLkpId",
                table: "TmCharityBoxes",
                column: "StatusLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_TmCharityBoxes_TmSubLocationId",
                table: "TmCharityBoxes",
                column: "TmSubLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_TmCharityBoxes_TmSupervisorId",
                table: "TmCharityBoxes",
                column: "TmSupervisorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TmCharityBoxes");
        }
    }
}
