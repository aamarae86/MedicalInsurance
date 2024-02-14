using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class crmProjects : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CrmProjects",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    PostUserId = table.Column<long>(nullable: true),
                    PostTime = table.Column<DateTime>(nullable: true),
                    UnPostUserId = table.Column<long>(nullable: true),
                    UnPostTime = table.Column<DateTime>(nullable: true),
                    ProjectDate = table.Column<DateTime>(nullable: false),
                    ProjectNameAr = table.Column<string>(maxLength: 200, nullable: true),
                    ProjectNameEn = table.Column<string>(maxLength: 200, nullable: true),
                    ProjectAdressAr = table.Column<string>(maxLength: 4000, nullable: true),
                    ProjectAdressEn = table.Column<string>(maxLength: 4000, nullable: true),
                    ContentAr = table.Column<string>(maxLength: 4000, nullable: true),
                    ContentEn = table.Column<string>(maxLength: 4000, nullable: true),
                    Filepath = table.Column<string>(maxLength: 500, nullable: true),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrmProjects", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CrmProjects");
        }
    }
}
