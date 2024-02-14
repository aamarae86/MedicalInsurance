using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class Update_Userid_IVUserWarehousesPrivilage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IvUserWarehousesPrivileges_AbpUsers_UserId",
                table: "IvUserWarehousesPrivileges");

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "IvUserWarehousesPrivileges",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddForeignKey(
                name: "FK_IvUserWarehousesPrivileges_AbpUsers_UserId",
                table: "IvUserWarehousesPrivileges",
                column: "UserId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IvUserWarehousesPrivileges_AbpUsers_UserId",
                table: "IvUserWarehousesPrivileges");

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "IvUserWarehousesPrivileges",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_IvUserWarehousesPrivileges_AbpUsers_UserId",
                table: "IvUserWarehousesPrivileges",
                column: "UserId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
