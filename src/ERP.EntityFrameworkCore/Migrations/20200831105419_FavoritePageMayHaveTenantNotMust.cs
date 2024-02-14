using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class FavoritePageMayHaveTenantNotMust : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TenantId",
                table: "FavoritePages",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TenantId",
                table: "FavoritePages",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
