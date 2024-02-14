using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class PageLinkAndIcon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Icon",
                table: "Pages",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "Pages",
                maxLength: 100,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Icon",
                table: "Pages");

            migrationBuilder.DropColumn(
                name: "Link",
                table: "Pages");
        }
    }
}
