using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class AddingTablesForSPs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApBanks",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    BankNameAr = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    BankNameEn = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    BankTypeLkpId = table.Column<long>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApBanks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApBanks_FndLookupValues_BankTypeLkpId",
                        column: x => x.BankTypeLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApVendors",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    VendorNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 200, nullable: false),
                    VendorNameAr = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    VendorNameEn = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    StatusLkpId = table.Column<long>(nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    WorkTel = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    VendorCategoryLkpId = table.Column<long>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApVendors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApVendors_FndLookupValues_StatusLkpId",
                        column: x => x.StatusLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApVendors_FndLookupValues_VendorCategoryLkpId",
                        column: x => x.VendorCategoryLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GlMainAccounts",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    AccountId = table.Column<long>(nullable: false),
                    ReferenceCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GlMainAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GlMainAccounts_GlCodeComDetails_AccountId",
                        column: x => x.AccountId,
                        principalTable: "GlCodeComDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApBankAccounts",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    BankAccountNameAr = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BankAccountNameEn = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CurrencyId = table.Column<int>(nullable: false),
                    CurrencyRate = table.Column<decimal>(type: "decimal(18, 6)", nullable: false),
                    AccountId = table.Column<long>(nullable: true),
                    cPdcAccountId = table.Column<long>(nullable: true),
                    PdcCollAccountId = table.Column<long>(nullable: true),
                    ApPdcCollAccountId = table.Column<long>(nullable: true),
                    BankId = table.Column<long>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApBankAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApBankAccounts_GlCodeComDetails_AccountId",
                        column: x => x.AccountId,
                        principalTable: "GlCodeComDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApBankAccounts_GlCodeComDetails_ApPdcCollAccountId",
                        column: x => x.ApPdcCollAccountId,
                        principalTable: "GlCodeComDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApBankAccounts_ApBanks_BankId",
                        column: x => x.BankId,
                        principalTable: "ApBanks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApBankAccounts_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApBankAccounts_GlCodeComDetails_PdcCollAccountId",
                        column: x => x.PdcCollAccountId,
                        principalTable: "GlCodeComDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApBankAccounts_GlCodeComDetails_cPdcAccountId",
                        column: x => x.cPdcAccountId,
                        principalTable: "GlCodeComDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ApUserBankAccess",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    BankAccountId = table.Column<long>(nullable: true),
                    IsPrimaryCash = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<long>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApUserBankAccess", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApUserBankAccess_ApBankAccounts_BankAccountId",
                        column: x => x.BankAccountId,
                        principalTable: "ApBankAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApBankAccounts_AccountId",
                table: "ApBankAccounts",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_ApBankAccounts_ApPdcCollAccountId",
                table: "ApBankAccounts",
                column: "ApPdcCollAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_ApBankAccounts_BankId",
                table: "ApBankAccounts",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_ApBankAccounts_CurrencyId",
                table: "ApBankAccounts",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_ApBankAccounts_PdcCollAccountId",
                table: "ApBankAccounts",
                column: "PdcCollAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_ApBankAccounts_cPdcAccountId",
                table: "ApBankAccounts",
                column: "cPdcAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_ApBanks_BankTypeLkpId",
                table: "ApBanks",
                column: "BankTypeLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_ApUserBankAccess_BankAccountId",
                table: "ApUserBankAccess",
                column: "BankAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_ApVendors_StatusLkpId",
                table: "ApVendors",
                column: "StatusLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_ApVendors_VendorCategoryLkpId",
                table: "ApVendors",
                column: "VendorCategoryLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_GlMainAccounts_AccountId",
                table: "GlMainAccounts",
                column: "AccountId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApUserBankAccess");

            migrationBuilder.DropTable(
                name: "ApVendors");

            migrationBuilder.DropTable(
                name: "GlMainAccounts");

            migrationBuilder.DropTable(
                name: "ApBankAccounts");

            migrationBuilder.DropTable(
                name: "ApBanks");
        }
    }
}
