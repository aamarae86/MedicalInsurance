using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class addFmEngineers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FmEngineers",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    EngineerNumber = table.Column<string>(maxLength: 30, nullable: false),
                    EngineerName = table.Column<string>(maxLength: 100, nullable: false),
                    StatusLkpId = table.Column<long>(nullable: false),
                    Comments = table.Column<string>(maxLength: 4000, nullable: true),
                    Mobile1 = table.Column<string>(maxLength: 50, nullable: true),
                    Mobile2 = table.Column<string>(maxLength: 50, nullable: true),
                    HireDate = table.Column<DateTime>(nullable: true),
                    HrPersonsId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FmEngineers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FmEngineers_HrPersons_HrPersonsId",
                        column: x => x.HrPersonsId,
                        principalTable: "HrPersons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FmEngineers_FndLookupValues_StatusLkpId",
                        column: x => x.StatusLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FmEngineers_HrPersonsId",
                table: "FmEngineers",
                column: "HrPersonsId");

            migrationBuilder.CreateIndex(
                name: "IX_FmEngineers_StatusLkpId",
                table: "FmEngineers",
                column: "StatusLkpId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FmEngineers");
        }
    }
}
