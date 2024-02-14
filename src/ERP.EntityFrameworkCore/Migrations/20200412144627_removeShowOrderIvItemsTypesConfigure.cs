using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class removeShowOrderIvItemsTypesConfigure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShowOrder",
                table: "IvItemsTypesConfigure");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ShowOrder",
                table: "IvItemsTypesConfigure",
                nullable: false,
                defaultValue: 0);
        }
    }
}
