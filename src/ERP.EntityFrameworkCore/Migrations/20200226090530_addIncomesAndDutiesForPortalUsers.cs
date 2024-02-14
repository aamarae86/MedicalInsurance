using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class addIncomesAndDutiesForPortalUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PortalUserDuties",
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
                    PortalUserId = table.Column<long>(nullable: false),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortalUserDuties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PortalUserDuties_PortalUsers_PortalUserId",
                        column: x => x.PortalUserId,
                        principalTable: "PortalUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PortalUserIncomes",
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
                    PortalUserId = table.Column<long>(nullable: false),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortalUserIncomes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PortalUserIncomes_PortalUsers_PortalUserId",
                        column: x => x.PortalUserId,
                        principalTable: "PortalUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PortalUserDuties_PortalUserId",
                table: "PortalUserDuties",
                column: "PortalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PortalUserIncomes_PortalUserId",
                table: "PortalUserIncomes",
                column: "PortalUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PortalUserDuties");

            migrationBuilder.DropTable(
                name: "PortalUserIncomes");
        }
    }
}
