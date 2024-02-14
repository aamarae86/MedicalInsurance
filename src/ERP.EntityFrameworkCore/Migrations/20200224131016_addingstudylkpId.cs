using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class addingstudylkpId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "StudyLkpId",
                table: "ScPortalRequestStudy",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ScPortalRequestStudy_StudyLkpId",
                table: "ScPortalRequestStudy",
                column: "StudyLkpId");

            migrationBuilder.AddForeignKey(
                name: "FK_ScPortalRequestStudy_FndLookupValues_StudyLkpId",
                table: "ScPortalRequestStudy",
                column: "StudyLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScPortalRequestStudy_FndLookupValues_StudyLkpId",
                table: "ScPortalRequestStudy");

            migrationBuilder.DropIndex(
                name: "IX_ScPortalRequestStudy_StudyLkpId",
                table: "ScPortalRequestStudy");

            migrationBuilder.DropColumn(
                name: "StudyLkpId",
                table: "ScPortalRequestStudy");
        }
    }
}
