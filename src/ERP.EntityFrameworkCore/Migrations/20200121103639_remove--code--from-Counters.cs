using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class removecodefromCounters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "Counters");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Counters",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);
        }
    }
}
