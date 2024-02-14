using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class Add_FndTaxtypeIdColumn_ArDrCrTr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "FndTaxtypeId",
                table: "ArDrCrTr",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ArDrCrTr_FndTaxtypeId",
                table: "ArDrCrTr",
                column: "FndTaxtypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArDrCrTr_FndTaxType_FndTaxtypeId",
                table: "ArDrCrTr",
                column: "FndTaxtypeId",
                principalTable: "FndTaxType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArDrCrTr_FndTaxType_FndTaxtypeId",
                table: "ArDrCrTr");

            migrationBuilder.DropIndex(
                name: "IX_ArDrCrTr_FndTaxtypeId",
                table: "ArDrCrTr");

            migrationBuilder.DropColumn(
                name: "FndTaxtypeId",
                table: "ArDrCrTr");
        }
    }
}
