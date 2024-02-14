using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class PortalUser_TableInDBContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PortalUser_AbpUsers_UserId",
                table: "PortalUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PortalUser",
                table: "PortalUser");

            migrationBuilder.RenameTable(
                name: "PortalUser",
                newName: "PortalUsers");

            migrationBuilder.RenameIndex(
                name: "IX_PortalUser_UserId",
                table: "PortalUsers",
                newName: "IX_PortalUsers_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PortalUsers",
                table: "PortalUsers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PortalUsers_AbpUsers_UserId",
                table: "PortalUsers",
                column: "UserId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PortalUsers_AbpUsers_UserId",
                table: "PortalUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PortalUsers",
                table: "PortalUsers");

            migrationBuilder.RenameTable(
                name: "PortalUsers",
                newName: "PortalUser");

            migrationBuilder.RenameIndex(
                name: "IX_PortalUsers_UserId",
                table: "PortalUser",
                newName: "IX_PortalUser_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PortalUser",
                table: "PortalUser",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PortalUser_AbpUsers_UserId",
                table: "PortalUser",
                column: "UserId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
