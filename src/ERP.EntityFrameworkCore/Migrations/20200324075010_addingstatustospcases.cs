using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class addingstatustospcases : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "StatusLkpId",
                table: "SpCases",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SpCases_StatusLkpId",
                table: "SpCases",
                column: "StatusLkpId");

            migrationBuilder.AddForeignKey(
                name: "FK_SpCases_FndLookupValues_StatusLkpId",
                table: "SpCases",
                column: "StatusLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpCases_FndLookupValues_StatusLkpId",
                table: "SpCases");

            migrationBuilder.DropIndex(
                name: "IX_SpCases_StatusLkpId",
                table: "SpCases");

            migrationBuilder.DropColumn(
                name: "StatusLkpId",
                table: "SpCases");
        }
    }
}
