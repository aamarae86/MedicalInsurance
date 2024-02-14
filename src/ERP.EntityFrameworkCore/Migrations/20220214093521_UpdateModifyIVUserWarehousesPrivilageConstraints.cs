﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class UpdateModifyIVUserWarehousesPrivilageConstraints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
            name: "FK_IvUserWarehousesPrivileges_IvInventorySetting_IvInventorySettingId",
            table: "IvUserWarehousesPrivileges");


            migrationBuilder.AddForeignKey(
                      name: "FK_IvUserWarehousesPrivileges_IvInventorySetting_IvInventorySettingId",
                      table: "IvUserWarehousesPrivileges",
                      column: "IvInventorySettingId",
                      principalTable: "IvInventorySetting",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
             name: "FK_IvUserWarehousesPrivileges_IvInventorySetting_IvInventorySettingId",
             table: "IvUserWarehousesPrivileges");
        }
    }

}