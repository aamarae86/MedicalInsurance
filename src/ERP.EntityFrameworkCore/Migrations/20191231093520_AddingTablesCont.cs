using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class AddingTablesCont : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApMiscPaymentHeaders",
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
                    PaymentNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    MiscPaymentDate = table.Column<DateTime>(nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    PostedlkpId = table.Column<long>(nullable: true),
                    BeneficiaryName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18, 6)", nullable: true),
                    BankAccountId = table.Column<long>(nullable: true),
                    AccPayeeOnly = table.Column<bool>(type: "bit", nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApMiscPaymentHeaders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApMiscPaymentHeaders_FndLookupValues_PostedlkpId",
                        column: x => x.PostedlkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ArMiscReceiptDetails",
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
                    CheckNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    MaturityDate = table.Column<DateTime>(nullable: true),
                    BankLkpId = table.Column<long>(nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18, 6)", nullable: true),
                    BankAccountId = table.Column<long>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArMiscReceiptDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArMiscReceiptDetails_ApBankAccounts_BankAccountId",
                        column: x => x.BankAccountId,
                        principalTable: "ApBankAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ArMiscReceiptDetails_FndLookupValues_BankLkpId",
                        column: x => x.BankLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ApMiscPaymentDetails",
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
                    CheckNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    MaturityDate = table.Column<DateTime>(nullable: true),
                    BeneficiaryName = table.Column<string>(type: "nvarchar(30)", maxLength: 200, nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18, 6)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    MiscPaymentId = table.Column<long>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApMiscPaymentDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApMiscPaymentDetails_ApMiscPaymentHeaders_MiscPaymentId",
                        column: x => x.MiscPaymentId,
                        principalTable: "ApMiscPaymentHeaders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ApMiscPaymentLines",
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
                    MiscPaymentAmount = table.Column<decimal>(type: "decimal(18, 6)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    AccountId = table.Column<long>(nullable: true),
                    TaxNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TaxPercent = table.Column<decimal>(type: "decimal(18, 6)", nullable: true),
                    TrTax = table.Column<decimal>(type: "decimal(18, 6)", nullable: true),
                    TaxAccountId = table.Column<long>(nullable: true),
                    MiscPaymentId = table.Column<long>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApMiscPaymentLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApMiscPaymentLines_GlCodeComDetails_AccountId",
                        column: x => x.AccountId,
                        principalTable: "GlCodeComDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApMiscPaymentLines_ApMiscPaymentHeaders_MiscPaymentId",
                        column: x => x.MiscPaymentId,
                        principalTable: "ApMiscPaymentHeaders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApMiscPaymentLines_GlCodeComDetails_TaxAccountId",
                        column: x => x.TaxAccountId,
                        principalTable: "GlCodeComDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApMiscPaymentDetails_MiscPaymentId",
                table: "ApMiscPaymentDetails",
                column: "MiscPaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_ApMiscPaymentHeaders_PostedlkpId",
                table: "ApMiscPaymentHeaders",
                column: "PostedlkpId");

            migrationBuilder.CreateIndex(
                name: "IX_ApMiscPaymentLines_AccountId",
                table: "ApMiscPaymentLines",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_ApMiscPaymentLines_MiscPaymentId",
                table: "ApMiscPaymentLines",
                column: "MiscPaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_ApMiscPaymentLines_TaxAccountId",
                table: "ApMiscPaymentLines",
                column: "TaxAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_ArMiscReceiptDetails_BankAccountId",
                table: "ArMiscReceiptDetails",
                column: "BankAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_ArMiscReceiptDetails_BankLkpId",
                table: "ArMiscReceiptDetails",
                column: "BankLkpId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApMiscPaymentDetails");

            migrationBuilder.DropTable(
                name: "ApMiscPaymentLines");

            migrationBuilder.DropTable(
                name: "ArMiscReceiptDetails");

            migrationBuilder.DropTable(
                name: "ApMiscPaymentHeaders");
        }
    }
}
