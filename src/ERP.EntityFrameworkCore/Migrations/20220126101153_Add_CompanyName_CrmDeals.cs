using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class Add_CompanyName_CrmDeals : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Company",
                table: "CrmDeals",
                maxLength: 500,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Company",
                table: "CrmDeals");
        }
    }
}
