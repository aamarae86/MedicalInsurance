using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class SpContractsTblsFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SpContracts",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    ContractNumber = table.Column<string>(maxLength: 30, nullable: false),
                    ContractDate = table.Column<DateTime>(nullable: false),
                    StatusLkpId = table.Column<long>(nullable: false),
                    SpBeneficentId = table.Column<long>(nullable: false),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpContracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpContracts_SpBeneficent_SpBeneficentId",
                        column: x => x.SpBeneficentId,
                        principalTable: "SpBeneficent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpContracts_FndLookupValues_StatusLkpId",
                        column: x => x.StatusLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpContractAttachments",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    SpContractId = table.Column<long>(nullable: false),
                    AttachmentName = table.Column<string>(maxLength: 200, nullable: false),
                    FilePath = table.Column<string>(maxLength: 1000, nullable: false),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpContractAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpContractAttachments_SpContracts_SpContractId",
                        column: x => x.SpContractId,
                        principalTable: "SpContracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpContractDetails",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    SpContractId = table.Column<long>(nullable: false),
                    SpCaseId = table.Column<long>(nullable: false),
                    CaseStatusLkpId = table.Column<long>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    SponsFor = table.Column<string>(maxLength: 200, nullable: true),
                    SpBeneficentBankId = table.Column<long>(nullable: true),
                    BankLkpId = table.Column<long>(nullable: true),
                    AccountNumber = table.Column<string>(maxLength: 50, nullable: true),
                    AccountOwnerName = table.Column<string>(maxLength: 200, nullable: true),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpContractDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpContractDetails_FndLookupValues_BankLkpId",
                        column: x => x.BankLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SpContractDetails_FndLookupValues_CaseStatusLkpId",
                        column: x => x.CaseStatusLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpContractDetails_SpCases_SpCaseId",
                        column: x => x.SpCaseId,
                        principalTable: "SpCases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpContractDetails_SpContracts_SpContractId",
                        column: x => x.SpContractId,
                        principalTable: "SpContracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SpContractAttachments_SpContractId",
                table: "SpContractAttachments",
                column: "SpContractId");

            migrationBuilder.CreateIndex(
                name: "IX_SpContractDetails_BankLkpId",
                table: "SpContractDetails",
                column: "BankLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_SpContractDetails_CaseStatusLkpId",
                table: "SpContractDetails",
                column: "CaseStatusLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_SpContractDetails_SpCaseId",
                table: "SpContractDetails",
                column: "SpCaseId");

            migrationBuilder.CreateIndex(
                name: "IX_SpContractDetails_SpContractId",
                table: "SpContractDetails",
                column: "SpContractId");

            migrationBuilder.CreateIndex(
                name: "IX_SpContracts_SpBeneficentId",
                table: "SpContracts",
                column: "SpBeneficentId");

            migrationBuilder.CreateIndex(
                name: "IX_SpContracts_StatusLkpId",
                table: "SpContracts",
                column: "StatusLkpId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SpContractAttachments");

            migrationBuilder.DropTable(
                name: "SpContractDetails");

            migrationBuilder.DropTable(
                name: "SpContracts");
        }
    }
}
