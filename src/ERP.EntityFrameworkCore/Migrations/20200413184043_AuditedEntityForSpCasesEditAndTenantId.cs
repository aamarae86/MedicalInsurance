using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class AuditedEntityForSpCasesEditAndTenantId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "SpCaseEditData",
                nullable: false,
                defaultValue: new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                table: "SpCaseEditData",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "SpCaseEditData",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "SpCaseEditData",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "SpCaseEditData",
                nullable: false,
                defaultValue: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "SpCaseEditData");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "SpCaseEditData");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "SpCaseEditData");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "SpCaseEditData");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "SpCaseEditData");
        }
    }
}
