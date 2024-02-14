using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class HrPersonSalaryElements : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HrPersonSalaryElements",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    PyElementId = table.Column<long>(nullable: false),
                    StartPeriodId = table.Column<long>(nullable: false),
                    EndPeriodId = table.Column<long>(nullable: true),
                    HrPersonId = table.Column<long>(nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    Notes = table.Column<string>(maxLength: 4000, nullable: true),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HrPersonSalaryElements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HrPersonSalaryElements_GlPeriodsDetails_EndPeriodId",
                        column: x => x.EndPeriodId,
                        principalTable: "GlPeriodsDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HrPersonSalaryElements_HrPersons_HrPersonId",
                        column: x => x.HrPersonId,
                        principalTable: "HrPersons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HrPersonSalaryElements_PyElements_PyElementId",
                        column: x => x.PyElementId,
                        principalTable: "PyElements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HrPersonSalaryElements_GlPeriodsDetails_StartPeriodId",
                        column: x => x.StartPeriodId,
                        principalTable: "GlPeriodsDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HrPersonSalaryElements_EndPeriodId",
                table: "HrPersonSalaryElements",
                column: "EndPeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_HrPersonSalaryElements_HrPersonId",
                table: "HrPersonSalaryElements",
                column: "HrPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_HrPersonSalaryElements_PyElementId",
                table: "HrPersonSalaryElements",
                column: "PyElementId");

            migrationBuilder.CreateIndex(
                name: "IX_HrPersonSalaryElements_StartPeriodId",
                table: "HrPersonSalaryElements",
                column: "StartPeriodId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HrPersonSalaryElements");
        }
    }
}
