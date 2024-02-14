using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class mand : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScPortalRequestStudy_FndLookupValues_StudyLkpId",
                table: "ScPortalRequestStudy");

            migrationBuilder.AlterColumn<long>(
                name: "StudyLkpId",
                table: "ScPortalRequestStudy",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

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

            migrationBuilder.AlterColumn<long>(
                name: "StudyLkpId",
                table: "ScPortalRequestStudy",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddForeignKey(
                name: "FK_ScPortalRequestStudy_FndLookupValues_StudyLkpId",
                table: "ScPortalRequestStudy",
                column: "StudyLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
