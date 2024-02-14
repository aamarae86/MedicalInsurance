using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class Add_tbls_GlJeHeaders_GlPeriodsYears_GlPeriodsDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GlPeriodsYears",
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
                    PeriodYear = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    AccountId = table.Column<long>(nullable: false),
                    JeId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GlPeriodsYears", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GlPeriodsDetails",
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
                    PeriodName = table.Column<string>(maxLength: 200, nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    GlPeriodsYearsId = table.Column<long>(nullable: false),
                    StatusLkpId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GlPeriodsDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GlPeriodsDetails_GlPeriodsYears_GlPeriodsYearsId",
                        column: x => x.GlPeriodsYearsId,
                        principalTable: "GlPeriodsYears",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GlPeriodsDetails_FndLookupValues_StatusLkpId",
                        column: x => x.StatusLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GlJeHeaders",
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
                    JeName = table.Column<string>(maxLength: 500, nullable: false),
                    JeNumber = table.Column<string>(maxLength: 100, nullable: false),
                    JeNumberKey = table.Column<int>(nullable: false),
                    JeDate = table.Column<DateTime>(nullable: false),
                    PeriodId = table.Column<long>(nullable: false),
                    CurrencyId = table.Column<int>(nullable: false),
                    CurrencyRate = table.Column<decimal>(nullable: false),
                    StatusLkpId = table.Column<long>(nullable: true),
                    JeSourceLkpId = table.Column<long>(nullable: true),
                    JeSourceId = table.Column<long>(nullable: true),
                    JeNotes = table.Column<string>(maxLength: 4000, nullable: true),
                    JeSourceNo = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GlJeHeaders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GlJeHeaders_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GlJeHeaders_GlPeriodsDetails_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "GlPeriodsDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GlJeHeaders_FndLookupValues_StatusLkpId",
                        column: x => x.StatusLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GlJeHeaders_CurrencyId",
                table: "GlJeHeaders",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_GlJeHeaders_PeriodId",
                table: "GlJeHeaders",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_GlJeHeaders_StatusLkpId",
                table: "GlJeHeaders",
                column: "StatusLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_GlPeriodsDetails_GlPeriodsYearsId",
                table: "GlPeriodsDetails",
                column: "GlPeriodsYearsId");

            migrationBuilder.CreateIndex(
                name: "IX_GlPeriodsDetails_StatusLkpId",
                table: "GlPeriodsDetails",
                column: "StatusLkpId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GlJeHeaders");

            migrationBuilder.DropTable(
                name: "GlPeriodsDetails");

            migrationBuilder.DropTable(
                name: "GlPeriodsYears");
        }
    }
}
