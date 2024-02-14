using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class AddingTablesContinue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApPdcInterface",
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
                    SourceCodeLkpId = table.Column<long>(nullable: true),
                    SourceId = table.Column<long>(nullable: true),
                    StatusLkpId = table.Column<long>(nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18, 6)", nullable: true),
                    CheckNumber = table.Column<long>(nullable: true),
                    MaturityDate = table.Column<DateTime>(nullable: true),
                    BankAccountId = table.Column<long>(nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    ConfirmedDate = table.Column<DateTime>(nullable: true),
                    ReversedDate = table.Column<DateTime>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApPdcInterface", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApPdcInterface_ApBankAccounts_BankAccountId",
                        column: x => x.BankAccountId,
                        principalTable: "ApBankAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApPdcInterface_FndLookupValues_SourceCodeLkpId",
                        column: x => x.SourceCodeLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApPdcInterface_FndLookupValues_StatusLkpId",
                        column: x => x.StatusLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ArPdcInterface",
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
                    SourceCodeLkpId = table.Column<long>(nullable: true),
                    SourceId = table.Column<long>(nullable: true),
                    StatusLkpId = table.Column<long>(nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18, 6)", nullable: true),
                    CheckNumber = table.Column<long>(nullable: true),
                    MaturityDate = table.Column<DateTime>(nullable: true),
                    BankAccountId = table.Column<long>(nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    ConfirmedDate = table.Column<DateTime>(nullable: true),
                    ReversedDate = table.Column<DateTime>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArPdcInterface", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArPdcInterface_FndLookupValues_SourceCodeLkpId",
                        column: x => x.SourceCodeLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ArPdcInterface_ApBankAccounts_StatusLkpId",
                        column: x => x.StatusLkpId,
                        principalTable: "ApBankAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ArPdcInterface_FndLookupValues_StatusLkpId",
                        column: x => x.StatusLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApPdcInterface_BankAccountId",
                table: "ApPdcInterface",
                column: "BankAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_ApPdcInterface_SourceCodeLkpId",
                table: "ApPdcInterface",
                column: "SourceCodeLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_ApPdcInterface_StatusLkpId",
                table: "ApPdcInterface",
                column: "StatusLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_ArPdcInterface_SourceCodeLkpId",
                table: "ArPdcInterface",
                column: "SourceCodeLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_ArPdcInterface_StatusLkpId",
                table: "ArPdcInterface",
                column: "StatusLkpId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApPdcInterface");

            migrationBuilder.DropTable(
                name: "ArPdcInterface");
        }
    }
}
