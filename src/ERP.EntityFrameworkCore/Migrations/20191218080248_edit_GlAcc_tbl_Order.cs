using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class edit_GlAcc_tbl_Order : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "GlAccHeaders");

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "GlAccHeaders",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Order",
                table: "GlAccHeaders");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "GlAccHeaders",
                maxLength: 100,
                nullable: true);
        }
    }
}
