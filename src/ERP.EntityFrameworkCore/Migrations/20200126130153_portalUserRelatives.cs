using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class portalUserRelatives : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PortalUserRelatives",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    PortalUserId = table.Column<long>(nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: true),
                    GenderLkpId = table.Column<long>(nullable: false),
                    RelativesTypeLkpId = table.Column<long>(nullable: false),
                    IdNumber = table.Column<string>(maxLength: 50, nullable: true),
                    NationalityLkpId = table.Column<long>(nullable: false),
                    QualificationLkpId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortalUserRelatives", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PortalUserRelatives_PortalUsers_PortalUserId",
                        column: x => x.PortalUserId,
                        principalTable: "PortalUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PortalUserRelatives_PortalUserId",
                table: "PortalUserRelatives",
                column: "PortalUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PortalUserRelatives");
        }
    }
}
