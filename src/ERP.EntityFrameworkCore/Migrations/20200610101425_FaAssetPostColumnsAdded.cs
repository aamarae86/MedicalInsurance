using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class FaAssetPostColumnsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "PostTime",
                table: "FaAssets",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PostUserId",
                table: "FaAssets",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UnPostTime",
                table: "FaAssets",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UnPostUserId",
                table: "FaAssets",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PostTime",
                table: "FaAssets");

            migrationBuilder.DropColumn(
                name: "PostUserId",
                table: "FaAssets");

            migrationBuilder.DropColumn(
                name: "UnPostTime",
                table: "FaAssets");

            migrationBuilder.DropColumn(
                name: "UnPostUserId",
                table: "FaAssets");
        }
    }
}
