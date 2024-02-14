using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class Fix_Table_addFullAudited_GlAccDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "GlJeLines",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                table: "GlJeLines",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "GlJeLines",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "GlJeLines",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "GlJeLines",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "GlJeLines",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "GlJeLines",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "GlJeLines",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "GlCodeComDetails",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                table: "GlCodeComDetails",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "GlCodeComDetails",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "GlCodeComDetails",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "GlCodeComDetails",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "GlCodeComDetails",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "GlCodeComDetails",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "GlAccDetails",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                table: "GlAccDetails",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "GlAccDetails",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "GlAccDetails",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "GlAccDetails",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "GlJeLines");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "GlJeLines");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "GlJeLines");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "GlJeLines");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "GlJeLines");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "GlJeLines");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "GlJeLines");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "GlJeLines");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "GlCodeComDetails");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "GlCodeComDetails");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "GlCodeComDetails");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "GlCodeComDetails");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "GlCodeComDetails");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "GlCodeComDetails");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "GlCodeComDetails");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "GlAccDetails");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "GlAccDetails");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "GlAccDetails");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "GlAccDetails");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "GlAccDetails");
        }
    }
}
