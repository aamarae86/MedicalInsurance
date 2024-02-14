using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class Update_IvSaleHd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscAmount",
                table: "IvSaleTr");

            migrationBuilder.DropColumn(
                name: "DiscAmount",
                table: "IvSaleHd");

            migrationBuilder.DropColumn(
                name: "DiscPercentage",
                table: "IvSaleHd");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "DiscAmount",
                table: "IvSaleTr",
                type: "decimal(18, 6)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "DiscAmount",
                table: "IvSaleHd",
                type: "decimal(18, 6)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "DiscPercentage",
                table: "IvSaleHd",
                type: "decimal(18, 6)",
                nullable: true);
        }
    }
}
