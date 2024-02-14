using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class update_IsaleHd_SalesmanId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IvSaleHd_FndSalesMen_FndSalesMenId",
                table: "IvSaleHd");

            migrationBuilder.AlterColumn<long>(
                name: "FndSalesMenId",
                table: "IvSaleHd",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_IvSaleHd_FndSalesMen_FndSalesMenId",
                table: "IvSaleHd",
                column: "FndSalesMenId",
                principalTable: "FndSalesMen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IvSaleHd_FndSalesMen_FndSalesMenId",
                table: "IvSaleHd");

            migrationBuilder.AlterColumn<long>(
                name: "FndSalesMenId",
                table: "IvSaleHd",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddForeignKey(
                name: "FK_IvSaleHd_FndSalesMen_FndSalesMenId",
                table: "IvSaleHd",
                column: "FndSalesMenId",
                principalTable: "FndSalesMen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
