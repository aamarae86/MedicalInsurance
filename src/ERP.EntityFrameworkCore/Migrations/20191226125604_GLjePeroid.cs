using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class GLjePeroid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GlJeHeaders_GlPeriodsDetails_GlPeriodsDetailsId",
                table: "GlJeHeaders");

            migrationBuilder.DropIndex(
                name: "IX_GlJeHeaders_GlPeriodsDetailsId",
                table: "GlJeHeaders");

            migrationBuilder.DropColumn(
                name: "GlPeriodsDetailsId",
                table: "GlJeHeaders");

            migrationBuilder.CreateIndex(
                name: "IX_GlJeHeaders_PeriodId",
                table: "GlJeHeaders",
                column: "PeriodId");

            migrationBuilder.AddForeignKey(
                name: "FK_GlJeHeaders_GlPeriodsDetails_PeriodId",
                table: "GlJeHeaders",
                column: "PeriodId",
                principalTable: "GlPeriodsDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GlJeHeaders_GlPeriodsDetails_PeriodId",
                table: "GlJeHeaders");

            migrationBuilder.DropIndex(
                name: "IX_GlJeHeaders_PeriodId",
                table: "GlJeHeaders");

            migrationBuilder.AddColumn<long>(
                name: "GlPeriodsDetailsId",
                table: "GlJeHeaders",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GlJeHeaders_GlPeriodsDetailsId",
                table: "GlJeHeaders",
                column: "GlPeriodsDetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_GlJeHeaders_GlPeriodsDetails_GlPeriodsDetailsId",
                table: "GlJeHeaders",
                column: "GlPeriodsDetailsId",
                principalTable: "GlPeriodsDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
