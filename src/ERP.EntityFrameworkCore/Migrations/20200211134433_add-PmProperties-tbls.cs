using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class addPmPropertiestbls : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "FndLookupValuesId",
                table: "ScCommitteesCheck",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "FndLookupValuesId",
                table: "ScCommittees",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PmProperties",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    PropertyNameAr = table.Column<string>(maxLength: 200, nullable: false),
                    PropertyNameEn = table.Column<string>(maxLength: 200, nullable: false),
                    PropertyNumber = table.Column<string>(maxLength: 30, nullable: false),
                    LandNumber = table.Column<string>(maxLength: 30, nullable: true),
                    MilkiyaNumber = table.Column<string>(maxLength: 30, nullable: true),
                    Region = table.Column<string>(maxLength: 200, nullable: true),
                    Address = table.Column<string>(maxLength: 4000, nullable: false),
                    Notes = table.Column<string>(maxLength: 4000, nullable: true),
                    PropertyValue = table.Column<decimal>(type: "decimal(18, 6)", nullable: true),
                    CommissionPercentage = table.Column<decimal>(type: "decimal(18, 6)", nullable: false),
                    CompletionDate = table.Column<DateTime>(nullable: true),
                    NoOfFloors = table.Column<int>(nullable: true),
                    PmOwnerId = table.Column<long>(nullable: false),
                    BankAccountId = table.Column<long>(nullable: false),
                    StatusLkpId = table.Column<long>(nullable: false),
                    CountryLkpId = table.Column<long>(nullable: false),
                    CityLkpId = table.Column<long>(nullable: false),
                    CommissionTypeLkpId = table.Column<long>(nullable: false),
                    PmPurposeLkpId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PmProperties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PmProperties_ApBankAccounts_BankAccountId",
                        column: x => x.BankAccountId,
                        principalTable: "ApBankAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PmProperties_FndLookupValues_CityLkpId",
                        column: x => x.CityLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PmProperties_FndLookupValues_CommissionTypeLkpId",
                        column: x => x.CommissionTypeLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PmProperties_FndLookupValues_CountryLkpId",
                        column: x => x.CountryLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PmProperties_PmOwners_PmOwnerId",
                        column: x => x.PmOwnerId,
                        principalTable: "PmOwners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PmProperties_FndLookupValues_PmPurposeLkpId",
                        column: x => x.PmPurposeLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PmProperties_FndLookupValues_StatusLkpId",
                        column: x => x.StatusLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "PmPropertiesAttachments",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    AttachmentName = table.Column<string>(maxLength: 200, nullable: false),
                    FilePath = table.Column<string>(maxLength: 1000, nullable: false),
                    PropertyId = table.Column<long>(nullable: false),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PmPropertiesAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PmPropertiesAttachments_PmProperties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "PmProperties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PmPropertiesRevenueAccounts",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    Percentage = table.Column<decimal>(type: "decimal(18, 6)", nullable: false),
                    AccountId = table.Column<long>(nullable: false),
                    AdvanceAccountId = table.Column<long>(nullable: false),
                    PropertyId = table.Column<long>(nullable: false),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PmPropertiesRevenueAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PmPropertiesRevenueAccounts_GlCodeComDetails_AccountId",
                        column: x => x.AccountId,
                        principalTable: "GlCodeComDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PmPropertiesRevenueAccounts_GlCodeComDetails_AdvanceAccountId",
                        column: x => x.AdvanceAccountId,
                        principalTable: "GlCodeComDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PmPropertiesRevenueAccounts_PmProperties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "PmProperties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "PmPropertiesUnits",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    UnitNo = table.Column<string>(maxLength: 30, nullable: true),
                    ElectricityNumber = table.Column<string>(maxLength: 30, nullable: true),
                    SewerageNumber = table.Column<string>(maxLength: 30, nullable: true),
                    AreaSize = table.Column<decimal>(type: "decimal(18, 6)", nullable: false),
                    YearlyRent = table.Column<decimal>(type: "decimal(18, 6)", nullable: false),
                    FloorLevel = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 4000, nullable: true),
                    PmUnitTypeLkpId = table.Column<long>(nullable: false),
                    StatusLkpId = table.Column<long>(nullable: false),
                    ViewLkpId = table.Column<long>(nullable: false),
                    FinishesLkpId = table.Column<long>(nullable: false),
                    PropertyId = table.Column<long>(nullable: false),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PmPropertiesUnits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PmPropertiesUnits_FndLookupValues_FinishesLkpId",
                        column: x => x.FinishesLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PmPropertiesUnits_FndLookupValues_PmUnitTypeLkpId",
                        column: x => x.PmUnitTypeLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PmPropertiesUnits_PmProperties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "PmProperties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PmPropertiesUnits_FndLookupValues_StatusLkpId",
                        column: x => x.StatusLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PmPropertiesUnits_FndLookupValues_ViewLkpId",
                        column: x => x.ViewLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ScCommitteesCheck_FndLookupValuesId",
                table: "ScCommitteesCheck",
                column: "FndLookupValuesId");

            migrationBuilder.CreateIndex(
                name: "IX_ScCommittees_FndLookupValuesId",
                table: "ScCommittees",
                column: "FndLookupValuesId");

            migrationBuilder.CreateIndex(
                name: "IX_PmProperties_BankAccountId",
                table: "PmProperties",
                column: "BankAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_PmProperties_CityLkpId",
                table: "PmProperties",
                column: "CityLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_PmProperties_CommissionTypeLkpId",
                table: "PmProperties",
                column: "CommissionTypeLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_PmProperties_CountryLkpId",
                table: "PmProperties",
                column: "CountryLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_PmProperties_PmOwnerId",
                table: "PmProperties",
                column: "PmOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_PmProperties_PmPurposeLkpId",
                table: "PmProperties",
                column: "PmPurposeLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_PmProperties_StatusLkpId",
                table: "PmProperties",
                column: "StatusLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_PmPropertiesAttachments_PropertyId",
                table: "PmPropertiesAttachments",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_PmPropertiesRevenueAccounts_AccountId",
                table: "PmPropertiesRevenueAccounts",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_PmPropertiesRevenueAccounts_AdvanceAccountId",
                table: "PmPropertiesRevenueAccounts",
                column: "AdvanceAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_PmPropertiesRevenueAccounts_PropertyId",
                table: "PmPropertiesRevenueAccounts",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_PmPropertiesUnits_FinishesLkpId",
                table: "PmPropertiesUnits",
                column: "FinishesLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_PmPropertiesUnits_PmUnitTypeLkpId",
                table: "PmPropertiesUnits",
                column: "PmUnitTypeLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_PmPropertiesUnits_PropertyId",
                table: "PmPropertiesUnits",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_PmPropertiesUnits_StatusLkpId",
                table: "PmPropertiesUnits",
                column: "StatusLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_PmPropertiesUnits_ViewLkpId",
                table: "PmPropertiesUnits",
                column: "ViewLkpId");

            migrationBuilder.AddForeignKey(
                name: "FK_ScCommittees_FndLookupValues_FndLookupValuesId",
                table: "ScCommittees",
                column: "FndLookupValuesId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ScCommitteesCheck_FndLookupValues_FndLookupValuesId",
                table: "ScCommitteesCheck",
                column: "FndLookupValuesId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScCommittees_FndLookupValues_FndLookupValuesId",
                table: "ScCommittees");

            migrationBuilder.DropForeignKey(
                name: "FK_ScCommitteesCheck_FndLookupValues_FndLookupValuesId",
                table: "ScCommitteesCheck");

            migrationBuilder.DropTable(
                name: "PmPropertiesAttachments");

            migrationBuilder.DropTable(
                name: "PmPropertiesRevenueAccounts");

            migrationBuilder.DropTable(
                name: "PmPropertiesUnits");

            migrationBuilder.DropTable(
                name: "PmProperties");

            migrationBuilder.DropIndex(
                name: "IX_ScCommitteesCheck_FndLookupValuesId",
                table: "ScCommitteesCheck");

            migrationBuilder.DropIndex(
                name: "IX_ScCommittees_FndLookupValuesId",
                table: "ScCommittees");

            migrationBuilder.DropColumn(
                name: "FndLookupValuesId",
                table: "ScCommitteesCheck");

            migrationBuilder.DropColumn(
                name: "FndLookupValuesId",
                table: "ScCommittees");
        }
    }
}
