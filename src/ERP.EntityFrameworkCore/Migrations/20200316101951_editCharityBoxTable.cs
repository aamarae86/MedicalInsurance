using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class editCharityBoxTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "InternalCounterPerType",
                table: "TmCharityBoxes",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TmCharityBoxReceiveId",
                table: "TmCharityBoxes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TmCharityBoxes_TmCharityBoxReceiveId",
                table: "TmCharityBoxes",
                column: "TmCharityBoxReceiveId");

            migrationBuilder.AddForeignKey(
                name: "FK_TmCharityBoxes_TmCharityBoxReceive_TmCharityBoxReceiveId",
                table: "TmCharityBoxes",
                column: "TmCharityBoxReceiveId",
                principalTable: "TmCharityBoxReceive",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TmCharityBoxes_TmCharityBoxReceive_TmCharityBoxReceiveId",
                table: "TmCharityBoxes");

            migrationBuilder.DropIndex(
                name: "IX_TmCharityBoxes_TmCharityBoxReceiveId",
                table: "TmCharityBoxes");

            migrationBuilder.DropColumn(
                name: "InternalCounterPerType",
                table: "TmCharityBoxes");

            migrationBuilder.DropColumn(
                name: "TmCharityBoxReceiveId",
                table: "TmCharityBoxes");
        }
    }
}
