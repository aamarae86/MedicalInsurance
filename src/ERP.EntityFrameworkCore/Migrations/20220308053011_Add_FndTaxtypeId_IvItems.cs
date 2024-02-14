using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class Add_FndTaxtypeId_IvItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "FndTaxtypeId",
                table: "IvItems",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_IvItems_FndTaxtypeId",
                table: "IvItems",
                column: "FndTaxtypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_IvItems_FndTaxType_FndTaxtypeId",
                table: "IvItems",
                column: "FndTaxtypeId",
                principalTable: "FndTaxType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IvItems_FndTaxType_FndTaxtypeId",
                table: "IvItems");

            migrationBuilder.DropIndex(
                name: "IX_IvItems_FndTaxtypeId",
                table: "IvItems");

            migrationBuilder.DropColumn(
                name: "FndTaxtypeId",
                table: "IvItems");
        }
    }
}
