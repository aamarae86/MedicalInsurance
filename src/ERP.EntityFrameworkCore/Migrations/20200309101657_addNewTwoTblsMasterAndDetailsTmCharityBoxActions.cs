using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class addNewTwoTblsMasterAndDetailsTmCharityBoxActions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TmCharityBoxActions",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    ActionsDate = table.Column<DateTime>(nullable: false),
                    ActionsNumber = table.Column<string>(maxLength: 30, nullable: false),
                    Notes = table.Column<string>(maxLength: 4000, nullable: true),
                    StatusLkpId = table.Column<long>(nullable: false),
                    TmSupervisorId = table.Column<long>(nullable: false),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TmCharityBoxActions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TmCharityBoxActions_FndLookupValues_StatusLkpId",
                        column: x => x.StatusLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TmCharityBoxActions_TmSupervisors_TmSupervisorId",
                        column: x => x.TmSupervisorId,
                        principalTable: "TmSupervisors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "TmCharityBoxActionDetails",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    Notes = table.Column<string>(maxLength: 4000, nullable: true),
                    ActionLkpId = table.Column<long>(nullable: false),
                    StatusLkpId = table.Column<long>(nullable: false),
                    TmLocationSubId = table.Column<long>(nullable: false),
                    OldCharityBoxid = table.Column<long>(nullable: true),
                    NewCharityBoxId = table.Column<long>(nullable: true),
                    CharityBoxActionId = table.Column<long>(nullable: false),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TmCharityBoxActionDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TmCharityBoxActionDetails_FndLookupValues_ActionLkpId",
                        column: x => x.ActionLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TmCharityBoxActionDetails_TmCharityBoxActions_CharityBoxActionId",
                        column: x => x.CharityBoxActionId,
                        principalTable: "TmCharityBoxActions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TmCharityBoxActionDetails_TmCharityBoxes_NewCharityBoxId",
                        column: x => x.NewCharityBoxId,
                        principalTable: "TmCharityBoxes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TmCharityBoxActionDetails_TmCharityBoxes_OldCharityBoxid",
                        column: x => x.OldCharityBoxid,
                        principalTable: "TmCharityBoxes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TmCharityBoxActionDetails_FndLookupValues_StatusLkpId",
                        column: x => x.StatusLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TmCharityBoxActionDetails_TmLocationSub_TmLocationSubId",
                        column: x => x.TmLocationSubId,
                        principalTable: "TmLocationSub",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TmCharityBoxActionDetails_ActionLkpId",
                table: "TmCharityBoxActionDetails",
                column: "ActionLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_TmCharityBoxActionDetails_CharityBoxActionId",
                table: "TmCharityBoxActionDetails",
                column: "CharityBoxActionId");

            migrationBuilder.CreateIndex(
                name: "IX_TmCharityBoxActionDetails_NewCharityBoxId",
                table: "TmCharityBoxActionDetails",
                column: "NewCharityBoxId");

            migrationBuilder.CreateIndex(
                name: "IX_TmCharityBoxActionDetails_OldCharityBoxid",
                table: "TmCharityBoxActionDetails",
                column: "OldCharityBoxid");

            migrationBuilder.CreateIndex(
                name: "IX_TmCharityBoxActionDetails_StatusLkpId",
                table: "TmCharityBoxActionDetails",
                column: "StatusLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_TmCharityBoxActionDetails_TmLocationSubId",
                table: "TmCharityBoxActionDetails",
                column: "TmLocationSubId");

            migrationBuilder.CreateIndex(
                name: "IX_TmCharityBoxActions_StatusLkpId",
                table: "TmCharityBoxActions",
                column: "StatusLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_TmCharityBoxActions_TmSupervisorId",
                table: "TmCharityBoxActions",
                column: "TmSupervisorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TmCharityBoxActionDetails");

            migrationBuilder.DropTable(
                name: "TmCharityBoxActions");
        }
    }
}
