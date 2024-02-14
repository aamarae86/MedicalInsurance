using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class addPostAuditedScCampaigns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "PostTime",
                table: "ScCampains",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PostUserId",
                table: "ScCampains",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UnPostTime",
                table: "ScCampains",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UnPostUserId",
                table: "ScCampains",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PostTime",
                table: "ScCampains");

            migrationBuilder.DropColumn(
                name: "PostUserId",
                table: "ScCampains");

            migrationBuilder.DropColumn(
                name: "UnPostTime",
                table: "ScCampains");

            migrationBuilder.DropColumn(
                name: "UnPostUserId",
                table: "ScCampains");
        }
    }
}
