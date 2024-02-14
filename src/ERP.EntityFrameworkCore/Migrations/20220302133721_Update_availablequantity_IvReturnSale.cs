using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class Update_availablequantity_IvReturnSale : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Avilablequantity",
                table: "IvReturnSaleTr",
                type: "decimal(18, 6)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Avilablequantity",
                table: "IvReturnSaleTr");
        }
    }
}
