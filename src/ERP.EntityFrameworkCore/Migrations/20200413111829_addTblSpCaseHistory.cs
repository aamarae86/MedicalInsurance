using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class addTblSpCaseHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SpCaseHistory",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    OprationDate = table.Column<DateTime>(nullable: false),
                    SpCaseId = table.Column<long>(nullable: false),
                    OperationTypeLkpId = table.Column<long>(nullable: false),
                    CaseStatusLkpId = table.Column<long>(nullable: false),
                    BeneficentId = table.Column<long>(nullable: false),
                    SourceId = table.Column<long>(nullable: true),
                    OperationNotes = table.Column<string>(maxLength: 4000, nullable: true),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpCaseHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpCaseHistory_SpBeneficent_BeneficentId",
                        column: x => x.BeneficentId,
                        principalTable: "SpBeneficent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpCaseHistory_FndLookupValues_CaseStatusLkpId",
                        column: x => x.CaseStatusLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpCaseHistory_FndLookupValues_OperationTypeLkpId",
                        column: x => x.OperationTypeLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_SpCaseHistory_SpCases_SpCaseId",
                        column: x => x.SpCaseId,
                        principalTable: "SpCases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SpCaseHistory_BeneficentId",
                table: "SpCaseHistory",
                column: "BeneficentId");

            migrationBuilder.CreateIndex(
                name: "IX_SpCaseHistory_CaseStatusLkpId",
                table: "SpCaseHistory",
                column: "CaseStatusLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_SpCaseHistory_OperationTypeLkpId",
                table: "SpCaseHistory",
                column: "OperationTypeLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_SpCaseHistory_SpCaseId",
                table: "SpCaseHistory",
                column: "SpCaseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SpCaseHistory");
        }
    }
}
