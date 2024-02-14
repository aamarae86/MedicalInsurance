using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class addNewTblsSpPayments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SpCasesPaymentDeserving",
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
                    DeservingNumber = table.Column<string>(maxLength: 30, nullable: false),
                    DeservingDate = table.Column<DateTime>(nullable: false),
                    SpContractDetailsId = table.Column<long>(nullable: false),
                    DeservingPeriodId = table.Column<long>(nullable: false),
                    CaseStatusLkpId = table.Column<long>(nullable: false),
                    StatusLkpId = table.Column<long>(nullable: false),
                    DeservingAmount = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    Notes = table.Column<string>(maxLength: 4000, nullable: true),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpCasesPaymentDeserving", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpCasesPaymentDeserving_FndLookupValues_CaseStatusLkpId",
                        column: x => x.CaseStatusLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpCasesPaymentDeserving_GlPeriodsDetails_DeservingPeriodId",
                        column: x => x.DeservingPeriodId,
                        principalTable: "GlPeriodsDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpCasesPaymentDeserving_SpContractDetails_SpContractDetailsId",
                        column: x => x.SpContractDetailsId,
                        principalTable: "SpContractDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_SpCasesPaymentDeserving_FndLookupValues_StatusLkpId",
                        column: x => x.StatusLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "SpPayments",
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
                    PaymentNumber = table.Column<string>(maxLength: 30, nullable: false),
                    StatusLkpId = table.Column<long>(nullable: false),
                    FromPeriodId = table.Column<long>(nullable: false),
                    ToPeriodId = table.Column<long>(nullable: false),
                    SponsorCategoryLkpId = table.Column<long>(nullable: true),
                    SpCaseId = table.Column<long>(nullable: true),
                    Notes = table.Column<string>(maxLength: 4000, nullable: true),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpPayments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpPayments_GlPeriodsDetails_FromPeriodId",
                        column: x => x.FromPeriodId,
                        principalTable: "GlPeriodsDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpPayments_SpCases_SpCaseId",
                        column: x => x.SpCaseId,
                        principalTable: "SpCases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SpPayments_FndLookupValues_SponsorCategoryLkpId",
                        column: x => x.SponsorCategoryLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SpPayments_FndLookupValues_StatusLkpId",
                        column: x => x.StatusLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpPayments_GlPeriodsDetails_ToPeriodId",
                        column: x => x.ToPeriodId,
                        principalTable: "GlPeriodsDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "SpPaymentPersons",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    SpPaymentId = table.Column<long>(nullable: false),
                    SpCasesPaymentDeservingId = table.Column<long>(nullable: true),
                    SpCaseId = table.Column<long>(nullable: false),
                    CaseStatusLkpId = table.Column<long>(nullable: false),
                    SponsorCategoryLkpId = table.Column<long>(nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpPaymentPersons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpPaymentPersons_FndLookupValues_CaseStatusLkpId",
                        column: x => x.CaseStatusLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpPaymentPersons_SpCases_SpCaseId",
                        column: x => x.SpCaseId,
                        principalTable: "SpCases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpPaymentPersons_SpCasesPaymentDeserving_SpCasesPaymentDeservingId",
                        column: x => x.SpCasesPaymentDeservingId,
                        principalTable: "SpCasesPaymentDeserving",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SpPaymentPersons_SpPayments_SpPaymentId",
                        column: x => x.SpPaymentId,
                        principalTable: "SpPayments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_SpPaymentPersons_FndLookupValues_SponsorCategoryLkpId",
                        column: x => x.SponsorCategoryLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "SpPaymentPersonDetails",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    SpPaymentPersonId = table.Column<long>(nullable: false),
                    SpContractDetailsId = table.Column<long>(nullable: false),
                    PeriodId = table.Column<long>(nullable: false),
                    SpCasesPaymentDeservingId = table.Column<long>(nullable: true),
                    ContractStartDate = table.Column<DateTime>(nullable: false),
                    ContractEndDate = table.Column<DateTime>(nullable: false),
                    ContractAmount = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    ManagementPercentage = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpPaymentPersonDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpPaymentPersonDetails_GlPeriodsDetails_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "GlPeriodsDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpPaymentPersonDetails_SpCasesPaymentDeserving_SpCasesPaymentDeservingId",
                        column: x => x.SpCasesPaymentDeservingId,
                        principalTable: "SpCasesPaymentDeserving",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SpPaymentPersonDetails_SpContractDetails_SpContractDetailsId",
                        column: x => x.SpContractDetailsId,
                        principalTable: "SpContractDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpPaymentPersonDetails_SpPaymentPersons_SpPaymentPersonId",
                        column: x => x.SpPaymentPersonId,
                        principalTable: "SpPaymentPersons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SpCasesPaymentDeserving_CaseStatusLkpId",
                table: "SpCasesPaymentDeserving",
                column: "CaseStatusLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_SpCasesPaymentDeserving_DeservingPeriodId",
                table: "SpCasesPaymentDeserving",
                column: "DeservingPeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_SpCasesPaymentDeserving_SpContractDetailsId",
                table: "SpCasesPaymentDeserving",
                column: "SpContractDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_SpCasesPaymentDeserving_StatusLkpId",
                table: "SpCasesPaymentDeserving",
                column: "StatusLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_SpPaymentPersonDetails_PeriodId",
                table: "SpPaymentPersonDetails",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_SpPaymentPersonDetails_SpCasesPaymentDeservingId",
                table: "SpPaymentPersonDetails",
                column: "SpCasesPaymentDeservingId");

            migrationBuilder.CreateIndex(
                name: "IX_SpPaymentPersonDetails_SpContractDetailsId",
                table: "SpPaymentPersonDetails",
                column: "SpContractDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_SpPaymentPersonDetails_SpPaymentPersonId",
                table: "SpPaymentPersonDetails",
                column: "SpPaymentPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_SpPaymentPersons_CaseStatusLkpId",
                table: "SpPaymentPersons",
                column: "CaseStatusLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_SpPaymentPersons_SpCaseId",
                table: "SpPaymentPersons",
                column: "SpCaseId");

            migrationBuilder.CreateIndex(
                name: "IX_SpPaymentPersons_SpCasesPaymentDeservingId",
                table: "SpPaymentPersons",
                column: "SpCasesPaymentDeservingId");

            migrationBuilder.CreateIndex(
                name: "IX_SpPaymentPersons_SpPaymentId",
                table: "SpPaymentPersons",
                column: "SpPaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_SpPaymentPersons_SponsorCategoryLkpId",
                table: "SpPaymentPersons",
                column: "SponsorCategoryLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_SpPayments_FromPeriodId",
                table: "SpPayments",
                column: "FromPeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_SpPayments_SpCaseId",
                table: "SpPayments",
                column: "SpCaseId");

            migrationBuilder.CreateIndex(
                name: "IX_SpPayments_SponsorCategoryLkpId",
                table: "SpPayments",
                column: "SponsorCategoryLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_SpPayments_StatusLkpId",
                table: "SpPayments",
                column: "StatusLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_SpPayments_ToPeriodId",
                table: "SpPayments",
                column: "ToPeriodId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SpPaymentPersonDetails");

            migrationBuilder.DropTable(
                name: "SpPaymentPersons");

            migrationBuilder.DropTable(
                name: "SpCasesPaymentDeserving");

            migrationBuilder.DropTable(
                name: "SpPayments");
        }
    }
}
