using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class levelfloorfrominttostringinpmunits : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FloorLevel",
                table: "PmPropertiesUnits",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "FloorLevel",
                table: "PmPropertiesUnits",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 30,
                oldNullable: true);
        }
    }
}
