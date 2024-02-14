using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class reedittblFndUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WifeName1",
                table: "FndUsers",
                newName: "WifeHusbandName1");

            migrationBuilder.RenameColumn(
                name: "IdNumberWife1",
                table: "FndUsers",
                newName: "IdNumberWifeHusband1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WifeHusbandName1",
                table: "FndUsers",
                newName: "WifeName1");

            migrationBuilder.RenameColumn(
                name: "IdNumberWifeHusband1",
                table: "FndUsers",
                newName: "IdNumberWife1");
        }
    }
}
