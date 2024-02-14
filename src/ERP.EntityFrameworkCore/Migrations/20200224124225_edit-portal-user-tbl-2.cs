using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class editportalusertbl2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PortalUsers_AbpUsers_UserId",
                table: "PortalUsers");

            migrationBuilder.DropIndex(
                name: "IX_PortalUsers_UserId",
                table: "PortalUsers");

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "PortalUsers",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.CreateIndex(
                name: "IX_PortalUsers_UserId",
                table: "PortalUsers",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_PortalUsers_AbpUsers_UserId",
                table: "PortalUsers",
                column: "UserId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PortalUsers_AbpUsers_UserId",
                table: "PortalUsers");

            migrationBuilder.DropIndex(
                name: "IX_PortalUsers_UserId",
                table: "PortalUsers");

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "PortalUsers",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PortalUsers_UserId",
                table: "PortalUsers",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PortalUsers_AbpUsers_UserId",
                table: "PortalUsers",
                column: "UserId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
