using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class addContractpost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "PostTime",
                table: "FmContracts",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PostUserId",
                table: "FmContracts",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UnPostTime",
                table: "FmContracts",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UnPostUserId",
                table: "FmContracts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PostTime",
                table: "FmContracts");

            migrationBuilder.DropColumn(
                name: "PostUserId",
                table: "FmContracts");

            migrationBuilder.DropColumn(
                name: "UnPostTime",
                table: "FmContracts");

            migrationBuilder.DropColumn(
                name: "UnPostUserId",
                table: "FmContracts");
        }
    }
}
