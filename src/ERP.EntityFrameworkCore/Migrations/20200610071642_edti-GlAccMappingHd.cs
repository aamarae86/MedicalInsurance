using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class edtiGlAccMappingHd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MapNumber",
                table: "GlAccMappingHd",
                maxLength: 30,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MapNumber",
                table: "GlAccMappingHd");
        }
    }
}
