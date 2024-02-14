using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class addingTableScCompainsAid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ScCampainsAid",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    CampainsAidCategoryLkpId = table.Column<long>(nullable: false),
                    AidName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    AidAmount = table.Column<decimal>(type: "decimal(18, 6)", nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScCampainsAid", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScCampainsAid_FndLookupValues_CampainsAidCategoryLkpId",
                        column: x => x.CampainsAidCategoryLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ScCampainsAid_CampainsAidCategoryLkpId",
                table: "ScCampainsAid",
                column: "CampainsAidCategoryLkpId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScCampainsAid");
        }
    }
}
