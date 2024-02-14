using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class reedit_GlAcc_tbl_ShowOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Order",
                table: "GlAccHeaders",
                newName: "ShowOrder");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShowOrder",
                table: "GlAccHeaders",
                newName: "Order");
        }
    }
}
