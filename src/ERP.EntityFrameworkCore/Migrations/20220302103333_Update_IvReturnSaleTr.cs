using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class Update_IvReturnSaleTr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IvReturnSaleTr_FndLookupValues_TaxPercentageLkpId",
                table: "IvReturnSaleTr");

            migrationBuilder.AlterColumn<long>(
                name: "TaxPercentageLkpId",
                table: "IvReturnSaleTr",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddForeignKey(
                name: "FK_IvReturnSaleTr_FndLookupValues_TaxPercentageLkpId",
                table: "IvReturnSaleTr",
                column: "TaxPercentageLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IvReturnSaleTr_FndLookupValues_TaxPercentageLkpId",
                table: "IvReturnSaleTr");

            migrationBuilder.AlterColumn<long>(
                name: "TaxPercentageLkpId",
                table: "IvReturnSaleTr",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_IvReturnSaleTr_FndLookupValues_TaxPercentageLkpId",
                table: "IvReturnSaleTr",
                column: "TaxPercentageLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
