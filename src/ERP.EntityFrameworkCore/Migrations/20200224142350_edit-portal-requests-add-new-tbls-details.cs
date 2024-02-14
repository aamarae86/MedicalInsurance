using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class editportalrequestsaddnewtblsdetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IncomeSource",
                table: "ScPortalRequests");

            migrationBuilder.DropColumn(
                name: "MonthlyIncomeAmount",
                table: "ScPortalRequests");

            migrationBuilder.DropColumn(
                name: "MonthlyOutcomeAmount",
                table: "ScPortalRequests");

            migrationBuilder.CreateTable(
                name: "ScPortalRequestDuties",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    DutyType = table.Column<string>(maxLength: 200, nullable: false),
                    DutyDescription = table.Column<string>(maxLength: 200, nullable: false),
                    MonthlyAmount = table.Column<decimal>(type: "decimal(18, 6)", nullable: false),
                    PortalRequestId = table.Column<long>(nullable: false),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScPortalRequestDuties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScPortalRequestDuties_ScPortalRequests_PortalRequestId",
                        column: x => x.PortalRequestId,
                        principalTable: "ScPortalRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScPortalRequestIncome",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IncomeSourceName = table.Column<string>(maxLength: 200, nullable: false),
                    MonthlyIncomeAmount = table.Column<decimal>(type: "decimal(18, 6)", nullable: false),
                    PortalRequestId = table.Column<long>(nullable: false),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScPortalRequestIncome", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScPortalRequestIncome_ScPortalRequests_PortalRequestId",
                        column: x => x.PortalRequestId,
                        principalTable: "ScPortalRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ScPortalRequestDuties_PortalRequestId",
                table: "ScPortalRequestDuties",
                column: "PortalRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_ScPortalRequestIncome_PortalRequestId",
                table: "ScPortalRequestIncome",
                column: "PortalRequestId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScPortalRequestDuties");

            migrationBuilder.DropTable(
                name: "ScPortalRequestIncome");

            migrationBuilder.AddColumn<string>(
                name: "IncomeSource",
                table: "ScPortalRequests",
                maxLength: 4000,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "MonthlyIncomeAmount",
                table: "ScPortalRequests",
                type: "decimal(18, 6)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MonthlyOutcomeAmount",
                table: "ScPortalRequests",
                type: "decimal(18, 6)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
