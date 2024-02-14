using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class AddDiscountPercentageAllowed_SalesMen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DiscountPercentageAllowed",
                table: "FndSalesMen",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscountPercentageAllowed",
                table: "FndSalesMen");
        }
    }
}
