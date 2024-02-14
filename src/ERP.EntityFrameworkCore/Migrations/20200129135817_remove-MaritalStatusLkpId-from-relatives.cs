using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class removeMaritalStatusLkpIdfromrelatives : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PortalUserRelatives_FndLookupValues_MaritalStatusLkpId",
                table: "PortalUserRelatives");

            migrationBuilder.DropIndex(
                name: "IX_PortalUserRelatives_MaritalStatusLkpId",
                table: "PortalUserRelatives");

            migrationBuilder.DropColumn(
                name: "MaritalStatusLkpId",
                table: "PortalUserRelatives");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "MaritalStatusLkpId",
                table: "PortalUserRelatives",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_PortalUserRelatives_MaritalStatusLkpId",
                table: "PortalUserRelatives",
                column: "MaritalStatusLkpId");

            migrationBuilder.AddForeignKey(
                name: "FK_PortalUserRelatives_FndLookupValues_MaritalStatusLkpId",
                table: "PortalUserRelatives",
                column: "MaritalStatusLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
