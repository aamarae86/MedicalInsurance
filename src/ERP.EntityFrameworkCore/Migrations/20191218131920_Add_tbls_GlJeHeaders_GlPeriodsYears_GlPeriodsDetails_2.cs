using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class Add_tbls_GlJeHeaders_GlPeriodsYears_GlPeriodsDetails_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateIndex(
                name: "IX_GlJeHeaders_JeSourceLkpId",
                table: "GlJeHeaders",
                column: "JeSourceLkpId");

            migrationBuilder.AddForeignKey(
                name: "FK_GlJeHeaders_GlPeriodsDetails_GlPeriodsDetailsId",
                table: "GlJeHeaders",
                column: "GlPeriodsDetailsId",
                principalTable: "GlPeriodsDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GlJeHeaders_FndLookupValues_JeSourceLkpId",
                table: "GlJeHeaders",
                column: "JeSourceLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GlJeHeaders_GlPeriodsDetails_GlPeriodsDetailsId",
                table: "GlJeHeaders");

            migrationBuilder.DropForeignKey(
                name: "FK_GlJeHeaders_FndLookupValues_JeSourceLkpId",
                table: "GlJeHeaders");

            migrationBuilder.DropIndex(
                name: "IX_GlJeHeaders_GlPeriodsDetailsId",
                table: "GlJeHeaders");

            migrationBuilder.DropIndex(
                name: "IX_GlJeHeaders_JeSourceLkpId",
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
    }
}
