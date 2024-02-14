using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class AddCoulmn_TaxPercentageLkpId_Ivitems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "TaxPercentageLkpId",
                table: "IvItems",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_IvItems_TaxPercentageLkpId",
                table: "IvItems",
                column: "TaxPercentageLkpId");

            migrationBuilder.AddForeignKey(
                name: "FK_IvItems_FndLookupValues_TaxPercentageLkpId",
                table: "IvItems",
                column: "TaxPercentageLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IvItems_FndLookupValues_TaxPercentageLkpId",
                table: "IvItems");

            migrationBuilder.DropIndex(
                name: "IX_IvItems_TaxPercentageLkpId",
                table: "IvItems");

            migrationBuilder.DropColumn(
                name: "TaxPercentageLkpId",
                table: "IvItems");
        }
    }
}
