﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class removetestcolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Test",
                table: "Currencies");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Test",
                table: "Currencies",
                nullable: false,
                defaultValue: 0);
        }
    }
}
