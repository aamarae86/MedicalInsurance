using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class removeCreditAccountFromPyElements : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PyElements_GlCodeComDetails_CreditAccountId",
                table: "PyElements");

            migrationBuilder.DropIndex(
                name: "IX_PyElements_CreditAccountId",
                table: "PyElements");

            migrationBuilder.DropColumn(
                name: "CreditAccountId",
                table: "PyElements");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CreditAccountId",
                table: "PyElements",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PyElements_CreditAccountId",
                table: "PyElements",
                column: "CreditAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_PyElements_GlCodeComDetails_CreditAccountId",
                table: "PyElements",
                column: "CreditAccountId",
                principalTable: "GlCodeComDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
