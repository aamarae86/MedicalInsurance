using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class RemoveUnusedPortalUserDataId2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
               name: "FK_ApMiscPaymentLines_PortalUserData_PortalUserDataId",
               table: "ApMiscPaymentLines");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
                name: "FK_ApMiscPaymentLines_PortalUserData_PortalUserDataId",
                table: "ApMiscPaymentLines",
                column: "PortalUserDataId",
                principalTable: "PortalUserData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
