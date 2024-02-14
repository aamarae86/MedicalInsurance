using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class addingColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ChqReturnResonLKPId",
                table: "ApPdcInterface",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApPdcInterface_ChqReturnResonLKPId",
                table: "ApPdcInterface",
                column: "ChqReturnResonLKPId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApPdcInterface_FndLookupValues_ChqReturnResonLKPId",
                table: "ApPdcInterface",
                column: "ChqReturnResonLKPId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApPdcInterface_FndLookupValues_ChqReturnResonLKPId",
                table: "ApPdcInterface");

            migrationBuilder.DropIndex(
                name: "IX_ApPdcInterface_ChqReturnResonLKPId",
                table: "ApPdcInterface");

            migrationBuilder.DropColumn(
                name: "ChqReturnResonLKPId",
                table: "ApPdcInterface");
        }
    }
}
