using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class editScPortalRequestStudy1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsMedicine",
                table: "ScPortalRequestStudy",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "OtherAidLkpId",
                table: "ScPortalRequestStudy",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OtherMonthNo",
                table: "ScPortalRequestStudy",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ScPortalRequestStudy_OtherAidLkpId",
                table: "ScPortalRequestStudy",
                column: "OtherAidLkpId");

            migrationBuilder.AddForeignKey(
                name: "FK_ScPortalRequestStudy_FndLookupValues_OtherAidLkpId",
                table: "ScPortalRequestStudy",
                column: "OtherAidLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScPortalRequestStudy_FndLookupValues_OtherAidLkpId",
                table: "ScPortalRequestStudy");

            migrationBuilder.DropIndex(
                name: "IX_ScPortalRequestStudy_OtherAidLkpId",
                table: "ScPortalRequestStudy");

            migrationBuilder.DropColumn(
                name: "IsMedicine",
                table: "ScPortalRequestStudy");

            migrationBuilder.DropColumn(
                name: "OtherAidLkpId",
                table: "ScPortalRequestStudy");

            migrationBuilder.DropColumn(
                name: "OtherMonthNo",
                table: "ScPortalRequestStudy");
        }
    }
}
