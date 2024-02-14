using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class addColumninIvSaleHd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPOS",
                table: "IvSaleHd",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PaymentMethodLkpId",
                table: "IvSaleHd",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_IvSaleHd_PaymentMethodLkpId",
                table: "IvSaleHd",
                column: "PaymentMethodLkpId");

            migrationBuilder.AddForeignKey(
                name: "FK_IvSaleHd_FndLookupValues_PaymentMethodLkpId",
                table: "IvSaleHd",
                column: "PaymentMethodLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IvSaleHd_FndLookupValues_PaymentMethodLkpId",
                table: "IvSaleHd");

            migrationBuilder.DropIndex(
                name: "IX_IvSaleHd_PaymentMethodLkpId",
                table: "IvSaleHd");

            migrationBuilder.DropColumn(
                name: "IsPOS",
                table: "IvSaleHd");

            migrationBuilder.DropColumn(
                name: "PaymentMethodLkpId",
                table: "IvSaleHd");
        }
    }
}
