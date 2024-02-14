using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class AddNewFieldGlAccounts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "IdMap",
                table: "GlAccounts",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ParentIdMap",
                table: "GlAccounts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdMap",
                table: "GlAccounts");

            migrationBuilder.DropColumn(
                name: "ParentIdMap",
                table: "GlAccounts");
        }
    }
}
