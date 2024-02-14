using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class addingTablesSpCasesAndItsAttachment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SpCases",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    CaseName = table.Column<string>(maxLength: 200, nullable: true),
                    CaseNumber = table.Column<string>(maxLength: 20, nullable: true),
                    RegistrationDate = table.Column<DateTime>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: true),
                    PlaceOfBirth = table.Column<string>(maxLength: 200, nullable: true),
                    NationalityLkpId = table.Column<long>(nullable: true),
                    MaritalStatusLkpId = table.Column<long>(nullable: true),
                    SpFamilyId = table.Column<long>(nullable: true),
                    HealthStatusLkpId = table.Column<long>(nullable: true),
                    TypeOfDisease = table.Column<string>(maxLength: 200, nullable: true),
                    TypeOfTreatment = table.Column<string>(maxLength: 200, nullable: true),
                    DescriptionOfHealthCondition = table.Column<string>(maxLength: 4000, nullable: true),
                    IsStudy = table.Column<bool>(nullable: true),
                    SchoolUniversityName = table.Column<string>(maxLength: 200, nullable: true),
                    EducationalLevelLkpId = table.Column<long>(nullable: true),
                    EducationalStageLkpId = table.Column<long>(nullable: true),
                    MonthlyInstallment = table.Column<decimal>(type: "decimal(18, 6)", nullable: true),
                    SupervisorComments = table.Column<string>(maxLength: 4000, nullable: true),
                    Casephoto = table.Column<string>(maxLength: 200, nullable: true),
                    SponsorCategoryLkpId = table.Column<long>(nullable: true),
                    IdNumber = table.Column<string>(maxLength: 50, nullable: true),
                    IdExpirationDate = table.Column<DateTime>(nullable: true),
                    GenderLkpId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpCases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpCases_FndLookupValues_EducationalLevelLkpId",
                        column: x => x.EducationalLevelLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SpCases_FndLookupValues_EducationalStageLkpId",
                        column: x => x.EducationalStageLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SpCases_FndLookupValues_GenderLkpId",
                        column: x => x.GenderLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SpCases_FndLookupValues_HealthStatusLkpId",
                        column: x => x.HealthStatusLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SpCases_FndLookupValues_MaritalStatusLkpId",
                        column: x => x.MaritalStatusLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SpCases_FndLookupValues_NationalityLkpId",
                        column: x => x.NationalityLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SpCases_FndLookupValues_SponsorCategoryLkpId",
                        column: x => x.SponsorCategoryLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SpCasesAttachments",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    SpCaseId = table.Column<long>(nullable: true),
                    AttachmentName = table.Column<string>(maxLength: 200, nullable: true),
                    FilePath = table.Column<string>(maxLength: 1000, nullable: true),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpCasesAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpCasesAttachments_SpCases_SpCaseId",
                        column: x => x.SpCaseId,
                        principalTable: "SpCases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SpCases_EducationalLevelLkpId",
                table: "SpCases",
                column: "EducationalLevelLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_SpCases_EducationalStageLkpId",
                table: "SpCases",
                column: "EducationalStageLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_SpCases_GenderLkpId",
                table: "SpCases",
                column: "GenderLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_SpCases_HealthStatusLkpId",
                table: "SpCases",
                column: "HealthStatusLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_SpCases_MaritalStatusLkpId",
                table: "SpCases",
                column: "MaritalStatusLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_SpCases_NationalityLkpId",
                table: "SpCases",
                column: "NationalityLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_SpCases_SponsorCategoryLkpId",
                table: "SpCases",
                column: "SponsorCategoryLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_SpCasesAttachments_SpCaseId",
                table: "SpCasesAttachments",
                column: "SpCaseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SpCasesAttachments");

            migrationBuilder.DropTable(
                name: "SpCases");
        }
    }
}
