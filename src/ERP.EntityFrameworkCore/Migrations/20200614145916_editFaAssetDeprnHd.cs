using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class editFaAssetDeprnHd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FaAssetDeprnHd_GlPeriodsYears_PeriodId",
                table: "FaAssetDeprnHd");

            migrationBuilder.AddForeignKey(
                name: "FK_FaAssetDeprnHd_GlPeriodsDetails_PeriodId",
                table: "FaAssetDeprnHd",
                column: "PeriodId",
                principalTable: "GlPeriodsDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FaAssetDeprnHd_GlPeriodsDetails_PeriodId",
                table: "FaAssetDeprnHd");

            migrationBuilder.AddForeignKey(
                name: "FK_FaAssetDeprnHd_GlPeriodsYears_PeriodId",
                table: "FaAssetDeprnHd",
                column: "PeriodId",
                principalTable: "GlPeriodsYears",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
