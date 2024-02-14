using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class ArRecieptsAndItsDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArReceipts",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    ReceiptNumber = table.Column<string>(maxLength: 30, nullable: true),
                    ReceiptDate = table.Column<DateTime>(nullable: true),
                    StatusLkpId = table.Column<long>(nullable: true),
                    ArCustomerId = table.Column<long>(nullable: true),
                    Notes = table.Column<string>(maxLength: 4000, nullable: true),
                    BankAccountId = table.Column<long>(nullable: true),
                    CurrencyId = table.Column<long>(nullable: true),
                    CurrencyRate = table.Column<decimal>(type: "decimal(18, 6)", nullable: true),
                    RemitanceBankId = table.Column<long>(nullable: true),
                    ManualReceiptNo = table.Column<string>(maxLength: 30, nullable: true),
                    SourceCodeLkpId = table.Column<long>(nullable: true),
                    SourceId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArReceipts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArReceiptDetails",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    ReceiptId = table.Column<long>(nullable: true),
                    CheckNumber = table.Column<string>(maxLength: 30, nullable: true),
                    MaturityDate = table.Column<DateTime>(nullable: true),
                    Amount = table.Column<decimal>(nullable: true),
                    Notes = table.Column<string>(maxLength: 4000, nullable: true),
                    SourceCodeLkpId = table.Column<long>(nullable: true),
                    SourceId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArReceiptDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArReceiptDetails_ArReceipts_ReceiptId",
                        column: x => x.ReceiptId,
                        principalTable: "ArReceipts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ArReceiptsOnAccount",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    ApplyDate = table.Column<DateTime>(nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18, 6)", nullable: true),
                    Notes = table.Column<string>(maxLength: 4000, nullable: true),
                    ArCustomerId = table.Column<long>(nullable: true),
                    ReceiptTypeLkpId = table.Column<long>(nullable: true),
                    SourceCodeLkpId = table.Column<long>(nullable: true),
                    SourceId = table.Column<long>(nullable: true),
                    ReceiptId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArReceiptsOnAccount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArReceiptsOnAccount_ArReceipts_ReceiptId",
                        column: x => x.ReceiptId,
                        principalTable: "ArReceipts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArReceiptDetails_ReceiptId",
                table: "ArReceiptDetails",
                column: "ReceiptId");

            migrationBuilder.CreateIndex(
                name: "IX_ArReceiptsOnAccount_ReceiptId",
                table: "ArReceiptsOnAccount",
                column: "ReceiptId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArReceiptDetails");

            migrationBuilder.DropTable(
                name: "ArReceiptsOnAccount");

            migrationBuilder.DropTable(
                name: "ArReceipts");
        }
    }
}
