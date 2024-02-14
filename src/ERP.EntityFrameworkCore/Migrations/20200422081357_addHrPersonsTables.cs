using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class addHrPersonsTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HrPersons",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    EmployeeNumber = table.Column<string>(maxLength: 30, nullable: false),
                    FirstName = table.Column<string>(maxLength: 200, nullable: false),
                    FatherName = table.Column<string>(maxLength: 200, nullable: false),
                    LastName = table.Column<string>(maxLength: 200, nullable: true),
                    PlaceOfBirth = table.Column<string>(maxLength: 200, nullable: true),
                    EmailAddress = table.Column<string>(maxLength: 256, nullable: true),
                    PersonPhoto = table.Column<string>(maxLength: 200, nullable: true),
                    AccountNumber = table.Column<string>(maxLength: 50, nullable: true),
                    HireDate = table.Column<DateTime>(nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    ProbationEndDate = table.Column<DateTime>(nullable: true),
                    ProbationLength = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    NoOfTickets = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    TicketAfterYears = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    TicketAmount = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    NoticeLength = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    HrOrganizationsDeptId = table.Column<long>(nullable: false),
                    HrOrganizationsBranchId = table.Column<long>(nullable: false),
                    HrPersonSupervisorId = table.Column<long>(nullable: true),
                    PyPayrollTypeId = table.Column<long>(nullable: false),
                    GenderLkpId = table.Column<long>(nullable: false),
                    PersonTypeLkpId = table.Column<long>(nullable: false),
                    NationalityLkpId = table.Column<long>(nullable: false),
                    MaritalStatusLkpId = table.Column<long>(nullable: false),
                    StatusLkpId = table.Column<long>(nullable: false),
                    JobGradeLkpId = table.Column<long>(nullable: false),
                    JobLkpId = table.Column<long>(nullable: false),
                    PersonCategoryLkpId = table.Column<long>(nullable: false),
                    FirstTitleLkpId = table.Column<long>(nullable: true),
                    SponserLkpId = table.Column<long>(nullable: true),
                    CountryOfBrithLkpId = table.Column<long>(nullable: true),
                    ProbationUnitLkpId = table.Column<long>(nullable: true),
                    DestinationCountryLkpId = table.Column<long>(nullable: true),
                    TicketClassLkpId = table.Column<long>(nullable: true),
                    NoticeUnitLkpId = table.Column<long>(nullable: true),
                    PaymentTypeLkpId = table.Column<long>(nullable: true),
                    BankLkpId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HrPersons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HrPersons_FndLookupValues_BankLkpId",
                        column: x => x.BankLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HrPersons_FndLookupValues_CountryOfBrithLkpId",
                        column: x => x.CountryOfBrithLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HrPersons_FndLookupValues_DestinationCountryLkpId",
                        column: x => x.DestinationCountryLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HrPersons_FndLookupValues_FirstTitleLkpId",
                        column: x => x.FirstTitleLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HrPersons_FndLookupValues_GenderLkpId",
                        column: x => x.GenderLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HrPersons_HrOrganizations_HrOrganizationsBranchId",
                        column: x => x.HrOrganizationsBranchId,
                        principalTable: "HrOrganizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HrPersons_HrOrganizations_HrOrganizationsDeptId",
                        column: x => x.HrOrganizationsDeptId,
                        principalTable: "HrOrganizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HrPersons_HrPersons_HrPersonSupervisorId",
                        column: x => x.HrPersonSupervisorId,
                        principalTable: "HrPersons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HrPersons_FndLookupValues_JobGradeLkpId",
                        column: x => x.JobGradeLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HrPersons_FndLookupValues_JobLkpId",
                        column: x => x.JobLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HrPersons_FndLookupValues_MaritalStatusLkpId",
                        column: x => x.MaritalStatusLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HrPersons_FndLookupValues_NationalityLkpId",
                        column: x => x.NationalityLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HrPersons_FndLookupValues_NoticeUnitLkpId",
                        column: x => x.NoticeUnitLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HrPersons_FndLookupValues_PaymentTypeLkpId",
                        column: x => x.PaymentTypeLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HrPersons_FndLookupValues_PersonCategoryLkpId",
                        column: x => x.PersonCategoryLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HrPersons_FndLookupValues_PersonTypeLkpId",
                        column: x => x.PersonTypeLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HrPersons_FndLookupValues_ProbationUnitLkpId",
                        column: x => x.ProbationUnitLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HrPersons_PyPayrollTypes_PyPayrollTypeId",
                        column: x => x.PyPayrollTypeId,
                        principalTable: "PyPayrollTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HrPersons_FndLookupValues_SponserLkpId",
                        column: x => x.SponserLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HrPersons_FndLookupValues_StatusLkpId",
                        column: x => x.StatusLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HrPersons_FndLookupValues_TicketClassLkpId",
                        column: x => x.TicketClassLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HrPersonIdentityCard",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    Segment1 = table.Column<string>(maxLength: 3, nullable: true),
                    Segment2 = table.Column<string>(maxLength: 4, nullable: true),
                    Segment3 = table.Column<string>(maxLength: 7, nullable: true),
                    Segment4 = table.Column<string>(maxLength: 1, nullable: true),
                    IdNumber = table.Column<string>(maxLength: 50, nullable: true),
                    CardNo = table.Column<string>(maxLength: 50, nullable: true),
                    Notes = table.Column<string>(maxLength: 4000, nullable: true),
                    HrPersonId = table.Column<long>(nullable: false),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HrPersonIdentityCard", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HrPersonIdentityCard_HrPersons_HrPersonId",
                        column: x => x.HrPersonId,
                        principalTable: "HrPersons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HrPersonPassportDetails",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    PassportNumber = table.Column<string>(maxLength: 100, nullable: false),
                    PlaceOfIssue = table.Column<string>(maxLength: 200, nullable: false),
                    Notes = table.Column<string>(maxLength: 4000, nullable: true),
                    DateOfIssue = table.Column<DateTime>(nullable: false),
                    DateOfExpiry = table.Column<DateTime>(nullable: false),
                    HrPersonId = table.Column<long>(nullable: false),
                    PassportTypeLkpId = table.Column<long>(nullable: false),
                    CountryOfIssueLkpId = table.Column<long>(nullable: false),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HrPersonPassportDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HrPersonPassportDetails_FndLookupValues_CountryOfIssueLkpId",
                        column: x => x.CountryOfIssueLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HrPersonPassportDetails_HrPersons_HrPersonId",
                        column: x => x.HrPersonId,
                        principalTable: "HrPersons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HrPersonPassportDetails_FndLookupValues_PassportTypeLkpId",
                        column: x => x.PassportTypeLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "HrPersonVisaDetails",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    VisaNumber = table.Column<string>(maxLength: 100, nullable: false),
                    Notes = table.Column<string>(maxLength: 4000, nullable: true),
                    VisaCost = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    DateOfIssue = table.Column<DateTime>(nullable: false),
                    DateOfExpiry = table.Column<DateTime>(nullable: false),
                    HrPersonId = table.Column<long>(nullable: false),
                    VisaTypeLkpId = table.Column<long>(nullable: false),
                    PlaceOfIssueLkpId = table.Column<long>(nullable: true),
                    IssuedByLkpId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HrPersonVisaDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HrPersonVisaDetails_HrPersons_HrPersonId",
                        column: x => x.HrPersonId,
                        principalTable: "HrPersons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HrPersonVisaDetails_FndLookupValues_IssuedByLkpId",
                        column: x => x.IssuedByLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HrPersonVisaDetails_FndLookupValues_PlaceOfIssueLkpId",
                        column: x => x.PlaceOfIssueLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HrPersonVisaDetails_FndLookupValues_VisaTypeLkpId",
                        column: x => x.VisaTypeLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HrPersonIdentityCard_HrPersonId",
                table: "HrPersonIdentityCard",
                column: "HrPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_HrPersonPassportDetails_CountryOfIssueLkpId",
                table: "HrPersonPassportDetails",
                column: "CountryOfIssueLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_HrPersonPassportDetails_HrPersonId",
                table: "HrPersonPassportDetails",
                column: "HrPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_HrPersonPassportDetails_PassportTypeLkpId",
                table: "HrPersonPassportDetails",
                column: "PassportTypeLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_HrPersons_BankLkpId",
                table: "HrPersons",
                column: "BankLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_HrPersons_CountryOfBrithLkpId",
                table: "HrPersons",
                column: "CountryOfBrithLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_HrPersons_DestinationCountryLkpId",
                table: "HrPersons",
                column: "DestinationCountryLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_HrPersons_FirstTitleLkpId",
                table: "HrPersons",
                column: "FirstTitleLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_HrPersons_GenderLkpId",
                table: "HrPersons",
                column: "GenderLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_HrPersons_HrOrganizationsBranchId",
                table: "HrPersons",
                column: "HrOrganizationsBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_HrPersons_HrOrganizationsDeptId",
                table: "HrPersons",
                column: "HrOrganizationsDeptId");

            migrationBuilder.CreateIndex(
                name: "IX_HrPersons_HrPersonSupervisorId",
                table: "HrPersons",
                column: "HrPersonSupervisorId");

            migrationBuilder.CreateIndex(
                name: "IX_HrPersons_JobGradeLkpId",
                table: "HrPersons",
                column: "JobGradeLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_HrPersons_JobLkpId",
                table: "HrPersons",
                column: "JobLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_HrPersons_MaritalStatusLkpId",
                table: "HrPersons",
                column: "MaritalStatusLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_HrPersons_NationalityLkpId",
                table: "HrPersons",
                column: "NationalityLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_HrPersons_NoticeUnitLkpId",
                table: "HrPersons",
                column: "NoticeUnitLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_HrPersons_PaymentTypeLkpId",
                table: "HrPersons",
                column: "PaymentTypeLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_HrPersons_PersonCategoryLkpId",
                table: "HrPersons",
                column: "PersonCategoryLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_HrPersons_PersonTypeLkpId",
                table: "HrPersons",
                column: "PersonTypeLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_HrPersons_ProbationUnitLkpId",
                table: "HrPersons",
                column: "ProbationUnitLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_HrPersons_PyPayrollTypeId",
                table: "HrPersons",
                column: "PyPayrollTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_HrPersons_SponserLkpId",
                table: "HrPersons",
                column: "SponserLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_HrPersons_StatusLkpId",
                table: "HrPersons",
                column: "StatusLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_HrPersons_TicketClassLkpId",
                table: "HrPersons",
                column: "TicketClassLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_HrPersonVisaDetails_HrPersonId",
                table: "HrPersonVisaDetails",
                column: "HrPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_HrPersonVisaDetails_IssuedByLkpId",
                table: "HrPersonVisaDetails",
                column: "IssuedByLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_HrPersonVisaDetails_PlaceOfIssueLkpId",
                table: "HrPersonVisaDetails",
                column: "PlaceOfIssueLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_HrPersonVisaDetails_VisaTypeLkpId",
                table: "HrPersonVisaDetails",
                column: "VisaTypeLkpId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HrPersonIdentityCard");

            migrationBuilder.DropTable(
                name: "HrPersonPassportDetails");

            migrationBuilder.DropTable(
                name: "HrPersonVisaDetails");

            migrationBuilder.DropTable(
                name: "HrPersons");
        }
    }
}
