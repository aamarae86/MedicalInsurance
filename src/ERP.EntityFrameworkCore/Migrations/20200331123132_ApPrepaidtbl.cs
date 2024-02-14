using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class ApPrepaidtbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApPrepaid",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    SourceNo = table.Column<string>(maxLength: 20, nullable: true),
                    TransactionDate = table.Column<DateTime>(nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    DrAccountId = table.Column<long>(nullable: true),
                    CrAccountId = table.Column<long>(nullable: true),
                    SourceId = table.Column<long>(nullable: true),
                    StatusLkpId = table.Column<long>(nullable: false),
                    SourceCodeLkpId = table.Column<long>(nullable: false),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApPrepaid", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApPrepaid_GlCodeComDetails_CrAccountId",
                        column: x => x.CrAccountId,
                        principalTable: "GlCodeComDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApPrepaid_GlCodeComDetails_DrAccountId",
                        column: x => x.DrAccountId,
                        principalTable: "GlCodeComDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApPrepaid_FndLookupValues_SourceCodeLkpId",
                        column: x => x.SourceCodeLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApPrepaid_FndLookupValues_StatusLkpId",
                        column: x => x.StatusLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApPrepaid_CrAccountId",
                table: "ApPrepaid",
                column: "CrAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_ApPrepaid_DrAccountId",
                table: "ApPrepaid",
                column: "DrAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_ApPrepaid_SourceCodeLkpId",
                table: "ApPrepaid",
                column: "SourceCodeLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_ApPrepaid_StatusLkpId",
                table: "ApPrepaid",
                column: "StatusLkpId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApPrepaid");
        }
    }
}
