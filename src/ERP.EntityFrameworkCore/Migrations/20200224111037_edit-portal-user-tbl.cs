using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class editportalusertbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "JobWife2",
                table: "PortalUsers",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JobWife3",
                table: "PortalUsers",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JobWife4",
                table: "PortalUsers",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JobWifeHusband1",
                table: "PortalUsers",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PassportExpiryDate",
                table: "PortalUsers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PassportIssueDate",
                table: "PortalUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PassportNumber",
                table: "PortalUsers",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ResidenceEndDate",
                table: "PortalUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UnifiedNumber",
                table: "PortalUsers",
                maxLength: 100,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JobWife2",
                table: "PortalUsers");

            migrationBuilder.DropColumn(
                name: "JobWife3",
                table: "PortalUsers");

            migrationBuilder.DropColumn(
                name: "JobWife4",
                table: "PortalUsers");

            migrationBuilder.DropColumn(
                name: "JobWifeHusband1",
                table: "PortalUsers");

            migrationBuilder.DropColumn(
                name: "PassportExpiryDate",
                table: "PortalUsers");

            migrationBuilder.DropColumn(
                name: "PassportIssueDate",
                table: "PortalUsers");

            migrationBuilder.DropColumn(
                name: "PassportNumber",
                table: "PortalUsers");

            migrationBuilder.DropColumn(
                name: "ResidenceEndDate",
                table: "PortalUsers");

            migrationBuilder.DropColumn(
                name: "UnifiedNumber",
                table: "PortalUsers");
        }
    }
}
