using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class Added_CreditNote_ArJobCardHd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "CreditNote",
                table: "ArJobCardHd",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreditNote",
                table: "ArJobCardHd");
        }
    }
}
