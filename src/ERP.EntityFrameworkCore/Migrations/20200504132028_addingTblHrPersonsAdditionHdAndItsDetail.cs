using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class addingTblHrPersonsAdditionHdAndItsDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HrPersonsAdditionHd",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    AdditionNumber = table.Column<string>(maxLength: 30, nullable: true),
                    AdditionName = table.Column<string>(maxLength: 200, nullable: true),
                    PeriodId = table.Column<long>(nullable: true),
                    StatusLkpId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HrPersonsAdditionHd", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HrPersonsAdditionHd_GlPeriodsDetails_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "GlPeriodsDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HrPersonsAdditionHd_FndLookupValues_StatusLkpId",
                        column: x => x.StatusLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HrPersonsAdditionTr",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    HrPersonAdditionHdId = table.Column<long>(nullable: true),
                    HrPersonId = table.Column<long>(nullable: true),
                    AdditionTypeLkpId = table.Column<long>(nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18, 6)", nullable: true),
                    Notes = table.Column<string>(maxLength: 4000, nullable: true),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HrPersonsAdditionTr", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HrPersonsAdditionTr_FndLookupValues_AdditionTypeLkpId",
                        column: x => x.AdditionTypeLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HrPersonsAdditionTr_HrPersonsAdditionHd_HrPersonAdditionHdId",
                        column: x => x.HrPersonAdditionHdId,
                        principalTable: "HrPersonsAdditionHd",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HrPersonsAdditionTr_HrPersons_HrPersonId",
                        column: x => x.HrPersonId,
                        principalTable: "HrPersons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HrPersonsAdditionHd_PeriodId",
                table: "HrPersonsAdditionHd",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_HrPersonsAdditionHd_StatusLkpId",
                table: "HrPersonsAdditionHd",
                column: "StatusLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_HrPersonsAdditionTr_AdditionTypeLkpId",
                table: "HrPersonsAdditionTr",
                column: "AdditionTypeLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_HrPersonsAdditionTr_HrPersonAdditionHdId",
                table: "HrPersonsAdditionTr",
                column: "HrPersonAdditionHdId");

            migrationBuilder.CreateIndex(
                name: "IX_HrPersonsAdditionTr_HrPersonId",
                table: "HrPersonsAdditionTr",
                column: "HrPersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HrPersonsAdditionTr");

            migrationBuilder.DropTable(
                name: "HrPersonsAdditionHd");
        }
    }
}
