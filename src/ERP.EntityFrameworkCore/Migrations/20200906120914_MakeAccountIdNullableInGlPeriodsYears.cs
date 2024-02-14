using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class MakeAccountIdNullableInGlPeriodsYears : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GlPeriodsYears_GlCodeComDetails_AccountId",
                table: "GlPeriodsYears");

            migrationBuilder.AlterColumn<long>(
                name: "AccountId",
                table: "GlPeriodsYears",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddForeignKey(
                name: "FK_GlPeriodsYears_GlCodeComDetails_AccountId",
                table: "GlPeriodsYears",
                column: "AccountId",
                principalTable: "GlCodeComDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GlPeriodsYears_GlCodeComDetails_AccountId",
                table: "GlPeriodsYears");

            migrationBuilder.AlterColumn<long>(
                name: "AccountId",
                table: "GlPeriodsYears",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_GlPeriodsYears_GlCodeComDetails_AccountId",
                table: "GlPeriodsYears",
                column: "AccountId",
                principalTable: "GlCodeComDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
