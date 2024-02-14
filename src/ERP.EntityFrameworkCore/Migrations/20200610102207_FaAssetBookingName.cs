using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class FaAssetBookingName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BookingName",
                table: "FaAssets",
                maxLength: 200,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookingName",
                table: "FaAssets");
        }
    }
}
