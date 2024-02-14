using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class addtblScPortalRequestVisited : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FilePath",
                table: "ScPortalRequestStudyAttachment",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100  0)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ScPortalRequestVisited",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    PortalRequestId = table.Column<long>(nullable: false),
                    VisitDate = table.Column<DateTime>(nullable: false),
                    VisitTime = table.Column<DateTime>(nullable: false),
                    VisitStatusLkpId = table.Column<long>(nullable: false),
                    MobileNumber = table.Column<string>(maxLength: 50, nullable: false),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScPortalRequestVisited", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScPortalRequestVisited_ScPortalRequests_PortalRequestId",
                        column: x => x.PortalRequestId,
                        principalTable: "ScPortalRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScPortalRequestVisited_FndLookupValues_VisitStatusLkpId",
                        column: x => x.VisitStatusLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ScPortalRequestVisited_PortalRequestId",
                table: "ScPortalRequestVisited",
                column: "PortalRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_ScPortalRequestVisited_VisitStatusLkpId",
                table: "ScPortalRequestVisited",
                column: "VisitStatusLkpId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScPortalRequestVisited");

            migrationBuilder.AlterColumn<string>(
                name: "FilePath",
                table: "ScPortalRequestStudyAttachment",
                type: "nvarchar(100  0)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000,
                oldNullable: true);
        }
    }
}
