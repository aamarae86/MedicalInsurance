using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class parentInFndLookup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ParentId",
                table: "FndLookupValues",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FndLookupValues_ParentId",
                table: "FndLookupValues",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_FndLookupValues_FndLookupValues_ParentId",
                table: "FndLookupValues",
                column: "ParentId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FndLookupValues_FndLookupValues_ParentId",
                table: "FndLookupValues");

            migrationBuilder.DropIndex(
                name: "IX_FndLookupValues_ParentId",
                table: "FndLookupValues");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "FndLookupValues");
        }
    }
}
