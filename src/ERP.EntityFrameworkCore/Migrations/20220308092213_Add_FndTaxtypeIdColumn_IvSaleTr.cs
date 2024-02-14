using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class Add_FndTaxtypeIdColumn_IvSaleTr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "FndTaxtypeId",
                table: "IvSaleTr",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_IvSaleTr_FndTaxtypeId",
                table: "IvSaleTr",
                column: "FndTaxtypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_IvSaleTr_FndTaxType_FndTaxtypeId",
                table: "IvSaleTr",
                column: "FndTaxtypeId",
                principalTable: "FndTaxType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IvSaleTr_FndTaxType_FndTaxtypeId",
                table: "IvSaleTr");

            migrationBuilder.DropIndex(
                name: "IX_IvSaleTr_FndTaxtypeId",
                table: "IvSaleTr");

            migrationBuilder.DropColumn(
                name: "FndTaxtypeId",
                table: "IvSaleTr");
        }
    }
}
