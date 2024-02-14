using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class PmOwners_Tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PmOwners",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    OwnerNumber = table.Column<string>(maxLength: 30, nullable: false),
                    OwnerNameAr = table.Column<string>(maxLength: 200, nullable: false),
                    OwnerNameEn = table.Column<string>(maxLength: 200, nullable: false),
                    StatusLkpId = table.Column<long>(nullable: false),
                    IdNumber = table.Column<string>(maxLength: 50, nullable: true),
                    TaxNumber = table.Column<string>(maxLength: 100, nullable: false),
                    NationalityLkpId = table.Column<long>(nullable: false),
                    CountryLkpId = table.Column<long>(nullable: false),
                    CityLkpId = table.Column<long>(nullable: false),
                    Address = table.Column<string>(maxLength: 4000, nullable: true),
                    HomePhoneNumber = table.Column<string>(maxLength: 32, nullable: true),
                    MobileNumber = table.Column<string>(maxLength: 32, nullable: true),
                    WorkPhoneNumber = table.Column<string>(maxLength: 32, nullable: true),
                    Fax = table.Column<string>(maxLength: 32, nullable: true),
                    Website = table.Column<string>(maxLength: 256, nullable: true),
                    EmailAddress = table.Column<string>(maxLength: 256, nullable: true),
                    JobName = table.Column<string>(maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(maxLength: 200, nullable: true),
                    PoBox = table.Column<string>(maxLength: 100, nullable: true),
                    OtherAddress = table.Column<string>(maxLength: 4000, nullable: true),
                    Notes = table.Column<string>(maxLength: 4000, nullable: true),
                    AccountId = table.Column<long>(nullable: false),
                    CurrentAccountId = table.Column<long>(nullable: false),
                    BankAccountId = table.Column<long>(nullable: false),
                    CashAccountId = table.Column<long>(nullable: false),
                    IsMainOwner = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PmOwners", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PmOwners_GlCodeComDetails_AccountId",
                        column: x => x.AccountId,
                        principalTable: "GlCodeComDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PmOwners_GlCodeComDetails_BankAccountId",
                        column: x => x.BankAccountId,
                        principalTable: "GlCodeComDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PmOwners_GlCodeComDetails_CashAccountId",
                        column: x => x.CashAccountId,
                        principalTable: "GlCodeComDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PmOwners_FndLookupValues_CityLkpId",
                        column: x => x.CityLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PmOwners_FndLookupValues_CountryLkpId",
                        column: x => x.CountryLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PmOwners_GlCodeComDetails_CurrentAccountId",
                        column: x => x.CurrentAccountId,
                        principalTable: "GlCodeComDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PmOwners_FndLookupValues_NationalityLkpId",
                        column: x => x.NationalityLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PmOwners_FndLookupValues_StatusLkpId",
                        column: x => x.StatusLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PmOwnersTaxDetails",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    PmOwnerId = table.Column<long>(nullable: false),
                    PmActivityTypeLkpId = table.Column<long>(nullable: false),
                    TaxPercentage = table.Column<decimal>(type: "decimal(18, 6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PmOwnersTaxDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PmOwnersTaxDetails_FndLookupValues_PmActivityTypeLkpId",
                        column: x => x.PmActivityTypeLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PmOwnersTaxDetails_PmOwners_PmOwnerId",
                        column: x => x.PmOwnerId,
                        principalTable: "PmOwners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PmOwners_AccountId",
                table: "PmOwners",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_PmOwners_BankAccountId",
                table: "PmOwners",
                column: "BankAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_PmOwners_CashAccountId",
                table: "PmOwners",
                column: "CashAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_PmOwners_CityLkpId",
                table: "PmOwners",
                column: "CityLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_PmOwners_CountryLkpId",
                table: "PmOwners",
                column: "CountryLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_PmOwners_CurrentAccountId",
                table: "PmOwners",
                column: "CurrentAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_PmOwners_NationalityLkpId",
                table: "PmOwners",
                column: "NationalityLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_PmOwners_StatusLkpId",
                table: "PmOwners",
                column: "StatusLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_PmOwnersTaxDetails_PmActivityTypeLkpId",
                table: "PmOwnersTaxDetails",
                column: "PmActivityTypeLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_PmOwnersTaxDetails_PmOwnerId",
                table: "PmOwnersTaxDetails",
                column: "PmOwnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PmOwnersTaxDetails");

            migrationBuilder.DropTable(
                name: "PmOwners");
        }
    }
}
