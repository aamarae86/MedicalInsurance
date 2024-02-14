using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class HrPersonVacations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HrPersonVacations",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    OperationNumber = table.Column<string>(maxLength: 30, nullable: false),
                    VacationBalance = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    OperationDate = table.Column<DateTime>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    StatusLkpId = table.Column<long>(nullable: false),
                    HrVacationsTypeId = table.Column<long>(nullable: false),
                    HrPersonId = table.Column<long>(nullable: false),
                    Notes = table.Column<string>(maxLength: 4000, nullable: true),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HrPersonVacations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HrPersonVacations_HrPersons_HrPersonId",
                        column: x => x.HrPersonId,
                        principalTable: "HrPersons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HrPersonVacations_HrVacationsTypes_HrVacationsTypeId",
                        column: x => x.HrVacationsTypeId,
                        principalTable: "HrVacationsTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HrPersonVacations_FndLookupValues_StatusLkpId",
                        column: x => x.StatusLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HrPersonVacations_HrPersonId",
                table: "HrPersonVacations",
                column: "HrPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_HrPersonVacations_HrVacationsTypeId",
                table: "HrPersonVacations",
                column: "HrVacationsTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_HrPersonVacations_StatusLkpId",
                table: "HrPersonVacations",
                column: "StatusLkpId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HrPersonVacations");
        }
    }
}
