using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class AddDeliveryChargesAndDiscount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "DeliveryCharges",
                table: "IvSaleHd",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Discount",
                table: "IvSaleHd",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeliveryCharges",
                table: "IvSaleHd");

            migrationBuilder.DropColumn(
                name: "Discount",
                table: "IvSaleHd");
        }
    }
}
