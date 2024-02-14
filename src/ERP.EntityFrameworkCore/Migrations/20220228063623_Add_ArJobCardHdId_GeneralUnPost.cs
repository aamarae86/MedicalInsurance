using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class Add_ArJobCardHdId_GeneralUnPost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ArJobCardHdId",
                table: "GeneralUnPost",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GeneralUnPost_ArJobCardHdId",
                table: "GeneralUnPost",
                column: "ArJobCardHdId");

            migrationBuilder.AddForeignKey(
                name: "FK_GeneralUnPost_ArJobCardHd_ArJobCardHdId",
                table: "GeneralUnPost",
                column: "ArJobCardHdId",
                principalTable: "ArJobCardHd",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GeneralUnPost_ArJobCardHd_ArJobCardHdId",
                table: "GeneralUnPost");

            migrationBuilder.DropIndex(
                name: "IX_GeneralUnPost_ArJobCardHdId",
                table: "GeneralUnPost");

            migrationBuilder.DropColumn(
                name: "ArJobCardHdId",
                table: "GeneralUnPost");
        }
    }
}
