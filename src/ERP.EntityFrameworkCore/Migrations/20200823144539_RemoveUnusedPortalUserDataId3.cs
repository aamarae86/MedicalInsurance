using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class RemoveUnusedPortalUserDataId3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                 name: "PortalUserDataId",
                 table: "ApMiscPaymentLines");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<long>(
                   name: "PortalUserDataId",
                   table: "ApMiscPaymentLines",
                   nullable: true);
        }
    }
}
