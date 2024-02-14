using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class addNewTblTmCharityBoxCollectMembers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TmCharityBoxes_TmCharityBoxReceive_TmCharityBoxReceiveId",
                table: "TmCharityBoxes");

            migrationBuilder.DropIndex(
                name: "IX_TmCharityBoxes_TmCharityBoxReceiveId",
                table: "TmCharityBoxes");

            migrationBuilder.DropColumn(
                name: "InternalCounterPerType",
                table: "TmCharityBoxes");

            migrationBuilder.DropColumn(
                name: "TmCharityBoxReceiveId",
                table: "TmCharityBoxes");

            migrationBuilder.CreateTable(
                name: "TmCharityBoxCollectMembers",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    MemberNumber = table.Column<string>(maxLength: 30, nullable: true),
                    MemberName = table.Column<string>(maxLength: 200, nullable: false),
                    MemberCategoryLkpId = table.Column<long>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TmCharityBoxCollectMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TmCharityBoxCollectMembers_FndLookupValues_MemberCategoryLkpId",
                        column: x => x.MemberCategoryLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TmCharityBoxCollectMembers_MemberCategoryLkpId",
                table: "TmCharityBoxCollectMembers",
                column: "MemberCategoryLkpId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TmCharityBoxCollectMembers");

            migrationBuilder.AddColumn<long>(
                name: "InternalCounterPerType",
                table: "TmCharityBoxes",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "TmCharityBoxReceiveId",
                table: "TmCharityBoxes",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_TmCharityBoxes_TmCharityBoxReceiveId",
                table: "TmCharityBoxes",
                column: "TmCharityBoxReceiveId");

            migrationBuilder.AddForeignKey(
                name: "FK_TmCharityBoxes_TmCharityBoxReceive_TmCharityBoxReceiveId",
                table: "TmCharityBoxes",
                column: "TmCharityBoxReceiveId",
                principalTable: "TmCharityBoxReceive",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
