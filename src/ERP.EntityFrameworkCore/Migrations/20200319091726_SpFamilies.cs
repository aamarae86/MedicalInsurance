using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class SpFamilies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SpFamilies",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    FamilyName = table.Column<string>(maxLength: 200, nullable: false),
                    FamilyNumber = table.Column<string>(maxLength: 30, nullable: false),
                    RegistrationDate = table.Column<DateTime>(nullable: false),
                    GuardianName = table.Column<string>(maxLength: 200, nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    PlaceOfBirth = table.Column<string>(maxLength: 200, nullable: true),
                    IdNumber = table.Column<string>(maxLength: 50, nullable: true),
                    IdExpirationDate = table.Column<DateTime>(nullable: true),
                    JobDescription = table.Column<string>(maxLength: 200, nullable: true),
                    Job = table.Column<string>(maxLength: 200, nullable: true),
                    IsFatherDied = table.Column<bool>(nullable: false),
                    IsMotherDied = table.Column<bool>(nullable: false),
                    IsHasHouse = table.Column<bool>(nullable: false),
                    FatherDiedDate = table.Column<DateTime>(nullable: true),
                    MotherDiedDate = table.Column<DateTime>(nullable: true),
                    FatherDiedReason = table.Column<string>(maxLength: 200, nullable: true),
                    MotherDiedReason = table.Column<string>(maxLength: 200, nullable: true),
                    Region = table.Column<string>(maxLength: 200, nullable: true),
                    Address = table.Column<string>(maxLength: 4000, nullable: true),
                    MobileNumber1 = table.Column<string>(maxLength: 50, nullable: true),
                    MobileNumber2 = table.Column<string>(maxLength: 50, nullable: true),
                    AccountNumber = table.Column<string>(maxLength: 50, nullable: true),
                    AccountOwner = table.Column<string>(maxLength: 50, nullable: true),
                    BankLkpId = table.Column<long>(nullable: true),
                    MaritalStatusLkpId = table.Column<long>(nullable: true),
                    RelativesTypeLkpId = table.Column<long>(nullable: true),
                    NationalityLkpId = table.Column<long>(nullable: true),
                    HousingTypeLkpId = table.Column<long>(nullable: true),
                    HousingStatusLkpId = table.Column<long>(nullable: true),
                    CityLkpId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpFamilies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpFamilies_FndLookupValues_BankLkpId",
                        column: x => x.BankLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SpFamilies_FndLookupValues_CityLkpId",
                        column: x => x.CityLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SpFamilies_FndLookupValues_HousingStatusLkpId",
                        column: x => x.HousingStatusLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SpFamilies_FndLookupValues_HousingTypeLkpId",
                        column: x => x.HousingTypeLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SpFamilies_FndLookupValues_MaritalStatusLkpId",
                        column: x => x.MaritalStatusLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SpFamilies_FndLookupValues_NationalityLkpId",
                        column: x => x.NationalityLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SpFamilies_FndLookupValues_RelativesTypeLkpId",
                        column: x => x.RelativesTypeLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SpFamilyDuties",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    SpFamilyId = table.Column<long>(nullable: false),
                    DutyType = table.Column<string>(maxLength: 200, nullable: false),
                    DutyDescription = table.Column<string>(maxLength: 200, nullable: true),
                    MonthlyAmount = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpFamilyDuties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpFamilyDuties_SpFamilies_SpFamilyId",
                        column: x => x.SpFamilyId,
                        principalTable: "SpFamilies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SpFamilies_BankLkpId",
                table: "SpFamilies",
                column: "BankLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_SpFamilies_CityLkpId",
                table: "SpFamilies",
                column: "CityLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_SpFamilies_HousingStatusLkpId",
                table: "SpFamilies",
                column: "HousingStatusLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_SpFamilies_HousingTypeLkpId",
                table: "SpFamilies",
                column: "HousingTypeLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_SpFamilies_MaritalStatusLkpId",
                table: "SpFamilies",
                column: "MaritalStatusLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_SpFamilies_NationalityLkpId",
                table: "SpFamilies",
                column: "NationalityLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_SpFamilies_RelativesTypeLkpId",
                table: "SpFamilies",
                column: "RelativesTypeLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_SpFamilyDuties_SpFamilyId",
                table: "SpFamilyDuties",
                column: "SpFamilyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SpFamilyDuties");

            migrationBuilder.DropTable(
                name: "SpFamilies");
        }
    }
}
