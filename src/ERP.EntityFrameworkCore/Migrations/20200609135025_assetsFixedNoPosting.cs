using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class assetsFixedNoPosting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "FaAssets",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 4000,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "FaAssets",
                maxLength: 4000,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200,
                oldNullable: true);

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
    }
}
