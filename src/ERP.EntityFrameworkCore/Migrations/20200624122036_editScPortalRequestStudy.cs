using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class editScPortalRequestStudy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberOfMonths",
                table: "ScPortalRequestStudy",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfMonths",
                table: "ScPortalRequestStudy");
        }
    }
}
