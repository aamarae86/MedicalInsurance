using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class calenderMayHaveTenant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TenantId",
                table: "CalenderNotes",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TenantId",
                table: "CalenderNotes",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
