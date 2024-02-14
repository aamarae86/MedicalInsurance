using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class addUserId_FndSalesMen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "FndSalesMen",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FndSalesMen_UserId",
                table: "FndSalesMen",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_FndSalesMen_AbpUsers_UserId",
                table: "FndSalesMen",
                column: "UserId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FndSalesMen_AbpUsers_UserId",
                table: "FndSalesMen");

            migrationBuilder.DropIndex(
                name: "IX_FndSalesMen_UserId",
                table: "FndSalesMen");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "FndSalesMen");
        }
    }
}
