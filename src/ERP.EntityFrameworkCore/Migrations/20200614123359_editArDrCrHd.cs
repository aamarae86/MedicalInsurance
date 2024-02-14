using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class editArDrCrHd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "PostTime",
                table: "ArDrCrHd",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PostUserId",
                table: "ArDrCrHd",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UnPostTime",
                table: "ArDrCrHd",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UnPostUserId",
                table: "ArDrCrHd",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FaAssetDeprnTrDtl_AccountId",
                table: "FaAssetDeprnTrDtl",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_FaAssetDeprnTrDtl_GlCodeComDetails_AccountId",
                table: "FaAssetDeprnTrDtl",
                column: "AccountId",
                principalTable: "GlCodeComDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FaAssetDeprnTrDtl_GlCodeComDetails_AccountId",
                table: "FaAssetDeprnTrDtl");

            migrationBuilder.DropIndex(
                name: "IX_FaAssetDeprnTrDtl_AccountId",
                table: "FaAssetDeprnTrDtl");

            migrationBuilder.DropColumn(
                name: "PostTime",
                table: "ArDrCrHd");

            migrationBuilder.DropColumn(
                name: "PostUserId",
                table: "ArDrCrHd");

            migrationBuilder.DropColumn(
                name: "UnPostTime",
                table: "ArDrCrHd");

            migrationBuilder.DropColumn(
                name: "UnPostUserId",
                table: "ArDrCrHd");
        }
    }
}
