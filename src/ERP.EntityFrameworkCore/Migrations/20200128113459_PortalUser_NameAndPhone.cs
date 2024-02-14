using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class PortalUser_NameAndPhone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "PortalUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "PortalUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "PortalUsers");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "PortalUsers");
        }
    }
}
