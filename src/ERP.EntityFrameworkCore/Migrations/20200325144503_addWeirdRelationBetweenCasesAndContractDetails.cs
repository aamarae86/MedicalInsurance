using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class addWeirdRelationBetweenCasesAndContractDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<long>(
                name: "SpContractDetails",
                table: "SpCases",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "SpContractDetailsId",
                table: "SpCases",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SpContractDetails_SpBeneficentBankId",
                table: "SpContractDetails",
                column: "SpBeneficentBankId");

            migrationBuilder.CreateIndex(
                name: "IX_SpCases_SpContractDetailsId",
                table: "SpCases",
                column: "SpContractDetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_SpCases_SpContractDetails_SpContractDetailsId",
                table: "SpCases",
                column: "SpContractDetailsId",
                principalTable: "SpContractDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SpContractDetails_SpBeneficentBanks_SpBeneficentBankId",
                table: "SpContractDetails",
                column: "SpBeneficentBankId",
                principalTable: "SpBeneficentBanks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpCases_SpContractDetails_SpContractDetailsId",
                table: "SpCases");

            migrationBuilder.DropForeignKey(
                name: "FK_SpContractDetails_SpBeneficentBanks_SpBeneficentBankId",
                table: "SpContractDetails");

            migrationBuilder.DropIndex(
                name: "IX_SpContractDetails_SpBeneficentBankId",
                table: "SpContractDetails");

            migrationBuilder.DropIndex(
                name: "IX_SpCases_SpContractDetailsId",
                table: "SpCases");

            migrationBuilder.DropColumn(
                name: "SpContractDetails",
                table: "SpCases");

            migrationBuilder.DropColumn(
                name: "SpContractDetailsId",
                table: "SpCases");

        }
    }
}
