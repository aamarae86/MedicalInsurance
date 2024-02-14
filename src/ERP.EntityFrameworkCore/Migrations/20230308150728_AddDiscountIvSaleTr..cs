using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class AddDiscountIvSaleTr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Discount",
                table: "IvSaleTr",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discount",
                table: "IvSaleTr");
        }
    }
}
