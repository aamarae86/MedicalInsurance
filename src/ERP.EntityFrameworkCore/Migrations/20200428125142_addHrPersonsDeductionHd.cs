using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class addHrPersonsDeductionHd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HrPersonsDeductionHd",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    DeductionNumber = table.Column<string>(maxLength: 30, nullable: false),
                    DeductionName = table.Column<string>(maxLength: 200, nullable: false),
                    PeriodId = table.Column<long>(nullable: false),
                    StatusLkpId = table.Column<long>(nullable: false),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HrPersonsDeductionHd", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HrPersonsDeductionHd_GlPeriodsDetails_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "GlPeriodsDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HrPersonsDeductionHd_FndLookupValues_StatusLkpId",
                        column: x => x.StatusLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HrPersonsDeductionTr",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    HrPersonDeductionHdId = table.Column<long>(nullable: false),
                    HrPersonId = table.Column<long>(nullable: false),
                    DeductionTypeLkpId = table.Column<long>(nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    Notes = table.Column<string>(maxLength: 4000, nullable: true),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HrPersonsDeductionTr", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HrPersonsDeductionTr_FndLookupValues_DeductionTypeLkpId",
                        column: x => x.DeductionTypeLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HrPersonsDeductionTr_HrPersonsDeductionHd_HrPersonDeductionHdId",
                        column: x => x.HrPersonDeductionHdId,
                        principalTable: "HrPersonsDeductionHd",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HrPersonsDeductionTr_HrPersons_HrPersonId",
                        column: x => x.HrPersonId,
                        principalTable: "HrPersons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HrPersonsDeductionHd_PeriodId",
                table: "HrPersonsDeductionHd",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_HrPersonsDeductionHd_StatusLkpId",
                table: "HrPersonsDeductionHd",
                column: "StatusLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_HrPersonsDeductionTr_DeductionTypeLkpId",
                table: "HrPersonsDeductionTr",
                column: "DeductionTypeLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_HrPersonsDeductionTr_HrPersonDeductionHdId",
                table: "HrPersonsDeductionTr",
                column: "HrPersonDeductionHdId");

            migrationBuilder.CreateIndex(
                name: "IX_HrPersonsDeductionTr_HrPersonId",
                table: "HrPersonsDeductionTr",
                column: "HrPersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HrPersonsDeductionTr");

            migrationBuilder.DropTable(
                name: "HrPersonsDeductionHd");
        }
    }
}
