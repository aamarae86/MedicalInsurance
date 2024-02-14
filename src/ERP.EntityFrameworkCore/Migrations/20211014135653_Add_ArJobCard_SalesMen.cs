using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class Add_ArJobCard_SalesMen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArJobCardHd_FndLookupValues_ExcessStatusLkpId",
                table: "ArJobCardHd");

            migrationBuilder.DropForeignKey(
                name: "FK_ArJobCardHd_FndLookupValues_StatusLkpId",
                table: "ArJobCardHd");

            migrationBuilder.AlterColumn<long>(
                name: "StatusLkpId",
                table: "ArJobCardHd",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "ExcessStatusLkpId",
                table: "ArJobCardHd",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddColumn<decimal>(
                name: "DiscountAmount",
                table: "ArJobCardHd",
                type: "decimal(18,6)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "FndSalesMenId",
                table: "ArJobCardHd",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ArJobCardHd_FndSalesMenId",
                table: "ArJobCardHd",
                column: "FndSalesMenId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArJobCardHd_FndLookupValues_ExcessStatusLkpId",
                table: "ArJobCardHd",
                column: "ExcessStatusLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ArJobCardHd_FndSalesMen_FndSalesMenId",
                table: "ArJobCardHd",
                column: "FndSalesMenId",
                principalTable: "FndSalesMen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ArJobCardHd_FndLookupValues_StatusLkpId",
                table: "ArJobCardHd",
                column: "StatusLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArJobCardHd_FndLookupValues_ExcessStatusLkpId",
                table: "ArJobCardHd");

            migrationBuilder.DropForeignKey(
                name: "FK_ArJobCardHd_FndSalesMen_FndSalesMenId",
                table: "ArJobCardHd");

            migrationBuilder.DropForeignKey(
                name: "FK_ArJobCardHd_FndLookupValues_StatusLkpId",
                table: "ArJobCardHd");

            migrationBuilder.DropIndex(
                name: "IX_ArJobCardHd_FndSalesMenId",
                table: "ArJobCardHd");

            migrationBuilder.DropColumn(
                name: "DiscountAmount",
                table: "ArJobCardHd");

            migrationBuilder.DropColumn(
                name: "FndSalesMenId",
                table: "ArJobCardHd");

            migrationBuilder.AlterColumn<long>(
                name: "StatusLkpId",
                table: "ArJobCardHd",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ExcessStatusLkpId",
                table: "ArJobCardHd",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ArJobCardHd_FndLookupValues_ExcessStatusLkpId",
                table: "ArJobCardHd",
                column: "ExcessStatusLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArJobCardHd_FndLookupValues_StatusLkpId",
                table: "ArJobCardHd",
                column: "StatusLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
