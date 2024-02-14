using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class Added_GlJeHeaderId_To_GeneralUnPost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "GlJeHeaderId",
                table: "GeneralUnPost",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GeneralUnPost_GlJeHeaderId",
                table: "GeneralUnPost",
                column: "GlJeHeaderId");

            migrationBuilder.AddForeignKey(
                name: "FK_GeneralUnPost_GlJeHeaders_GlJeHeaderId",
                table: "GeneralUnPost",
                column: "GlJeHeaderId",
                principalTable: "GlJeHeaders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GeneralUnPost_GlJeHeaders_GlJeHeaderId",
                table: "GeneralUnPost");

            migrationBuilder.DropIndex(
                name: "IX_GeneralUnPost_GlJeHeaderId",
                table: "GeneralUnPost");

            migrationBuilder.DropColumn(
                name: "GlJeHeaderId",
                table: "GeneralUnPost");
        }
    }
}
