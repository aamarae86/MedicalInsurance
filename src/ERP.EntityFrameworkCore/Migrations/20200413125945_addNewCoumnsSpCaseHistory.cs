using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class addNewCoumnsSpCaseHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "SourceCodeLkpId",
                table: "SpCaseHistory",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SpCaseHistory_SourceCodeLkpId",
                table: "SpCaseHistory",
                column: "SourceCodeLkpId");

            migrationBuilder.AddForeignKey(
                name: "FK_SpCaseHistory_FndLookupValues_SourceCodeLkpId",
                table: "SpCaseHistory",
                column: "SourceCodeLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpCaseHistory_FndLookupValues_SourceCodeLkpId",
                table: "SpCaseHistory");

            migrationBuilder.DropIndex(
                name: "IX_SpCaseHistory_SourceCodeLkpId",
                table: "SpCaseHistory");

            migrationBuilder.DropColumn(
                name: "SourceCodeLkpId",
                table: "SpCaseHistory");
        }
    }
}
