using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class fixSpCases : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "RelativesTypeLkpId",
                table: "SpCases",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SpCases_RelativesTypeLkpId",
                table: "SpCases",
                column: "RelativesTypeLkpId");

            migrationBuilder.AddForeignKey(
                name: "FK_SpCases_FndLookupValues_RelativesTypeLkpId",
                table: "SpCases",
                column: "RelativesTypeLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpCases_FndLookupValues_RelativesTypeLkpId",
                table: "SpCases");

            migrationBuilder.DropIndex(
                name: "IX_SpCases_RelativesTypeLkpId",
                table: "SpCases");

            migrationBuilder.DropColumn(
                name: "RelativesTypeLkpId",
                table: "SpCases");
        }
    }
}
