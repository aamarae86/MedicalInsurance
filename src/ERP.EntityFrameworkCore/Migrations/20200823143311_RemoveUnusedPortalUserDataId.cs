using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class RemoveUnusedPortalUserDataId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
               name: "PortalUserDataId",
               table: "ScPortalRequests");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
               name: "PortalUserDataId",
               table: "ScPortalRequests",
               nullable: true);
        }
    }
}
