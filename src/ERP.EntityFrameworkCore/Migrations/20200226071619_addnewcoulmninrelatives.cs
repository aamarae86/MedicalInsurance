using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class addnewcoulmninrelatives : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Employer",
                table: "PortalUserRelatives",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "MaritalStatusLkpId",
                table: "PortalUserRelatives",
                nullable: true);

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
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PortalUserRelatives_FndLookupValues_MaritalStatusLkpId",
                table: "PortalUserRelatives");

            migrationBuilder.DropIndex(
                name: "IX_PortalUserRelatives_MaritalStatusLkpId",
                table: "PortalUserRelatives");

            migrationBuilder.DropColumn(
                name: "Employer",
                table: "PortalUserRelatives");

            migrationBuilder.DropColumn(
                name: "MaritalStatusLkpId",
                table: "PortalUserRelatives");
        }
    }
}
