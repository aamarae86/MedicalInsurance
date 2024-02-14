using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class addTenentlogo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Filepath",
                table: "AbpTenants",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Filepath",
                table: "AbpTenants");
        }
    }
}
