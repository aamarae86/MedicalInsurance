using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class AddGlJeHeadersPostedAudited : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "PostTime",
                table: "GlJeHeaders",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PostUserId",
                table: "GlJeHeaders",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UnPostTime",
                table: "GlJeHeaders",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UnPostUserId",
                table: "GlJeHeaders",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PostTime",
                table: "GlJeHeaders");

            migrationBuilder.DropColumn(
                name: "PostUserId",
                table: "GlJeHeaders");

            migrationBuilder.DropColumn(
                name: "UnPostTime",
                table: "GlJeHeaders");

            migrationBuilder.DropColumn(
                name: "UnPostUserId",
                table: "GlJeHeaders");
        }
    }
}
