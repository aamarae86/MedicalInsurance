using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class ArMiscReceiptLines_Edit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "AdministrativePercent",
                table: "ArMiscReceiptLines",
                type: "decimal(18, 6)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdministrativePercent",
                table: "ArMiscReceiptLines");
        }
    }
}
