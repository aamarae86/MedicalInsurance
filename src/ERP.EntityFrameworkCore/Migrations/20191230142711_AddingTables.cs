using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class AddingTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArMiscReceiptHeaders",
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
                    ReceiptNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    MiscReceiptDate = table.Column<DateTime>(nullable: true),
                    BankAccountId = table.Column<long>(nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    PostedLkpId = table.Column<long>(nullable: true),
                    TransactionTypeLkpId = table.Column<long>(nullable: true),
                    CollectorId = table.Column<long>(nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18, 6)", nullable: true),
                    ManualReceiptNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BeneficentId = table.Column<long>(nullable: true),
                    SourceCodeLkpId = table.Column<long>(nullable: true),
                    SourceId = table.Column<long>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArMiscReceiptHeaders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArMiscReceiptHeaders_ApBankAccounts_BankAccountId",
                        column: x => x.BankAccountId,
                        principalTable: "ApBankAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ArMiscReceiptHeaders_FndLookupValues_PostedLkpId",
                        column: x => x.PostedLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ArMiscReceiptHeaders_FndLookupValues_SourceCodeLkpId",
                        column: x => x.SourceCodeLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ArMiscReceiptHeaders_FndLookupValues_TransactionTypeLkpId",
                        column: x => x.TransactionTypeLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ArMiscReceiptLines",
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
                    MiscReceiptId = table.Column<long>(nullable: true),
                    MiscReceiptAmount = table.Column<decimal>(type: "decimal(18, 6)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    ReceiptTypeLkpId = table.Column<long>(nullable: true),
                    CaseId = table.Column<long>(nullable: true),
                    AccountId = table.Column<long>(nullable: true),
                    ManualReceiptNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SourceCodeLkpId = table.Column<long>(nullable: true),
                    SourceId = table.Column<long>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArMiscReceiptLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArMiscReceiptLines_GlCodeComDetails_AccountId",
                        column: x => x.AccountId,
                        principalTable: "GlCodeComDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ArMiscReceiptLines_ArMiscReceiptHeaders_MiscReceiptId",
                        column: x => x.MiscReceiptId,
                        principalTable: "ArMiscReceiptHeaders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ArMiscReceiptLines_FndLookupValues_ReceiptTypeLkpId",
                        column: x => x.ReceiptTypeLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ArMiscReceiptLines_FndLookupValues_SourceCodeLkpId",
                        column: x => x.SourceCodeLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArMiscReceiptHeaders_BankAccountId",
                table: "ArMiscReceiptHeaders",
                column: "BankAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_ArMiscReceiptHeaders_PostedLkpId",
                table: "ArMiscReceiptHeaders",
                column: "PostedLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_ArMiscReceiptHeaders_SourceCodeLkpId",
                table: "ArMiscReceiptHeaders",
                column: "SourceCodeLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_ArMiscReceiptHeaders_TransactionTypeLkpId",
                table: "ArMiscReceiptHeaders",
                column: "TransactionTypeLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_ArMiscReceiptLines_AccountId",
                table: "ArMiscReceiptLines",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_ArMiscReceiptLines_MiscReceiptId",
                table: "ArMiscReceiptLines",
                column: "MiscReceiptId");

            migrationBuilder.CreateIndex(
                name: "IX_ArMiscReceiptLines_ReceiptTypeLkpId",
                table: "ArMiscReceiptLines",
                column: "ReceiptTypeLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_ArMiscReceiptLines_SourceCodeLkpId",
                table: "ArMiscReceiptLines",
                column: "SourceCodeLkpId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArMiscReceiptLines");

            migrationBuilder.DropTable(
                name: "ArMiscReceiptHeaders");
        }
    }
}
