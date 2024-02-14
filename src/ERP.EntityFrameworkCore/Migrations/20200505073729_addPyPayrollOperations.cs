using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class addPyPayrollOperations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PyPayrollOperationPersonDetails",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    PyPayrollOperationPersonId = table.Column<long>(nullable: false),
                    SourceCodeLkpId = table.Column<long>(nullable: false),
                    SourceId = table.Column<long>(nullable: true),
                    SourceName = table.Column<string>(maxLength: 200, nullable: true),
                    EarningAmount = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    DeductionAmount = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PyPayrollOperationPersonDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PyPayrollOperationPersonDetails_FndLookupValues_SourceCodeLkpId",
                        column: x => x.SourceCodeLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PyPayrollOperations",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    OperationNumber = table.Column<string>(maxLength: 20, nullable: false),
                    OperationDate = table.Column<DateTime>(nullable: false),
                    Notes = table.Column<string>(maxLength: 4000, nullable: true),
                    StatusLkpId = table.Column<long>(nullable: false),
                    PeriodId = table.Column<long>(nullable: false),
                    PyPayrollTypeId = table.Column<long>(nullable: false),
                    HrPersonId = table.Column<long>(nullable: false),
                    JobLkpId = table.Column<long>(nullable: false),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PyPayrollOperations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PyPayrollOperations_HrPersons_HrPersonId",
                        column: x => x.HrPersonId,
                        principalTable: "HrPersons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PyPayrollOperations_FndLookupValues_JobLkpId",
                        column: x => x.JobLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PyPayrollOperations_GlPeriodsDetails_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "GlPeriodsDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PyPayrollOperations_PyPayrollTypes_PyPayrollTypeId",
                        column: x => x.PyPayrollTypeId,
                        principalTable: "PyPayrollTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PyPayrollOperations_FndLookupValues_StatusLkpId",
                        column: x => x.StatusLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "PyPayrollOperationPersons",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    PyPayrollOperationId = table.Column<long>(nullable: false),
                    BankLkpId = table.Column<long>(nullable: false),
                    HrPersonId = table.Column<long>(nullable: true),
                    AccountNumber = table.Column<string>(maxLength: 50, nullable: true),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PyPayrollOperationPersons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PyPayrollOperationPersons_FndLookupValues_BankLkpId",
                        column: x => x.BankLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PyPayrollOperationPersons_HrPersons_HrPersonId",
                        column: x => x.HrPersonId,
                        principalTable: "HrPersons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PyPayrollOperationPersons_PyPayrollOperations_PyPayrollOperationId",
                        column: x => x.PyPayrollOperationId,
                        principalTable: "PyPayrollOperations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PyPayrollOperationPersonDetails_SourceCodeLkpId",
                table: "PyPayrollOperationPersonDetails",
                column: "SourceCodeLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_PyPayrollOperationPersons_BankLkpId",
                table: "PyPayrollOperationPersons",
                column: "BankLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_PyPayrollOperationPersons_HrPersonId",
                table: "PyPayrollOperationPersons",
                column: "HrPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PyPayrollOperationPersons_PyPayrollOperationId",
                table: "PyPayrollOperationPersons",
                column: "PyPayrollOperationId");

            migrationBuilder.CreateIndex(
                name: "IX_PyPayrollOperations_HrPersonId",
                table: "PyPayrollOperations",
                column: "HrPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PyPayrollOperations_JobLkpId",
                table: "PyPayrollOperations",
                column: "JobLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_PyPayrollOperations_PeriodId",
                table: "PyPayrollOperations",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_PyPayrollOperations_PyPayrollTypeId",
                table: "PyPayrollOperations",
                column: "PyPayrollTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PyPayrollOperations_StatusLkpId",
                table: "PyPayrollOperations",
                column: "StatusLkpId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PyPayrollOperationPersonDetails");

            migrationBuilder.DropTable(
                name: "PyPayrollOperationPersons");

            migrationBuilder.DropTable(
                name: "PyPayrollOperations");
        }
    }
}
