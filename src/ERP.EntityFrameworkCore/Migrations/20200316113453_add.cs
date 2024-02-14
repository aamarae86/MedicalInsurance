using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class add : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TmDamagedCharityBoxs",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    DamagedCharityBoxsDate = table.Column<DateTime>(nullable: false),
                    DamagedCharityBoxsNumber = table.Column<string>(maxLength: 30, nullable: false),
                    TmSupervisorId = table.Column<long>(nullable: false),
                    StatusLkpId = table.Column<long>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TmDamagedCharityBoxs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TmDamagedCharityBoxs_FndLookupValues_StatusLkpId",
                        column: x => x.StatusLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TmDamagedCharityBoxs_TmSupervisors_TmSupervisorId",
                        column: x => x.TmSupervisorId,
                        principalTable: "TmSupervisors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TmDamagedCharityBoxDetails",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    TmDamagedCharityBoxId = table.Column<long>(nullable: false),
                    CharityBoxActionDetailId = table.Column<long>(nullable: false),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TmDamagedCharityBoxDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TmDamagedCharityBoxDetails_TmCharityBoxActionDetails_CharityBoxActionDetailId",
                        column: x => x.CharityBoxActionDetailId,
                        principalTable: "TmCharityBoxActionDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TmDamagedCharityBoxDetails_TmDamagedCharityBoxs_TmDamagedCharityBoxId",
                        column: x => x.TmDamagedCharityBoxId,
                        principalTable: "TmDamagedCharityBoxs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TmDamagedCharityBoxDetails_CharityBoxActionDetailId",
                table: "TmDamagedCharityBoxDetails",
                column: "CharityBoxActionDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_TmDamagedCharityBoxDetails_TmDamagedCharityBoxId",
                table: "TmDamagedCharityBoxDetails",
                column: "TmDamagedCharityBoxId");

            migrationBuilder.CreateIndex(
                name: "IX_TmDamagedCharityBoxs_StatusLkpId",
                table: "TmDamagedCharityBoxs",
                column: "StatusLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_TmDamagedCharityBoxs_TmSupervisorId",
                table: "TmDamagedCharityBoxs",
                column: "TmSupervisorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TmDamagedCharityBoxDetails");

            migrationBuilder.DropTable(
                name: "TmDamagedCharityBoxs");
        }
    }
}
