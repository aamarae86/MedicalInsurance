using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class AddMetadataForCRMLead : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ConvertDate",
                table: "CrmLeadsPersons",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UserConvertId",
                table: "CrmLeadsPersons",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "WasLead",
                table: "CrmLeadsPersons",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConvertDate",
                table: "CrmLeadsPersons");

            migrationBuilder.DropColumn(
                name: "UserConvertId",
                table: "CrmLeadsPersons");

            migrationBuilder.DropColumn(
                name: "WasLead",
                table: "CrmLeadsPersons");
        }
    }
}
