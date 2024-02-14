using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class addindRelationToSpCases : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SpFamilyIncomes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    SpFamilyId = table.Column<long>(nullable: false),
                    IncomeSourceName = table.Column<string>(maxLength: 200, nullable: false),
                    MonthlyIncomeAmount = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpFamilyIncomes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpFamilyIncomes_SpFamilies_SpFamilyId",
                        column: x => x.SpFamilyId,
                        principalTable: "SpFamilies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SpCases_SpFamilyId",
                table: "SpCases",
                column: "SpFamilyId");

            migrationBuilder.CreateIndex(
                name: "IX_SpFamilyIncomes_SpFamilyId",
                table: "SpFamilyIncomes",
                column: "SpFamilyId");

            migrationBuilder.AddForeignKey(
                name: "FK_SpCases_SpFamilies_SpFamilyId",
                table: "SpCases",
                column: "SpFamilyId",
                principalTable: "SpFamilies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpCases_SpFamilies_SpFamilyId",
                table: "SpCases");

            migrationBuilder.DropTable(
                name: "SpFamilyIncomes");

            migrationBuilder.DropIndex(
                name: "IX_SpCases_SpFamilyId",
                table: "SpCases");
        }
    }
}
