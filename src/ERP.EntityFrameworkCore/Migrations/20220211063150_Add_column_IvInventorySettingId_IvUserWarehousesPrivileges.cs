using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class Add_column_IvInventorySettingId_IvUserWarehousesPrivileges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "IvInventorySettingId",
                table: "IvUserWarehousesPrivileges",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_IvUserWarehousesPrivileges_IvInventorySettingId",
                table: "IvUserWarehousesPrivileges",
                column: "IvInventorySettingId");

            migrationBuilder.AddForeignKey(
                name: "FK_IvUserWarehousesPrivileges_IvInventorySetting_IvInventorySettingId",
                table: "IvUserWarehousesPrivileges",
                column: "IvInventorySettingId",
                principalTable: "IvInventorySetting",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IvUserWarehousesPrivileges_IvInventorySetting_IvInventorySettingId",
                table: "IvUserWarehousesPrivileges");

            migrationBuilder.DropIndex(
                name: "IX_IvUserWarehousesPrivileges_IvInventorySettingId",
                table: "IvUserWarehousesPrivileges");

            migrationBuilder.DropColumn(
                name: "IvInventorySettingId",
                table: "IvUserWarehousesPrivileges");
        }
    }
}
