using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class addWeirdRelationBetweenCasesAndContractDetailsFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SpCases_SpContractDetailsId",
                table: "SpCases");

            migrationBuilder.DropColumn(
                name: "SpContractDetails",
                table: "SpCases");

            migrationBuilder.CreateIndex(
                name: "IX_SpCases_SpContractDetailsId",
                table: "SpCases",
                column: "SpContractDetailsId",
                unique: true,
                filter: "[SpContractDetailsId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SpCases_SpContractDetailsId",
                table: "SpCases");

            migrationBuilder.AddColumn<long>(
                name: "SpContractDetails",
                table: "SpCases",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SpCases_SpContractDetailsId",
                table: "SpCases",
                column: "SpContractDetailsId");
        }
    }
}
