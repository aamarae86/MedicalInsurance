using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class Add_FndTaxtypeIdColumn_IvReturnSaleTr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "FndTaxtypeId",
                table: "IvReturnSaleTr",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_IvReturnSaleTr_FndTaxtypeId",
                table: "IvReturnSaleTr",
                column: "FndTaxtypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_IvReturnSaleTr_FndTaxType_FndTaxtypeId",
                table: "IvReturnSaleTr",
                column: "FndTaxtypeId",
                principalTable: "FndTaxType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IvReturnSaleTr_FndTaxType_FndTaxtypeId",
                table: "IvReturnSaleTr");

            migrationBuilder.DropIndex(
                name: "IX_IvReturnSaleTr_FndTaxtypeId",
                table: "IvReturnSaleTr");

            migrationBuilder.DropColumn(
                name: "FndTaxtypeId",
                table: "IvReturnSaleTr");
        }
    }
}
