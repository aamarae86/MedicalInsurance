using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class removekeyfromgljeheader : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JeNumberKey",
                table: "GlJeHeaders");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "JeNumberKey",
                table: "GlJeHeaders",
                nullable: false,
                defaultValue: 0);
        }
    }
}
