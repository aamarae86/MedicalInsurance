using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class ScCommitteeDetailsElectronicAidadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ScCommitteeDetailsElectronicAid",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    ElectronicTypeLkpId = table.Column<long>(nullable: false),
                    ScCommitteeDetailsId = table.Column<long>(nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScCommitteeDetailsElectronicAid", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScCommitteeDetailsElectronicAid_FndLookupValues_ElectronicTypeLkpId",
                        column: x => x.ElectronicTypeLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScCommitteeDetailsElectronicAid_ScCommitteeDetails_ScCommitteeDetailsId",
                        column: x => x.ScCommitteeDetailsId,
                        principalTable: "ScCommitteeDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ScCommitteeDetailsElectronicAid_ElectronicTypeLkpId",
                table: "ScCommitteeDetailsElectronicAid",
                column: "ElectronicTypeLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_ScCommitteeDetailsElectronicAid_ScCommitteeDetailsId",
                table: "ScCommitteeDetailsElectronicAid",
                column: "ScCommitteeDetailsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScCommitteeDetailsElectronicAid");
        }
    }
}
