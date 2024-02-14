using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class addingTblHrAbsencesTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HrAbsencesTypes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    AbsencesTypeNumber = table.Column<string>(maxLength: 30, nullable: true),
                    AbsencesTypeName = table.Column<string>(maxLength: 200, nullable: true),
                    AbsencesTypeDesc = table.Column<string>(maxLength: 4000, nullable: true),
                    MaximumDaysPerYear = table.Column<decimal>(type: "decimal(18, 6)", nullable: true),
                    MaximumDays = table.Column<decimal>(type: "decimal(18, 6)", nullable: true),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HrAbsencesTypes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HrAbsencesTypes");
        }
    }
}
