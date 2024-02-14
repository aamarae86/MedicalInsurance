using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class Remove_TaxPercentageLkpId_IvsaleReturnTr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IvReturnSaleTr_FndLookupValues_TaxPercentageLkpId",
                table: "IvReturnSaleTr");

            migrationBuilder.DropIndex(
                name: "IX_IvReturnSaleTr_TaxPercentageLkpId",
                table: "IvReturnSaleTr");

            migrationBuilder.DropColumn(
                name: "TaxPercentageLkpId",
                table: "IvReturnSaleTr");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "TaxPercentageLkpId",
                table: "IvReturnSaleTr",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_IvReturnSaleTr_TaxPercentageLkpId",
                table: "IvReturnSaleTr",
                column: "TaxPercentageLkpId");

            migrationBuilder.AddForeignKey(
                name: "FK_IvReturnSaleTr_FndLookupValues_TaxPercentageLkpId",
                table: "IvReturnSaleTr",
                column: "TaxPercentageLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
