using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class RemoveUnusedPortalUserDataId4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
               name: "FK_ScCampainsDetail_PortalUserData_PortalUserDataId",
               table: "ScCampainsDetail");

            migrationBuilder.DropColumn(
              name: "PortalUserDataId",
              table: "ScCampainsDetail");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
             name: "FK_ScCampainsDetail_PortalUserData_PortalUserDataId",
             table: "ScCampainsDetail",
             column: "PortalUserDataId",
             principalTable: "ScCampainsDetail",
             principalColumn: "Id",
             onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddColumn<long>(
             name: "PortalUserDataId",
             table: "ScCampainsDetail",
             nullable: true);
        }
    }
}
