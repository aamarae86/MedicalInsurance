using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class Edit_Misc_Header : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "ArMiscReceiptLines");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "ArMiscReceiptHeaders");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "ArMiscReceiptDetails");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "ArMiscReceiptLines",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "ArMiscReceiptHeaders",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "ArMiscReceiptDetails",
                nullable: false,
                defaultValue: false);
        }
    }
}
