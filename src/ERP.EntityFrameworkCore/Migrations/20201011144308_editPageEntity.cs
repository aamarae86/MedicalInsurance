using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class editPageEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DocPathAr",
                table: "Pages",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DocPathEn",
                table: "Pages",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VideoUrlAr",
                table: "Pages",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VideoUrlEn",
                table: "Pages",
                maxLength: 200,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DocPathAr",
                table: "Pages");

            migrationBuilder.DropColumn(
                name: "DocPathEn",
                table: "Pages");

            migrationBuilder.DropColumn(
                name: "VideoUrlAr",
                table: "Pages");

            migrationBuilder.DropColumn(
                name: "VideoUrlEn",
                table: "Pages");
        }
    }
}
