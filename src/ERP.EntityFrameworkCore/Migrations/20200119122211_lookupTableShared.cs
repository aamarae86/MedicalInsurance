using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class lookupTableShared : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "FndLookupValues");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "FndLookupValues",
                nullable: false,
                defaultValue: 1);
        }
    }
}
