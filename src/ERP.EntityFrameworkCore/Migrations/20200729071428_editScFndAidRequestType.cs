using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class editScFndAidRequestType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsElectronics",
                table: "ScFndAidRequestType",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsMaintenance",
                table: "ScFndAidRequestType",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsElectronics",
                table: "ScFndAidRequestType");

            migrationBuilder.DropColumn(
                name: "IsMaintenance",
                table: "ScFndAidRequestType");
        }
    }
}
