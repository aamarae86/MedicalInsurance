using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class addExtraInfoToTenent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "AdminValue",
                table: "AbpTenants",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SubEndDate",
                table: "AbpTenants",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "UserValue",
                table: "AbpTenants",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdminValue",
                table: "AbpTenants");

            migrationBuilder.DropColumn(
                name: "SubEndDate",
                table: "AbpTenants");

            migrationBuilder.DropColumn(
                name: "UserValue",
                table: "AbpTenants");
        }
    }
}
