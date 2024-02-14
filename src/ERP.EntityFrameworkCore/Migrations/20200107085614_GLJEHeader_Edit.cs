using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class GLJEHeader_Edit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "PostedBy",
                table: "GlJeHeaders",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PostedDate",
                table: "GlJeHeaders",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UnPostedBy",
                table: "GlJeHeaders",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UnPostedDate",
                table: "GlJeHeaders",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PostedBy",
                table: "GlJeHeaders");

            migrationBuilder.DropColumn(
                name: "PostedDate",
                table: "GlJeHeaders");

            migrationBuilder.DropColumn(
                name: "UnPostedBy",
                table: "GlJeHeaders");

            migrationBuilder.DropColumn(
                name: "UnPostedDate",
                table: "GlJeHeaders");
        }
    }
}
