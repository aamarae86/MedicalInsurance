using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class UserRelationWithAPUserBankAccess : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ApUserBankAccess_UserId",
                table: "ApUserBankAccess",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApUserBankAccess_AbpUsers_UserId",
                table: "ApUserBankAccess",
                column: "UserId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApUserBankAccess_AbpUsers_UserId",
                table: "ApUserBankAccess");

            migrationBuilder.DropIndex(
                name: "IX_ApUserBankAccess_UserId",
                table: "ApUserBankAccess");
        }
    }
}
