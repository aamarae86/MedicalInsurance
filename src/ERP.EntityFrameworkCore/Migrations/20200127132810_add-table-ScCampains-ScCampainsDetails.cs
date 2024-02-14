using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class addtableScCampainsScCampainsDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ScCampains",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    CampainName = table.Column<string>(maxLength: 200, nullable: false),
                    ScCampainDate = table.Column<DateTime>(nullable: false),
                    StatusLkpId = table.Column<long>(nullable: false),
                    Notes = table.Column<string>(maxLength: 4000, nullable: true),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScCampains", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScCampains_FndLookupValues_StatusLkpId",
                        column: x => x.StatusLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScCampainsDetail",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    CampainId = table.Column<long>(nullable: false),
                    FndUsersId = table.Column<long>(nullable: false),
                    CampainAidId = table.Column<long>(nullable: false),
                    StatusLkpId = table.Column<long>(nullable: false),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScCampainsDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScCampainsDetail_ScCampainsAid_CampainAidId",
                        column: x => x.CampainAidId,
                        principalTable: "ScCampainsAid",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ScCampainsDetail_ScCampains_CampainId",
                        column: x => x.CampainId,
                        principalTable: "ScCampains",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ScCampainsDetail_FndUsers_FndUsersId",
                        column: x => x.FndUsersId,
                        principalTable: "FndUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ScCampainsDetail_FndLookupValues_StatusLkpId",
                        column: x => x.StatusLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ScCampains_StatusLkpId",
                table: "ScCampains",
                column: "StatusLkpId");

 

            migrationBuilder.CreateIndex(
                name: "IX_ScCampainsDetail_CampainAidId",
                table: "ScCampainsDetail",
                column: "CampainAidId");

            migrationBuilder.CreateIndex(
                name: "IX_ScCampainsDetail_CampainId",
                table: "ScCampainsDetail",
                column: "CampainId");

            migrationBuilder.CreateIndex(
                name: "IX_ScCampainsDetail_FndUsersId",
                table: "ScCampainsDetail",
                column: "FndUsersId");

            migrationBuilder.CreateIndex(
                name: "IX_ScCampainsDetail_StatusLkpId",
                table: "ScCampainsDetail",
                column: "StatusLkpId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScCampainsDetail");
 

            migrationBuilder.DropTable(
                name: "ScCampains");
        }
    }
}
