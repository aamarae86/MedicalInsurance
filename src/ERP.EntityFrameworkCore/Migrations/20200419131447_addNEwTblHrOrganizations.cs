using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class addNEwTblHrOrganizations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HrOrganizations",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    OrganizationName = table.Column<string>(maxLength: 200, nullable: false),
                    ShortName = table.Column<string>(maxLength: 200, nullable: true),
                    Notes = table.Column<string>(maxLength: 4000, nullable: true),
                    OrganizationTypeLkpId = table.Column<long>(nullable: false),
                    ParentId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HrOrganizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HrOrganizations_FndLookupValues_OrganizationTypeLkpId",
                        column: x => x.OrganizationTypeLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HrOrganizations_HrOrganizations_ParentId",
                        column: x => x.ParentId,
                        principalTable: "HrOrganizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HrOrganizations_OrganizationTypeLkpId",
                table: "HrOrganizations",
                column: "OrganizationTypeLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_HrOrganizations_ParentId",
                table: "HrOrganizations",
                column: "ParentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HrOrganizations");
        }
    }
}
