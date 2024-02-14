using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class Remove_TaxPercentageLkpId_Ivsaletr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IvSaleTr_FndLookupValues_TaxPercentageLkpId",
                table: "IvSaleTr");

            migrationBuilder.DropIndex(
                name: "IX_IvSaleTr_TaxPercentageLkpId",
                table: "IvSaleTr");

            migrationBuilder.DropColumn(
                name: "TaxPercentageLkpId",
                table: "IvSaleTr");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "TaxPercentageLkpId",
                table: "IvSaleTr",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_IvSaleTr_TaxPercentageLkpId",
                table: "IvSaleTr",
                column: "TaxPercentageLkpId");

            migrationBuilder.AddForeignKey(
                name: "FK_IvSaleTr_FndLookupValues_TaxPercentageLkpId",
                table: "IvSaleTr",
                column: "TaxPercentageLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
