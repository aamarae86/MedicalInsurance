using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class newColum_FullName_tblTenant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "AbpTenants",
                maxLength: 200,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullName",
                table: "AbpTenants");
        }
    }
}
