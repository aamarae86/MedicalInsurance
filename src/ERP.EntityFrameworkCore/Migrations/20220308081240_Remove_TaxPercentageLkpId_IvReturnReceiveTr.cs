using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class Remove_TaxPercentageLkpId_IvReturnReceiveTr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           
            migrationBuilder.DropForeignKey(
                name: "FK_IvReturnReceiveTr_FndLookupValues_TaxPercentageLkpId",
                table: "IvReturnReceiveTr");


            migrationBuilder.DropIndex(
                name: "IX_IvReturnReceiveTr_TaxPercentageLkpId",
                table: "IvReturnReceiveTr");

            migrationBuilder.DropColumn(
                name: "TaxPercentageLkpId",
                table: "IvReturnReceiveTr");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "FndTaxtypeId",
                table: "IvReturnReceiveTr",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TaxPercentageLkpId",
                table: "IvReturnReceiveTr",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_IvReturnReceiveTr_FndTaxtypeId",
                table: "IvReturnReceiveTr",
                column: "FndTaxtypeId");

            migrationBuilder.CreateIndex(
                name: "IX_IvReturnReceiveTr_TaxPercentageLkpId",
                table: "IvReturnReceiveTr",
                column: "TaxPercentageLkpId");

            migrationBuilder.AddForeignKey(
                name: "FK_IvReturnReceiveTr_FndTaxType_FndTaxtypeId",
                table: "IvReturnReceiveTr",
                column: "FndTaxtypeId",
                principalTable: "FndTaxType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IvReturnReceiveTr_FndLookupValues_TaxPercentageLkpId",
                table: "IvReturnReceiveTr",
                column: "TaxPercentageLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
