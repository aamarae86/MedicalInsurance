using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class fixHROrg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ParentPath",
                table: "HrOrganizations",
                maxLength: 2000,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParentPath",
                table: "HrOrganizations");
        }
    }
}
