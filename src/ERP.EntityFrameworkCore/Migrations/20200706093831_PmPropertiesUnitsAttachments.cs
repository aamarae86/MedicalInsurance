using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class PmPropertiesUnitsAttachments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PmPropertiesUnitsAttachments",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    FilePath = table.Column<string>(nullable: true),
                    PmPropertiesUnitstId = table.Column<long>(nullable: false),
                    TenantId = table.Column<int>(nullable: false),
                    PmPropertiesUnitsId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PmPropertiesUnitsAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PmPropertiesUnitsAttachments_PmPropertiesUnits_PmPropertiesUnitsId",
                        column: x => x.PmPropertiesUnitsId,
                        principalTable: "PmPropertiesUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PmPropertiesUnitsAttachments_PmPropertiesUnitsId",
                table: "PmPropertiesUnitsAttachments",
                column: "PmPropertiesUnitsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PmPropertiesUnitsAttachments");
        }
    }
}
