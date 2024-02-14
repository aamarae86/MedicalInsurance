using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class editPortalUserAndRequestAndStudy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "SuggestedAmount",
                table: "ScPortalRequestStudy",
                type: "decimal(18, 6)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalAmount",
                table: "ScPortalRequestDuties",
                type: "decimal(18, 6)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalAmount",
                table: "PortalUserDuties",
                type: "decimal(18, 6)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PortalUserAttachments",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    AttachmentName = table.Column<string>(maxLength: 200, nullable: false),
                    FilePath = table.Column<string>(maxLength: 1000, nullable: false),
                    PortalUserId = table.Column<long>(nullable: false),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortalUserAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PortalUserAttachments_PortalUsers_PortalUserId",
                        column: x => x.PortalUserId,
                        principalTable: "PortalUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PortalUserAttachments_PortalUserId",
                table: "PortalUserAttachments",
                column: "PortalUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PortalUserAttachments");

            migrationBuilder.DropColumn(
                name: "SuggestedAmount",
                table: "ScPortalRequestStudy");

            migrationBuilder.DropColumn(
                name: "TotalAmount",
                table: "ScPortalRequestDuties");

            migrationBuilder.DropColumn(
                name: "TotalAmount",
                table: "PortalUserDuties");
        }
    }
}
