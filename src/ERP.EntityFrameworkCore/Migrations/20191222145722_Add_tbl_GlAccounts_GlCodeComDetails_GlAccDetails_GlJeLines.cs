using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class Add_tbl_GlAccounts_GlCodeComDetails_GlAccDetails_GlJeLines : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GlAccDetails",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(maxLength: 20, nullable: false),
                    NameAr = table.Column<string>(maxLength: 200, nullable: false),
                    NameEn = table.Column<string>(maxLength: 200, nullable: false),
                    GlAccHeaderId = table.Column<long>(nullable: false),
                    IsDefault = table.Column<bool>(nullable: false),
                    ParentId = table.Column<long>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GlAccDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GlAccDetails_GlAccHeaders_GlAccHeaderId",
                        column: x => x.GlAccHeaderId,
                        principalTable: "GlAccHeaders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GlAccDetails_GlAccDetails_ParentId",
                        column: x => x.ParentId,
                        principalTable: "GlAccDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GlAccounts",
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
                    Code = table.Column<string>(maxLength: 100, nullable: false),
                    DescriptionEn = table.Column<string>(maxLength: 4000, nullable: false),
                    DescriptionAr = table.Column<string>(maxLength: 4000, nullable: false),
                    TrialBalance = table.Column<bool>(nullable: false),
                    CashFlow = table.Column<bool>(nullable: false),
                    Expense = table.Column<bool>(nullable: false),
                    Revenue = table.Column<bool>(nullable: false),
                    Libility = table.Column<bool>(nullable: false),
                    Assets = table.Column<bool>(nullable: false),
                    ProfitLoss = table.Column<bool>(nullable: false),
                    BalanceSheet = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    ParentId = table.Column<long>(nullable: true),
                    NatureOfAccountLkpId = table.Column<long>(nullable: false),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GlAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GlAccounts_FndLookupValues_NatureOfAccountLkpId",
                        column: x => x.NatureOfAccountLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GlAccounts_GlAccounts_ParentId",
                        column: x => x.ParentId,
                        principalTable: "GlAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GlCodeComDetails",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Attribute1 = table.Column<long>(nullable: true),
                    Attribute2 = table.Column<long>(nullable: true),
                    Attribute3 = table.Column<long>(nullable: true),
                    Attribute4 = table.Column<long>(nullable: true),
                    Attribute5 = table.Column<long>(nullable: true),
                    Attribute6 = table.Column<long>(nullable: true),
                    Attribute7 = table.Column<long>(nullable: true),
                    Attribute8 = table.Column<long>(nullable: true),
                    Attribute9 = table.Column<long>(nullable: true),
                    AccId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GlCodeComDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GlCodeComDetails_GlAccounts_AccId",
                        column: x => x.AccId,
                        principalTable: "GlAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GlJeLines",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DebitAmount = table.Column<decimal>(nullable: false),
                    CreditAmount = table.Column<decimal>(nullable: false),
                    AccountId = table.Column<long>(nullable: false),
                    GlJeHeaderId = table.Column<long>(nullable: false),
                    JeDtlSourceLkpId = table.Column<long>(nullable: false),
                    JeSourceId = table.Column<long>(nullable: false),
                    Notes = table.Column<string>(maxLength: 4000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GlJeLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GlJeLines_GlAccounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "GlAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GlJeLines_GlJeHeaders_GlJeHeaderId",
                        column: x => x.GlJeHeaderId,
                        principalTable: "GlJeHeaders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GlJeLines_FndLookupValues_JeDtlSourceLkpId",
                        column: x => x.JeDtlSourceLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GlAccDetails_GlAccHeaderId",
                table: "GlAccDetails",
                column: "GlAccHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_GlAccDetails_ParentId",
                table: "GlAccDetails",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_GlAccounts_NatureOfAccountLkpId",
                table: "GlAccounts",
                column: "NatureOfAccountLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_GlAccounts_ParentId",
                table: "GlAccounts",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_GlCodeComDetails_AccId",
                table: "GlCodeComDetails",
                column: "AccId");

            migrationBuilder.CreateIndex(
                name: "IX_GlJeLines_AccountId",
                table: "GlJeLines",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_GlJeLines_GlJeHeaderId",
                table: "GlJeLines",
                column: "GlJeHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_GlJeLines_JeDtlSourceLkpId",
                table: "GlJeLines",
                column: "JeDtlSourceLkpId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GlAccDetails");

            migrationBuilder.DropTable(
                name: "GlCodeComDetails");

            migrationBuilder.DropTable(
                name: "GlJeLines");

            migrationBuilder.DropTable(
                name: "GlAccounts");
        }
    }
}
