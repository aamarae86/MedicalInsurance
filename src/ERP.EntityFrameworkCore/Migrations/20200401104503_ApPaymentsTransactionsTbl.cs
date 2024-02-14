using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class ApPaymentsTransactionsTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApPaymentsTransactions",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    PaymentNumber = table.Column<string>(maxLength: 30, nullable: false),
                    CheckNumber = table.Column<string>(maxLength: 30, nullable: true),
                    PaymentDate = table.Column<DateTime>(nullable: false),
                    MaturityDate = table.Column<DateTime>(nullable: true),
                    Notes = table.Column<string>(maxLength: 4000, nullable: true),
                    PaymentAmount = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    AccPayeeOnly = table.Column<bool>(nullable: false),
                    StatusLkpId = table.Column<long>(nullable: false),
                    PaymentTypeLkpId = table.Column<long>(nullable: false),
                    BankAccountId = table.Column<long>(nullable: true),
                    VendorId = table.Column<long>(nullable: false),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApPaymentsTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApPaymentsTransactions_ApBankAccounts_BankAccountId",
                        column: x => x.BankAccountId,
                        principalTable: "ApBankAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApPaymentsTransactions_FndLookupValues_PaymentTypeLkpId",
                        column: x => x.PaymentTypeLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApPaymentsTransactions_FndLookupValues_StatusLkpId",
                        column: x => x.StatusLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ApPaymentsTransactions_ApVendors_VendorId",
                        column: x => x.VendorId,
                        principalTable: "ApVendors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApPaymentsTransactions_BankAccountId",
                table: "ApPaymentsTransactions",
                column: "BankAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_ApPaymentsTransactions_PaymentTypeLkpId",
                table: "ApPaymentsTransactions",
                column: "PaymentTypeLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_ApPaymentsTransactions_StatusLkpId",
                table: "ApPaymentsTransactions",
                column: "StatusLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_ApPaymentsTransactions_VendorId",
                table: "ApPaymentsTransactions",
                column: "VendorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApPaymentsTransactions");
        }
    }
}
