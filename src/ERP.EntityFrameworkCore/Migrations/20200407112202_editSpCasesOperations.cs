using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class editSpCasesOperations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "SpNewContractDetailsId",
                table: "SpCaseOperations",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SpCaseOperations_SpNewContractDetailsId",
                table: "SpCaseOperations",
                column: "SpNewContractDetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_SpCaseOperations_SpContractDetails_SpNewContractDetailsId",
                table: "SpCaseOperations",
                column: "SpNewContractDetailsId",
                principalTable: "SpContractDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpCaseOperations_SpContractDetails_SpNewContractDetailsId",
                table: "SpCaseOperations");

            migrationBuilder.DropIndex(
                name: "IX_SpCaseOperations_SpNewContractDetailsId",
                table: "SpCaseOperations");

            migrationBuilder.DropColumn(
                name: "SpNewContractDetailsId",
                table: "SpCaseOperations");
        }
    }
}
