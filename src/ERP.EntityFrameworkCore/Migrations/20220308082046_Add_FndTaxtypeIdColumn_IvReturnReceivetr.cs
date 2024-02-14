using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class Add_FndTaxtypeIdColumn_IvReturnReceivetr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "FndTaxtypeId",
                table: "IvReturnReceiveTr",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_IvReturnReceiveTr_FndTaxtypeId",
                table: "IvReturnReceiveTr",
                column: "FndTaxtypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_IvReturnReceiveTr_FndTaxType_FndTaxtypeId",
                table: "IvReturnReceiveTr",
                column: "FndTaxtypeId",
                principalTable: "FndTaxType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IvReturnReceiveTr_FndTaxType_FndTaxtypeId",
                table: "IvReturnReceiveTr");

            migrationBuilder.DropIndex(
                name: "IX_IvReturnReceiveTr_FndTaxtypeId",
                table: "IvReturnReceiveTr");

            migrationBuilder.DropColumn(
                name: "FndTaxtypeId",
                table: "IvReturnReceiveTr");
        }
    }
}
