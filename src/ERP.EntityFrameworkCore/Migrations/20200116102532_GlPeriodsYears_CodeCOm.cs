using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class GlPeriodsYears_CodeCOm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_GlPeriodsYears_AccountId",
                table: "GlPeriodsYears",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_GlPeriodsYears_GlCodeComDetails_AccountId",
                table: "GlPeriodsYears",
                column: "AccountId",
                principalTable: "GlCodeComDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GlPeriodsYears_GlCodeComDetails_AccountId",
                table: "GlPeriodsYears");

            migrationBuilder.DropIndex(
                name: "IX_GlPeriodsYears_AccountId",
                table: "GlPeriodsYears");
        }
    }
}
