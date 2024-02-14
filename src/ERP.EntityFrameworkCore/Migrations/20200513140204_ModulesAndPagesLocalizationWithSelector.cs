using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class ModulesAndPagesLocalizationWithSelector : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Pages",
                newName: "Selector");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Modules",
                newName: "Selector");

            migrationBuilder.AddColumn<string>(
                name: "NameAr",
                table: "Pages",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameEn",
                table: "Pages",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameAr",
                table: "Modules",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameEn",
                table: "Modules",
                maxLength: 100,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NameAr",
                table: "Pages");

            migrationBuilder.DropColumn(
                name: "NameEn",
                table: "Pages");

            migrationBuilder.DropColumn(
                name: "NameAr",
                table: "Modules");

            migrationBuilder.DropColumn(
                name: "NameEn",
                table: "Modules");

            migrationBuilder.RenameColumn(
                name: "Selector",
                table: "Pages",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Selector",
                table: "Modules",
                newName: "Name");
        }
    }
}
