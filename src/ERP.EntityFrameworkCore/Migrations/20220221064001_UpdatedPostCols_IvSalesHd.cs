using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class UpdatedPostCols_IvSalesHd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "PostTime",
                table: "IvSaleHd",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PostUserId",
                table: "IvSaleHd",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UnPostTime",
                table: "IvSaleHd",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UnPostUserId",
                table: "IvSaleHd",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PostTime",
                table: "IvSaleHd");

            migrationBuilder.DropColumn(
                name: "PostUserId",
                table: "IvSaleHd");

            migrationBuilder.DropColumn(
                name: "UnPostTime",
                table: "IvSaleHd");

            migrationBuilder.DropColumn(
                name: "UnPostUserId",
                table: "IvSaleHd");
        }
    }
}
