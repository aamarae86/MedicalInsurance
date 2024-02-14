using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class Add_FndTaxtypeIdColumn_ApDrCrTr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "FndTaxtypeId",
                table: "ApDrCrTr",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApDrCrTr_FndTaxtypeId",
                table: "ApDrCrTr",
                column: "FndTaxtypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApDrCrTr_FndTaxType_FndTaxtypeId",
                table: "ApDrCrTr",
                column: "FndTaxtypeId",
                principalTable: "FndTaxType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApDrCrTr_FndTaxType_FndTaxtypeId",
                table: "ApDrCrTr");

            migrationBuilder.DropIndex(
                name: "IX_ApDrCrTr_FndTaxtypeId",
                table: "ApDrCrTr");

            migrationBuilder.DropColumn(
                name: "FndTaxtypeId",
                table: "ApDrCrTr");
        }
    }
}
