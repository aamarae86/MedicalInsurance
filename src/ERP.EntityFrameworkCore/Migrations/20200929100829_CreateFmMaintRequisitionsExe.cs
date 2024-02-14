using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class CreateFmMaintRequisitionsExe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PostTime",
                table: "FmMaintRequisitionsHdr");

            migrationBuilder.DropColumn(
                name: "PostUserId",
                table: "FmMaintRequisitionsHdr");

            migrationBuilder.DropColumn(
                name: "UnPostTime",
                table: "FmMaintRequisitionsHdr");

            migrationBuilder.DropColumn(
                name: "UnPostUserId",
                table: "FmMaintRequisitionsHdr");

            migrationBuilder.CreateTable(
                name: "FmMaintRequisitionsExe",
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
                    StatusLkpId = table.Column<long>(nullable: false),
                    ExecuteTypeLkpId = table.Column<long>(nullable: false),
                    EngineerId = table.Column<long>(nullable: false),
                    FmContractsId = table.Column<long>(nullable: false),
                    FmContractVisitsId = table.Column<long>(nullable: false),
                    FmMaintRequisitionsHdrId = table.Column<long>(nullable: true),
                    ExecuteDate = table.Column<DateTime>(nullable: false),
                    ExecuteTime = table.Column<DateTime>(nullable: false),
                    Comments = table.Column<string>(maxLength: 4000, nullable: true),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FmMaintRequisitionsExe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FmMaintRequisitionsExe_FmEngineers_EngineerId",
                        column: x => x.EngineerId,
                        principalTable: "FmEngineers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FmMaintRequisitionsExe_FndLookupValues_ExecuteTypeLkpId",
                        column: x => x.ExecuteTypeLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_FmMaintRequisitionsExe_FmContractVisits_FmContractVisitsId",
                        column: x => x.FmContractVisitsId,
                        principalTable: "FmContractVisits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_FmMaintRequisitionsExe_FmContracts_FmContractsId",
                        column: x => x.FmContractsId,
                        principalTable: "FmContracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FmMaintRequisitionsExe_FmMaintRequisitionsHdr_FmMaintRequisitionsHdrId",
                        column: x => x.FmMaintRequisitionsHdrId,
                        principalTable: "FmMaintRequisitionsHdr",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FmMaintRequisitionsExe_FndLookupValues_StatusLkpId",
                        column: x => x.StatusLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FmMaintRequisitionsExe_EngineerId",
                table: "FmMaintRequisitionsExe",
                column: "EngineerId");

            migrationBuilder.CreateIndex(
                name: "IX_FmMaintRequisitionsExe_ExecuteTypeLkpId",
                table: "FmMaintRequisitionsExe",
                column: "ExecuteTypeLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_FmMaintRequisitionsExe_FmContractVisitsId",
                table: "FmMaintRequisitionsExe",
                column: "FmContractVisitsId");

            migrationBuilder.CreateIndex(
                name: "IX_FmMaintRequisitionsExe_FmContractsId",
                table: "FmMaintRequisitionsExe",
                column: "FmContractsId");

            migrationBuilder.CreateIndex(
                name: "IX_FmMaintRequisitionsExe_FmMaintRequisitionsHdrId",
                table: "FmMaintRequisitionsExe",
                column: "FmMaintRequisitionsHdrId");

            migrationBuilder.CreateIndex(
                name: "IX_FmMaintRequisitionsExe_StatusLkpId",
                table: "FmMaintRequisitionsExe",
                column: "StatusLkpId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FmMaintRequisitionsExe");

            migrationBuilder.AddColumn<DateTime>(
                name: "PostTime",
                table: "FmMaintRequisitionsHdr",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PostUserId",
                table: "FmMaintRequisitionsHdr",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UnPostTime",
                table: "FmMaintRequisitionsHdr",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UnPostUserId",
                table: "FmMaintRequisitionsHdr",
                nullable: true);
        }
    }
}
